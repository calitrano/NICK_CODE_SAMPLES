# -*- coding: utf-8 -*-
"""
Created on Sun Jan 10 14:32:21 2021

@author: CALIT
"""

#COMPARE EXCEL FILES.. 
import pandas as pd
import numpy as np
import os
### this is reading the Excel to dataframes... 

cwd = os.getcwd()+"\\"
print(cwd)
df1 =pd.read_excel(cwd+"CompareExcel1.xlsx")
print(df1)

df2 =pd.read_excel(cwd+"CompareExcel2.xlsx")
#print(df2)

#print(df1.equals(df2))

#comparevalues = df1.values == df2.values

#print(comparevalues)


rows,cols = np.where(comparevalues == False)

for item in zip(rows,cols):
        df1.iloc[item[0],item[1]] = '{} --> {} '.format(df1.iloc[item[0],item[1]],df2.iloc[item[0],item[1]])
df1.to_excel(cwd+'output.xlsx',index=False,header=True)


# make sure they are in the correct order 
# make sure account types comparing two files based on account num.

statement_1 = pd.read_csv(cwd+ 'CompareExcel')


