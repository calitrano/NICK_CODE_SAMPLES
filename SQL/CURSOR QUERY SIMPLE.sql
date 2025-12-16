--First, declare two variables to hold product name and list price, 
--and a cursor to hold the result of a query that retrieves product name 
--and list price from the production.products table:
 -- 04 2020

 use AdventureWorks
 go
DECLARE 
    @product_name VARCHAR(MAX), 
    @list_price   DECIMAL;

DECLARE cursor_product CURSOR   -- giving the cursor a name here. 
FOR SELECT 
        Name, 
        ListPrice
    FROM 
        production.product;
-- Next, open the cursor:
 
OPEN cursor_product;
--Then, fetch each row from the cursor and print out the product name and list price:
 
FETCH NEXT FROM cursor_product INTO 
    @product_name, 
    @list_price;

WHILE @@FETCH_STATUS = 0   -- here is the loop.
    BEGIN
			-- do some task here... 

        --PRINT @product_name + CAST(@list_price AS varchar);
        
		print @product_name
		
		-- get next row here 
		
		FETCH NEXT FROM cursor_product INTO 
            @product_name, 
            @list_price;
    END;
-- After that, close the cursor:  close at the end.
 
CLOSE cursor_product;
-- Finally, deallocate the cursor to release it. give memory back
 
DEALLOCATE cursor_product;