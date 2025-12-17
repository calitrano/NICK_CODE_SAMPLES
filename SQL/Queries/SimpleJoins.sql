-- Sample JOIN Queries (Northwind)

-- 1. INNER JOIN: show only customers with orders
SELECT c.CustomerID, c.CompanyName, o.OrderID, o.OrderDate
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerID = o.CustomerID;

-- 2. LEFT JOIN: show all customers, even if they have no orders
SELECT c.CustomerID, c.CompanyName, o.OrderID, o.OrderDate
FROM Customers c
LEFT JOIN Orders o
    ON c.CustomerID = o.CustomerID;

-- 3. LEFT JOIN with filter preserved in ON
SELECT c.CustomerID, c.CompanyName, o.OrderID, o.OrderDate
FROM Customers c
LEFT JOIN Orders o
    ON c.CustomerID = o.CustomerID
   AND YEAR(o.OrderDate) = 1997;

-- 4. Multi-join chain: customers → orders → order details
SELECT c.CustomerID, o.OrderID, od.ProductID, od.Quantity
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od
    ON o.OrderID = od.OrderID;
