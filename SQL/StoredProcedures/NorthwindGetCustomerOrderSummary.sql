-- =============================================
-- Author:        Nick DeNora
-- Procedure:     GetCustomerOrderSummary
-- Description:   Returns all orders for a given CustomerID,
--                with optional date filtering and total order value.
--                Demonstrates INNER JOINs, grouping, and optional parameters.
-- =============================================
CREATE PROCEDURE GetCustomerOrderSummary
    @CustomerID NVARCHAR(5),     -- Required customer identifier
    @StartDate DATE = NULL,      -- Optional: filter orders after this date
    @EndDate DATE = NULL         -- Optional: filter orders before this date
AS
BEGIN
    SET NOCOUNT ON;  -- Prevents extra result sets from interfering

    SELECT 
        c.CustomerID,
        c.CompanyName,
        o.OrderID,
        o.OrderDate,

        -- Calculate total value of an order line:
        -- Quantity × UnitPrice × (1 - Discount)
        -- Discount is stored as a decimal fraction (e.g., 0.10 for 10%)
        SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalOrderValue

    FROM Customers c
    INNER JOIN Orders o
        ON c.CustomerID = o.CustomerID   -- Only matched orders are included
    INNER JOIN [Order Details] od
        ON o.OrderID = od.OrderID

    WHERE c.CustomerID = @CustomerID
      -- Optional filters — only applied if parameters are supplied
      AND (@StartDate IS NULL OR o.OrderDate >= @StartDate)
      AND (@EndDate   IS NULL OR o.OrderDate <= @EndDate)

    GROUP BY 
        c.CustomerID, 
        c.CompanyName, 
        o.OrderID, 
        o.OrderDate

    ORDER BY o.OrderDate DESC;  -- Return most recent orders first
END;
GO
