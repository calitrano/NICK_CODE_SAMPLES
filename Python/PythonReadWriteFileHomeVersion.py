# -*- coding: utf-8 -*-
"""
Created on Tue Jan  5 14:52:29 2021

@author: TDEVND1
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


fileWithTimeStamp = "E:\\COMPUTER STUFF\\PYTHON PROGRAMMING\\NickTestCreate"+'_'+SimpleTime+'.txt'

#fileWithTimeStamp = 'E:\\COMPUTER STUFF\\PYTHON PROGRAMMING\\NickTestCreate.txt'
fileWithTimeStamp = os.getcwd()+"\\"+"NickTestCreate.txt"
print("file with time stamp : ",fileWithTimeStamp)

def myTestFunction():
    x = 300
    print(x)
    print("python uses indents for code blocks")
    print("variables in a function are local scope")


def readASimpleTextFile():

    print("\n*** in function readASimpleTextFile")

    try:
       print('try reading a file')
       file="nickTest.txt"
       path=os.getcwd() + "/" + file
       #path=wdir+file
       print(path)
       with open('E:\\COMPUTER STUFF\\PYTHON PROGRAMMING\\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
       #  with open(path,'r')
#    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
#    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
# with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
      
            
    #file.readlines()
       # print(reader.readlines(1))
        #    print(file()
    #list(file)
#    with open as reader:
#        print(reader.readlines(1))
#        print(reader.read())
#    
         line = fileObject.readline()  # like a priming read.
         while line != '': # the eof character will be empty str.
           print(line, end='')  # print with eof character.
                #  print(line, end='\n')  # print with eof character.
           line = fileObject.readline() 
#    if not line:         
#          break
           content = line
           for line in content:
                word = line.split()
                print(word)
           #content = file.readlines()
      
          
       print("\nfinished reading file", end='\n\n')
     
    
    
    except:
    # catch *all* exceptions
      print("\nUh oh Issues, Hit the exception !!!! ")
      e = sys.exc_info()[0]
      print( "<p>Error: %s</p>" % str(e) )
      print(str(e))
   
    finally:
        print("\nClosing the file Bye ")
        #file.close()
        fileObject.close()
 #       fileWrite.close()
    

  
def readAndWriteToTextFile():
    
   try:
       print('\n*** try reading a file and writing it out inside the read and write')
           # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
       fileWrite = open('E:\\COMPUTER STUFF\\PYTHON PROGRAMMING\\NickTestWrite.txt','w') ## To write to an existing file, you must add a parameter to the open() function:

       with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
        # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
    # my_file = os.path("E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt")
#    if my_file.is_file():
#        print("File exists")
#    # test
#    else:
#                # fileCreate = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt','x')  # "x" - Create - will create a file, returns an error if the file exist
#        print("part of else")
#             
#     # fileAppend = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestAppend.txt','a')  # "a" - Append - will create a file if the specified file does not exist
##    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
##
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
### with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
##
##    #file.readlines()
##       # print(reader.readlines(1))
##        #    print(file()
##    #list(file)
###    with open as reader:
###        print(reader.readlines(1))
###        print(reader.read())
###    
           line = fileObject.readline()  # like a priming read.
           while line != '': # the eof character will be empty str.
               print(line, end='')  # print with eof character.
               fileWrite.write(line)
                #  print(line, end='\n')  # print with eof character.
               line = fileObject.readline() 
##         
###    if not line:         
###          break
            
            
            
   except:
            # catch *all* exceptions
              print("\nUh oh Issues, Hit the exception !!!! ")
              e = sys.exc_info()[0]
              print( "<p>Error: %s</p>" % str(e) )
              print(str(e))
           
   finally:
            print("\nClosing the file Bye ")
            #file.close()
            fileObject.close()
            fileWrite.close()
    
  
def readAndAppendToTextFile():
    
   try:
       print('\n*** try reading a file and Appending it out inside the read and write')
           # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
       #fileWrite = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestWrite.txt','w') ## To write to an existing file, you must add a parameter to the open() function:
       fileAppend = open('E:\\COMPUTER STUFF\\PYTHON PROGRAMMING\\NickTestAppend.txt','a')  # "a" - Append - will create a file if the specified file does not exist

       with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
        # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
    # my_file = os.path("E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt")
#    if my_file.is_file():
#        print("File exists")
#    # test
#    else:
#                # fileCreate = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt','x')  # "x" - Create - will create a file, returns an error if the file exist
#        print("part of else")
#             
##    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
##
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
### with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
##
##    #file.readlines()
##       # print(reader.readlines(1))
##        #    print(file()
##    #list(file)
###    with open as reader:
###        print(reader.readlines(1))
###        print(reader.read())
###    
           line = fileObject.readline()  # like a priming read.
           while line != '': # the eof character will be empty str.
               print(line, end='')  # print with eof character.
               fileAppend.write(line)
                #  print(line, end='\n')  # print with eof character.
               line = fileObject.readline() 
##         
###    if not line:         
###          break
            
            
            
   except:
            # catch *all* exceptions
              print("\nUh oh Issues, Hit the exception !!!! ")
              e = sys.exc_info()[0]
              print( "<p>Error: %s</p>" % str(e) )
              print(str(e))
           
   finally:
            print("\nClosing the file Bye ")
            #file.close()
            fileObject.close()
            fileAppend.close()

def readAndCreateFileThenWriteToTextFile():
    
   try:
       print('\n*** try reading a file and Creating a new file then write to it \n')
           # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
       #fileWrite = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestWrite.txt','w') ## To write to an existing file, you must add a parameter to the open() function:
     #  fileAppend = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestAppend.txt','a')  # "a" - Append - will create a file if the specified file does not exist
   
       # this file is created as a global variable so it is never the same, same files fail on error. 
       fileCreate = open(fileWithTimeStamp,'x')  # "x" - Create - will create a file, returns an error if the file exist

########### with open requires a code Block !!! 
       with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
        # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
    # my_file = os.path("E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt")
#    if my_file.is_file():
#        print("File exists")
#    # test
#    else:
#  
#        print("part of else")
#             
##    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
##
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
### with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
##
##    #file.readlines()
##       # print(reader.readlines(1))
##        #    print(file()
##    #list(file)
###    with open as reader:
###        print(reader.readlines(1))
###        print(reader.read())
###    
           line = fileObject.readline()  # like a priming read.
           while line != '': # the eof character will be empty str.
               print(line, end='')  # print with eof character.
               fileCreate.write(line)
                #  print(line, end='\n')  # print with eof character.
               line = fileObject.readline() 
##         
###    if not line:         
###          break
            
            
            
   except:
            # catch *all* exceptions
              print("\nUh oh Issues, Hit the exception !!!! ")
              e = sys.exc_info()[0]
              print( "<p>Error: %s</p>" % str(e) )
              print(str(e))
           
   finally:
            print("\nClosing the file Bye ")
            #file.close()
            fileObject.close()
            fileCreate.close()
            

def CompareTwoFiles():
    
   try:
    print('\n*** doing a file Compare \n')
           # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
       #fileWrite = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestWrite.txt','w') ## To write to an existing file, you must add a parameter to the open() function:
     #  fileAppend = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestAppend.txt','a')  # "a" - Append - will create a file if the specified file does not exist
   
       # this file is created as a global variable so it is never the same, same files fail on error. 
    #   fileCreate = open(fileWithTimeStamp,'x')  # "x" - Create - will create a file, returns an error if the file exist

########### with open requires a code Block !!! 
    #   with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
        #    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
        # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
    # my_file = os.path("E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt")
       
#    if my_file.is_file():
#        print("File exists")
#    # test
#    else:
#  
#        print("part of else")
#             
##    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
##
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
### with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
##
##    #file.readlines()
##       # print(reader.readlines(1))
##        #    print(file()
##    #list(file)
###    with open as reader:
###        print(reader.readlines(1))
###        print(reader.read())
###    

    with open('some_file_1.txt', 'r') as file1:
        with open('some_file_2.txt', 'r') as file2:
            same = set(file1).intersection(file2)

    #same.discard('\n')

    with open('compare_output_file.txt', 'w') as file_out:
        for line in same:
            file_out.write(line)
            
#            line = fileObject.readline()  # like a priming read.
#            while line != '': # the eof character will be empty str.
#                   print(line, end='')  # print with eof character.
#                   fileCreate.write(line)
#                #  print(line, end='\n')  # print with eof character.
#                   line = fileObject.readline() 
###         
###    if not line:         
###          break
            
            
            
   except:
            # catch *all* exceptions
              print("\nUh oh Issues, Hit the exception !!!! ")
              e = sys.exc_info()[0]
              print( "<p>Error: %s</p>" % str(e) )
              print(str(e))
           
   finally:
            print("\nClosing the file Bye ")
            #file.close()
            file1.close()
            file2.close()
  
def CompareTwoFilesAnotherWay():
    
   try:
    print('\n*** doing a file Compare different \n')
    

    with open('some_file_1.txt', 'r') as file1:
      with open('some_file_1.txt', 'r') as file2:
        difference = set(file1).difference(file2)

    difference.discard('\n')

    with open('diff.txt', 'w') as file_out:
      for line in difference:
        file_out.write(line)
        
            
            
   except:
            # catch *all* exceptions
              print("\nUh oh Issues, Hit the exception !!!! ")
              e = sys.exc_info()[0]
              print( "<p>Error: %s</p>" % str(e) )
              print(str(e))
           
   finally:
            print("\nClosing the file Bye ")
            file_out.close()
            file2.close()
            file1.close()
 
        
  
def EndFunction():
    print('\n*** in End Function We made it to the end End Function '+time)

def hello_world():
    print("\nHello world function")

################## pgm starts here... 

def main():
    print("\nin Main function "+time)
  
    
    
    
##########################################################################################################################
##########################################################################################################################
##########################################################################################################################
###   pgm starts here. 
##########################################################################################################################
##########################################################################################################################
##########################################################################################################################



if __name__ == "__main__":
    main()

#print("Guru99")

#readASimpleTextFile()
readAndWriteToTextFile()
#readAndAppendToTextFile()
#readAndCreateFileThenWriteToTextFile()
#CompareTwoFiles()
#CompareTwoFilesAnotherWay()
EndFunction()



def SAVE_EVERYTHING():
 #   try:
        print('try reading a file')
    # myTestFunction()
   # with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
#    fileWrite = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestWrite.txt','w')   ## To write to an existing file, you must add a parameter to the open() function:
   # my_file = os.path("E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt")
#    if my_file.is_file():
#        print("File exists")
#    # test
#    else:
#                # fileCreate = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestCreate.txt','x')  # "x" - Create - will create a file, returns an error if the file exist
#        print("part of else")
#             
#     # fileAppend = open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\NickTestAppend.txt','a')  # "a" - Append - will create a file if the specified file does not exist
##    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\nickTest.txt','r') as fileObject: ### comment here. just in the same folder for now.
##
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\PRODcnslcandi_122220.txt','r') as fileObject: ### comment here. just in the same folder for now.
###    with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\UnconsciousBias.pdf','r') as fileObject: ### comment here. just in the same folder for now.
### with open('E:\COMPUTER STUFF\PYTHON PROGRAMMING\REL_Code_20201231.xlsx','r') as fileObject: ### read and excel file.
##
##    #file.readlines()
##       # print(reader.readlines(1))
##        #    print(file()
##    #list(file)
###    with open as reader:
###        print(reader.readlines(1))
###        print(reader.read())
###    
##        line = fileObject.readline()  # like a priming read.
##    while line != '': # the eof character will be empty str.
##        print(line, end='')  # print with eof character.
##        fileWrite.write(line)
##                #  print(line, end='\n')  # print with eof character.
##        line = fileObject.readline() 
##         
###    if not line:         
###          break
##         
##          
#    print("\nfinished reading file", end='\n\n')
#    
#    
#    
#    
#    
#except:
#    # catch *all* exceptions
#      print("Uh oh Issues, Hit the exception !!!! ")
#      e = sys.exc_info()[0]
#      print( "<p>Error: %s</p>" % str(e) )
#      print(str(e))
#   
#finally:
#    print("Closing the file Bye ")
#    #file.close()
#    fileObject.close()
#    fileWrite.close()
#    
  
#    write_to_page()