// MarioLikeGame.cpp
//
// Simple console "Mario-like" endless runner. The character auto-runs
// to the right (the world scrolls under a fixed player column) while
// gravity pulls it down. Press SPACE to jump over pipes; hitting one
// while grounded ends the run. Coins add score.
//
// Controls:
//   SPACE - jump
//   Q     - quit
//
// Build (Linux/Mac): g++ -std=c++17 -O2 MarioLikeGame.cpp -o mario
// Build (Windows):   run through MinGW g++, or MSVC's cl.exe
// Run:                ./mario

#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <cstdlib>
#include <ctime>
#include <chrono>
#include <thread>

#ifdef _WIN32
    #include <conio.h>
#else
    #include <unistd.h>
    #include <termios.h>
    #include <fcntl.h>
#endif

// ---------------------------------------------------------------------
// Cross-platform, non-blocking "was a key pressed?" helper.
// A real-time jump can't wait for Enter, so std::cin won't work here -
// on Windows we use conio's _kbhit()/_getch(); on Linux/Mac we put the
// terminal in raw, non-blocking mode so read() returns immediately
// with 0 bytes when nothing was typed.
// ---------------------------------------------------------------------
#ifndef _WIN32
namespace {
    termios g_originalTerm;

    void enableRawMode() {
        termios raw;
        tcgetattr(STDIN_FILENO, &g_originalTerm);
        raw = g_originalTerm;
        raw.c_lflag &= ~(ICANON | ECHO);            // no line buffering, no echo
        tcsetattr(STDIN_FILENO, TCSANOW, &raw);
        fcntl(STDIN_FILENO, F_SETFL, O_NONBLOCK);     // read() never blocks
    }

    void disableRawMode() {
        tcsetattr(STDIN_FILENO, TCSANOW, &g_originalTerm);
    }
}
#endif

bool pollKey(char& out) {
#ifdef _WIN32
    if (_kbhit()) {
        out = static_cast<char>(_getch());
        return true;
    }
    return false;
#else
    char c;
    if (read(STDIN_FILENO, &c, 1) > 0) {
        out = c;
        return true;
    }
    return false;
#endif
}

// ---------------------------------------------------------------------
// World constants
// ---------------------------------------------------------------------
const int WIDTH          = 50;  // visible columns
const int GROUND_ROW      = 6;   // row the character stands on
const int PLAYER_COL      = 8;   // player's fixed screen column (world scrolls past it)
const int JUMP_VELOCITY   = -3;  // initial upward speed (negative = up)
const int GRAVITY         = 1;   // added to velocity every tick

struct Obstacle {
    int x;        // column position in world space
    char symbol;   // '|' pipe (deadly on the ground) or '*' coin (collectible)
};

int main() {
#ifndef _WIN32
    enableRawMode();
#endif
    std::srand(static_cast<unsigned>(std::time(nullptr)));

    int playerRow = GROUND_ROW;
    int velocity = 0;
    bool jumping = false;

    std::vector<Obstacle> obstacles;
    int distance = 0;
    int score = 0;
    int spawnTimer = 5;
    bool gameOver = false;
    bool quit = false;

    std::cout << "=== Super C++ Runner ===\n";
    std::cout << "SPACE = jump, Q = quit. Starting in 2 seconds...\n";
    std::this_thread::sleep_for(std::chrono::seconds(2));

    while (!gameOver && !quit) {
        // ---- input ----
        char key;
        if (pollKey(key)) {
            if (key == ' ' && !jumping) {
                jumping = true;
                velocity = JUMP_VELOCITY;
            } else if (key == 'q' || key == 'Q') {
                quit = true;
                break;
            }
        }

        // ---- physics: simple jump arc under constant gravity ----
        if (jumping) {
            playerRow += velocity;
            velocity += GRAVITY;
            if (playerRow >= GROUND_ROW) {
                playerRow = GROUND_ROW;
                jumping = false;
                velocity = 0;
            }
        }

        // ---- scroll the world toward the player ----
        distance++;
        for (auto& o : obstacles) o.x--;
        obstacles.erase(
            std::remove_if(obstacles.begin(), obstacles.end(),
                            [](const Obstacle& o) { return o.x < 0; }),
            obstacles.end());

        // ---- spawn a new pipe or coin off the right edge ----
        if (--spawnTimer <= 0) {
            char symbol = (std::rand() % 4 == 0) ? '*' : '|'; // mostly pipes, some coins
            obstacles.push_back({WIDTH - 1, symbol});
            spawnTimer = 10 + std::rand() % 8;
        }

        // ---- collisions happen only at the player's fixed column ----
        for (auto it = obstacles.begin(); it != obstacles.end(); ) {
            if (it->x == PLAYER_COL) {
                if (it->symbol == '*') {
                    score += 10;
                    it = obstacles.erase(it);
                    continue;
                } else if (playerRow == GROUND_ROW) { // pipe reached while grounded
                    gameOver = true;
                }
            }
            ++it;
        }

        // ---- draw the frame ----
        std::cout << "\x1B[2J\x1B[H"; // ANSI: clear screen, cursor to top-left
        std::vector<std::string> screen(GROUND_ROW + 1, std::string(WIDTH, ' '));
        for (auto& o : obstacles)
            if (o.x >= 0 && o.x < WIDTH) screen[GROUND_ROW][o.x] = o.symbol;
        if (playerRow >= 0 && playerRow <= GROUND_ROW)
            screen[playerRow][PLAYER_COL] = 'M';

        std::cout << "Score: " << score << "   Distance: " << distance << "\n";
        for (auto& row : screen) std::cout << row << "\n";
        std::cout << std::string(WIDTH, '=') << "\n";

        std::this_thread::sleep_for(std::chrono::milliseconds(120));
    }

#ifndef _WIN32
    disableRawMode();
#endif

    std::cout << "\nGame over! Final score: " << score
              << "  (distance " << distance << ")\n";
    return 0;
}
