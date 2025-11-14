// C++CONSOLE_APP_POINTERS_REF_ETC.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
// HOPEFULLY HIGHLIGHTING
//
using namespace std;
#include <iostream>
#include <vector>
#pragma once  // prevents duplicate headers from the build. 
using namespace std; // for cout to work w/o std:
#include "PointerTestModule.h"
//#include "PointerTestModule.h"
//#include "PointerTestModule.h"

// adding a change on 11/3/25... 12:00 noon.
// hoping this works., uncommitted changes from laptop 11/3/25 1:43 pm. 
// gonna paste this 11/4/25 at 3:16 pm. wish me luck! 
// omg it works !!! 11/4/25... 3:21 finally??? 
// c++ test on saturday 11/8/25 1:04 pm. 

void doubleValue(int* p)
{

	*p = *p * 2;
	cout << "\n double value -->>>  " << *p << "\n";

}
void PointerToArray()
{
	/*
	int* arrInt = new int[5];
	double* arrDbl = new double[5];
	char* arrChar = new char[20];
	*/

	int* arr = new int[5];  // "NEW IS ALLOCATION OF MEMORY " 
	/*you’re doing three things under the hood :

	Ask for memory :
		new int[5] tells the system, “give me enough space for five int values on the heap.”  ALLOCATION!!! 
		That’s the creation at runtime — the size can even come from user input.

		Get a pointer back :
	The result of new int[5] is an address — the starting point of that block of memory.
		arr holds that address.It doesn’t “contain” the numbers; it just points to them.

		Use it like an array:
	arr[0], arr[1], … work because C++ knows the typeand can step through memory in sizeof(int) increments.

		You can picture it like :

	cpp
		Copy code
		arr →[int][int][int][int][int]*/
	cout << "\n array time ";
	cout << "*arr: " << *arr << endl;    // the value at that address, 42

	//modern vector to automatically size array
//#include <vector>
	int n = 9;
	vector<int> arrV(n);

	arrV[0] = 5;

	std::cout << " vector array size " << arrV.size();

	vector<string> students;  // start empty

	students.push_back("Nick");
	students.push_back("Maria");
	students.push_back("Alex");

	cout << "\n Students so far: " << " \n" << endl;
	for (const string& name : students)
		cout << name << endl;

	// add another later
	students.push_back("Jordan");

	cout << "\nAfter adding one more:" << endl;
	for (const string& name : students)
		cout << name << endl;

	cout << "\nCurrent count: " << students.size() << endl;

	
	delete[] arr; // deaccolated memory here !!! intensionally. 

	auto p = std::make_unique<int>(123);    // allocates & manages it
	std::cout << *p << std::endl;
	// no delete needed — automatically freed when going out of scope

	struct Person // here is a struct created... with a "name" member. 
	{
		string name;
		void greet() 
		{
			cout << "Hi, I'm " << name << endl; 
		}
	};

	Person nick = { "Nick" }; // nick is an instance of type "Person"
	Person* pNick = &nick;  // pointer is created of type struct and the address is assigned by using the &

	cout << " calling struct with '.' Instance.Method " << endl;
	nick.greet();      // uses .
//	cout << " calling struct with '.' Instance.memberMethod " << endl; 
	nick.name = "fred"; // change the member with . dot notation. 
	cout << " change the member '.' Instance.member  'nick.name = fred' "<< nick.name << endl;

	cout << " calling struct pointer  with '->' Pointer.Method arrow syntax " << endl;
	pNick->greet();    // uses -> because it's a pointer
	pNick->name = "Tom";
	cout << " change the member '-> ' Instance->member 'pNick->name = Tom' " << nick.name << endl;

	struct Per
	{
		string name;
		string lname;
	};

	//struct Per p{ "Joe","Obergfell" };
	//cout << p.name << endl;  // access with dot

	//cout << " struct name " << p.name << endl;
	//p.operator bool

}
class Animal {

	// class verusus struct !
public:
	virtual void speak() { cout << "Some animal sound\n"; }
	virtual ~Animal() = default;
};

class Dog : public Animal {

	// inheritence !
public:
	void speak() override { cout << "Woof!\n"; }
};

struct Creature {

	// class verusus struct !
	virtual void speak() { cout << "Some creature sound\n"; }
	virtual ~Creature() = default;
};

struct Cat : Creature {
	// inheritence !
	void speak() override { cout << "Meow!\n"; }
};


//• Both use inheritance.
//• Both have virtual methodsand destructors.
//• Both use->because we’re dealing with pointers.
//• The only difference is class defaults to private, while struct defaults to public.
//So, if you rewrote one as the otherand adjusted the public: line, they’d compile exactly the same.
//	Would you like me to add one more twist — showing what happens if you forget the virtual keyword ?

class Car
{

	string make;  /// IMPORTANT DEFAULTS TO PRIVATE!
};

void PointerTest()
{
	cout << "\n ******************************** \n";
	cout << "        Doing Pointer Work ! \n";
	cout << " ******************************** \n";

	// A pointer in C++ is a variable that stores the memory address of another variable. NOT the variable itself. 
	// Indirect access	A pointer lets you touch a variable without knowing its name — just where it lives.
	// 	That means you can pass data aroundand modify it from anywhere, instead of returning copies.

	int n_int = 42;
	//Now you can double any variable by giving its address. No copying, no return values.
	//Efficiency	Pointers let you avoid copying large structures.Instead of passing a 500 - element array, you just pass its address — 8 bytes.
	// Variables store values.
	// Pointers store connections — they let code share, reshape, and manage memory itself.

	// linked list test next !
	int x = 42;
	int* p = &x;   // p stores the address of x

	cout << "x:  " << x << endl;     // prints the value 42
	cout << "&x: " << &x << endl;    // prints the address of x
	cout << "p:  " << p << endl;     // same as &x — the address it holds
	cout << "*p: " << *p << endl;    // the value at that address, 42

}

int main()
{


	std::cout << "Hello World!\n";

	for (size_t i = 0; i < 4; i++)
	{
		cout << " Nick was here ! \n";
	}

	PointerTestModule p13;

	p13.Run();


	PointerTestModule Pointer1;

	Pointer1.nickWasHere();

	PointerTest();


	PointerToArray();

	int lint = 66;
	int* lptrInt = &lint;
	doubleValue(lptrInt);

	
		/// <summary>
		///  class versus struct test here !!! 
		/// 	
	Animal* a = new Dog();
	Creature* c = new Cat();

	a->speak();  // Woof!
	c->speak();  // Meow!


	delete a;
	delete c;
		/// </summary>
		/// <returns></returns>

	
	
}




// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
