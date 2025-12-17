-- Subquery Examples (Northwind)

-- 1. Customers who have placed at least one order (IN)
SELECT CustomerID, CompanyName
FROM Customers
WHERE CustomerID IN (
    SELECT CustomerID FROM Orders
);

-- 2. Customers with NO orders (NOT IN)
SELECT CustomerID, CompanyName
FROM Customers
WHERE CustomerID NOT IN (
    SELECT CustomerID FROM Orders
);

-- 3. Correlated subquery: most expensive product per category
SELECT p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice
FROM Products p
WHERE p.UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products
    WHERE CategoryID = p.CategoryID
);

-- 4. EXISTS example (usually best practice)
SELECT c.CustomerID, c.CompanyName
FROM Customers c
WHERE EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);
