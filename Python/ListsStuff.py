# -*- coding: utf-8 -*-
"""
Created on Sun Jan 17 14:26:49 2021

@author: CALIT
"""
myList=['dog','cat','whatever',45,66,'Nick']

import pandas
import io

def printList():
#    print(myList[5])
#    print(myList[2])
#    print(myList[3])
##
        
    for i in range(6):
        print("****")
        print(myList[i])

def printMsg(v_msg):
    print("passed var ",v_msg)
    

print("*************")
printList()

myList[3] ="yo man"


print("*************")
printList()

myList[4] =99

print("\ncomparision\n")
if  myList[4] == myList[5]:
    print("equal")
elif myList[3] == myList[5]:
    print("not equal")
#else 
#    Print("no clue")
printMsg("yo nick" )

string="this is a long string"
print(string[0:3])
print(string.__sizeof__())
#ucaseStuff = upper(string)
print(string.upper())
# Python3 program to show the 
# working of upper() function 
text1 = 'geeks fOr geeks'
  
text2 = 'gEeKS fOR GeeKs'
  
# Comparison of strings using  
# upper() method 
if(text1.upper() == text2.upper()): 
    print("Strings are same") 
else:  
    print("Strings are not same") 

print(len(string))


