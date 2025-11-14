print("Hello world")
## variant variable
myint =7
print(myint)
myfloat = 7.0
print(myfloat)
myfloat = float(7)
print(myfloat)
a, b = 3, 4
print(a,b)
# change this code
mystring = "hello"
myfloat = 10.0
myint = 20
# testing code
if mystring == "hello":
    print("String: %s" % mystring)
if isinstance(myfloat, float) and myfloat == 10.0:
    print("Float: %f" % myfloat)
if isinstance(myint, int) and myint == 20:
    print("Integer: %d" % myint)
    ### do some lists... similar to arrays
mylist = []
mylist.append(1)
mylist.append(2)
mylist.append(3)
print(mylist[0]) # prints 1
print(mylist[1]) # prints 2
print(mylist[2]) # prints 3

# prints out 1,2,3
for x in mylist:
    print(x)    
    count =0
numbers = []
strings = []
names = ["John", "Eric", "Jessica"]

# write your code here
second_name = 'nick'


# this code should write out the filled arrays and the second name in the names list (Eric).
print(numbers)
print(strings)
print("The second name on the names list is %s" % second_name)

# shift alt a is a block commment. 
""" """  """while count < 17:
        print(x)
        count +=1
 """
primes = [2, 3, 5, 7]
for prime in primes:
    print(" PRIME NUMBERS",prime)

# Prints out the numbers 0,1,2,3,4
for x in range(5):
    print(" A RANGE OF NUMBERS",x)

# Prints out 3,4,5
for x in range(3, 6):
    print(" RANGE LOWER AND UPPER",x)

# Prints out 3,5,7
for x in range(3, 8, 2):
    print("RANGE OF HUH",x)


# Prints out 0,1,2,3,4

count = 0
while count < 5:
    print(count)
    count += 1  # This is the same as count = count + 1

# Prints out 0,1,2,3,4

count = 0
while True:  # INFINITE LOOP HERE. 
    print('INFINITE LOOP HERE',count)
    count += 1
    if count >= 5:
        break

# Prints out only odd numbers - 1,3,5,7,9
for x in range(10):
    # Check if x is even
    if x % 2 == 0:
        continue
    print('NOT DIVISIBLE BY 2',x)

# Prints out 0,1,2,3,4 and then it prints "count value reached 5"

count=0
while(count<5):
    print(count)
    count +=1
else:
    print("count value reached %d" %(count))

# Prints out 1,2,3,4
for i in range(1, 10):
    if(i%5==0):
        break
    print(i)
else:
    print("this is not printed because for loop is terminated because of break but not due to fail in condition")

number = 1 + 2 * 3 / 4.0
print('NUMBER AMOUNT',number)
remainder = 11 % 3
print('REMAINDER',remainder)

# RAISES POWERS.. 
squared = 7 ** 2
cubed = 2 ** 3
print(squared)
print(cubed)

helloworld = "hello" + " " + "world"
print(helloworld)

lotsofhellos = "hello" * 10
print(lotsofhellos)


even_numbers = [2,4,6,8]
odd_numbers = [1,3,5,7]
all_numbers = odd_numbers + even_numbers
print(all_numbers)

print([1,2,3] * 3)

# THIS CREATES A LIST YOU CAN SEE HOW MANY OBJECTS YOU HAVE HERE... 
print([1,2,3] * 3)

x = object()
y = object()

# TODO: change this code
x_list = [1,4,5,4]
y_list = [2,4,8]
big_list = [1,23,6,4,6,8,8,9,]

print("x_list contains %d objects" % len(x_list))
print("y_list contains %d objects" % len(y_list))
print("big_list contains %d objects" % len(big_list))

# testing code
if x_list.count(x) == 10 and y_list.count(y) == 10:
    print("Almost there...")
if big_list.count(x) == 10 and big_list.count(y) == 10:
    print("Great!")

# This prints out "Hello, John! STRING FORMATTING"
name = "nICK"
print("Hello, %s!" % name)

# This prints out "John is 23 years old."
name = "nICKEY D"
age = 23
print("%s is %d years old." % (name, age))

# This prints out: A list: [1, 2, 3]
mylist = [1,2,3]
print("A list: %s" % mylist)

""" Here are some basic argument specifiers you should know:

%s - String (or any object with a string representation, like numbers)

%d - Integers

%f - Floating point numbers

%.<number of digits>f - Floating point numbers with a fixed amount of digits to the right of the dot.

%x/%X - Integers in hex representation (lowercase/uppercase) """


data = ("John", "Doe", 53.44)
format_string = "Hello"

print(format_string, data)

