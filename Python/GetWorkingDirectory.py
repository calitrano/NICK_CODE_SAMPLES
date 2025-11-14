# -*- coding: utf-8 -*-
"""
Created on Sun Jan 10 14:14:45 2021

@author: CALIT
"""


import pandas as pd
import sys
import os
import os.path
#import pathlib

# Nick indentation is everything, you need to indent even try catch's or it gets screwed up.. its like RPG.


from datetime import datetime

now = datetime.now() # current date and time

year = now.strftime("%Y")
print("year:", year)

month = now.strftime("%m")
print("month:", month)

day = now.strftime("%d")
print("day:", day)

time = now.strftime("%H:%M:%S")

print("time:", time)

date_time = now.strftime("%m/%d/%Y, %H:%M:%S")
print("date and time:",date_time)	
SimpleTime = now.strftime("%H%M%S")

print("just time: ",SimpleTime)
print("current working directory",os.getcwd())


##fileWithTimeStamp = "E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate"+'_'+SimpleTime+'.txt'

#fileWithTimeStamp = "E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt"
fileWithTimeStamp = os.getcwd()+"\\"+"NickTestCreate.txt"
print("file with time stamp : ",fileWithTimeStamp)

### NEED TO HAVEE DOUBLE \\ SLASHES... FOR DIRECTORIES... 
