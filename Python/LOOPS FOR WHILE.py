# -*- coding: utf-8 -*-
"""
Created on Sun Jan 24 13:42:05 2021

@author: CALIT
"""

import pandas


def BasicWhile() :
#basic
    i = 1
while i < 6:
  print(i)
  i += 1
  
#at 3
def  whileLessThan() :  
  i = 1
while i < 6:
    print(i)
    if i == 3:
        break
    i += 1
    i =3
    
    
def continueLoop() :
    
    i = 0
    while i < 6:
        i += 1
        if i == 3:
            continue
        print(i)
        
def whileElse() :
    
    i = 1
while i < 6:
  print(i)
  i += 1
else:
  print("i is no longer less than 6")

#continueLoop()
whileElse()


def forLoop() :
    fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)
  
  
forLoop()
  
def ForLikeAnArray() :
    for x in "banana":
        print(x)
  
ForLikeAnArray()

def ForBreakLoop():
    
    fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)
  if x == "banana":
    break

ForBreakLoop()


    
