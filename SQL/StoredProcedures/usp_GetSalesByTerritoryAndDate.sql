CREATE PROCEDURE usp_GetSalesByTerritoryAndDate
    @TerritoryID INT = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        st.Name AS TerritoryName,
        soh.SalesOrderID,
        soh.OrderDate,
        p.ProductNumber,
        p.Name AS ProductName,
        sod.OrderQty,
        sod.UnitPrice,
        (sod.OrderQty * sod.UnitPrice) AS LineTotal
    FROM Sales.SalesOrderHeader soh
    INNER JOIN Sales.SalesOrderDetail sod
        ON soh.SalesOrderID = sod.SalesOrderID
    INNER JOIN Production.Product p
        ON sod.ProductID = p.ProductID
    INNER JOIN Sales.SalesTerritory st
        ON soh.TerritoryID = st.TerritoryID
    WHERE (@TerritoryID IS NULL OR soh.TerritoryID = @TerritoryID)
      AND (@StartDate  IS NULL OR soh.OrderDate >= @StartDate)
      AND (@EndDate    IS NULL OR soh.OrderDate <= @EndDate)
    ORDER BY soh.OrderDate DESC;
END;
GO
