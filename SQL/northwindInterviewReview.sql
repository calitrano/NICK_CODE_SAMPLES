/****** Script for SelectTopNRows command from SSMS  ******/
/*
Purpose:
Demonstrates practical SQL JOIN behavior, aggregation,
and row-preservation logic using the Northwind database.

Focus:
- LEFT vs INNER JOIN
- Aggregates (COUNT, MIN)
- DISTINCT behavior
*/

SELECT c.CustomerID,
       c.CompanyName,
       o.OrderID
FROM [Northwind].[dbo].[Customers] c
LEFT JOIN [Northwind].[dbo].Orders o
    ON c.CustomerID = o.CustomerID;

-- Why LEFT JOIN is better than INNER JOIN 

--INNER JOIN = “only show rows that match on both sides”

--LEFT JOIN = “show everyone on the left, matched or not”

--If you’re unsure which one to use,
--use LEFT JOIN 99% of the time when exploring data.
SELECT
[CustomerID],
--      ,[CompanyName]
--      ,[ContactName]
--      ,[ContactTitle]
--      ,[Address]
      COUNT([City]) AS 'CITIES'
      --,[Region]
      --,[PostalCode]
      --,[Country]
      --,[Phone]
      --,[Fax]
  FROM [Northwind].[dbo].[Customers]

  GROUP BY  CustomerID


  SELECT DISTINCT CITY
  FROM [Northwind].[dbo].[Customers]

SELECT CITY
  FROM [Northwind].[dbo].[Customers]
GROUP BY CITY

SELECT COUNT(ContactName) AS 'COUNT OF CUST'
, CITY
  FROM [Northwind].[dbo].[Customers]
GROUP BY CITY

SELECT MIN([CustomerID]) AS 'MIN', CITY
  FROM [Northwind].[dbo].[Customers]
  GROUP BY  City  -- AGGREGATE NOT NEEDED HERE


select c.CustomerID, c.CompanyName, o.OrderDate
from Northwind.dbo.Customers c left join
   Northwind.dbo.Orders o on c.CustomerID = o.CustomerID


   
select o.OrderID,o.OrderDate, e.FirstName+'  '+e.LastName

from    Northwind.dbo.Orders o left join
   Northwind.dbo.Employees e on e.EmployeeID = o.EmployeeID


   
select o.OrderID,o.OrderDate, e.FirstName+'  '+e.LastName  -- -- INNER JOIN works here because every Order must have an Employee.
															-- LEFT JOIN is safer when relationship assumptions are uncertain.


from    Northwind.dbo.Orders o inner join
   Northwind.dbo.Employees e on e.EmployeeID = o.EmployeeID


SELECT COUNT(*) AS TotalOrders_LeftJoin
FROM Northwind.dbo.Orders o
LEFT JOIN Northwind.dbo.Employees e
    ON e.EmployeeID = o.EmployeeID;

SELECT COUNT(*) AS TotalOrders_InnerJoin  -- same result, still use left join on the TABLE WHICH YOU WANT. QUESTION: SHOW ME ORDERS, STOP! "ORDERS WOULD BE THE LEFT TABLE".
FROM Northwind.dbo.Orders o
INNER JOIN Northwind.dbo.Employees e
    ON e.EmployeeID = o.EmployeeID;

---------shows superiority of left join. 
SELECT COUNT(*) AS TotalCustomers
FROM Northwind.dbo.Customers;

SELECT COUNT(*) AS Customers_LeftJoin
FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Orders o
    ON c.CustomerID = o.CustomerID;

SELECT COUNT(*) AS Customers_InnerJoin
FROM Northwind.dbo.Customers c
INNER JOIN Northwind.dbo.Orders o
    ON c.CustomerID = o.CustomerID;
	---------------- basically inner join restricts rows


--	⭐ Summary in 1 line:
--LEFT JOIN = keep everyone
--INNER JOIN = keep only matches


select distinct c.CustomerID, c.CompanyName  
--⭐ Summary (one line)
--DISTINCT removes duplicate FULL rows — not individual columns. this takes everything after distinct as a pair. which cannot be repeated as a pair or a set!
	from Northwind.[dbo].[Customers] c inner join Orders o on c.CustomerID = o.CustomerID
	order by c.CustomerID


select * from 
northwind.dbo.customers c inner join northwind.dbo.orders o on c.CustomerId = o.CustomerId