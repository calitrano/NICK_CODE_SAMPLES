# -*- coding: utf-8 -*-
"""
Number Guessing Game
=====================
The computer picks a random number in a range, the player guesses it,
and gets a "too high" / "too low" hint after each try until they win
or run out of guesses.

Run it with:  python NumberGuessingGame.py
"""

import random


def play_round(low=1, high=100, max_guesses=7):
    """Play one round. Returns True if the player guessed the number."""
    secret = random.randint(low, high)
    print(f"I'm thinking of a number between {low} and {high}.")
    print(f"You have {max_guesses} guesses to find it.")

    for attempt in range(1, max_guesses + 1):
        guess_text = input(f"Guess #{attempt}: ").strip()

        # Validate before int() so a bad entry doesn't crash the game
        if not guess_text.lstrip("-").isdigit():
            print("Please enter a whole number.")
            continue

        guess = int(guess_text)

        if guess == secret:
            print(f"Correct! You got it in {attempt} guess(es).")
            return True
        elif guess < secret:
            print("Too low.")
        else:
            print("Too high.")

    print(f"Out of guesses! The number was {secret}.")
    return False


def main():
    print("=== Number Guessing Game ===")
    wins = 0
    rounds = 0

    while True:
        rounds += 1
        if play_round():
            wins += 1

        again = input("Play again? (y/n): ").strip().lower()
        if again != "y":
            break

    print(f"Final score: {wins} win(s) out of {rounds} round(s). Thanks for playing!")


if __name__ == "__main__":
    main()
