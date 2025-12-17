-- Group By Examples (Northwind)

-- 1. Total orders per customer
SELECT c.CustomerID, c.CompanyName, COUNT(*) AS TotalOrders
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName
ORDER BY TotalOrders DESC;

-- 2. Total revenue per product
SELECT od.ProductID, p.ProductName,
       SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalRevenue
FROM [Order Details] od
INNER JOIN Products p
    ON od.ProductID = p.ProductID
GROUP BY od.ProductID, p.ProductName
ORDER BY TotalRevenue DESC;

-- 3. HAVING example: customers with > 10 orders
SELECT CustomerID, COUNT(*) AS OrderCount
FROM Orders
GROUP BY CustomerID
HAVING COUNT(*) > 10;
