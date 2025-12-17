-- Window Function Examples (AdventureWorks)

-- 1. Row numbers per territory
SELECT 
    st.Name AS TerritoryName,
    soh.SalesOrderID,
    soh.OrderDate,
    ROW_NUMBER() OVER (PARTITION BY st.Name ORDER BY soh.OrderDate DESC) AS RowNumber
FROM Sales.SalesOrderHeader soh
INNER JOIN Sales.SalesTerritory st
    ON soh.TerritoryID = st.TerritoryID;

-- 2. Running total of sales per customer
SELECT
    soh.CustomerID,
    soh.SalesOrderID,
    soh.OrderDate,
    sod.LineTotal,
    SUM(sod.LineTotal) OVER (
        PARTITION BY soh.CustomerID
        ORDER BY soh.OrderDate
    ) AS RunningTotal
FROM Sales.SalesOrderHeader soh
INNER JOIN Sales.SalesOrderDetail sod
    ON soh.SalesOrderID = sod.SalesOrderID;

-- 3. Ranking products by sales
SELECT
    p.ProductID,
    p.Name AS ProductName,
    SUM(sod.LineTotal) AS TotalSales,
    RANK() OVER (ORDER BY SUM(sod.LineTotal) DESC) AS SalesRank
FROM Sales.SalesOrderDetail sod
INNER JOIN Production.Product p
    ON sod.ProductID = p.ProductID
GROUP BY p.ProductID, p.Name;
