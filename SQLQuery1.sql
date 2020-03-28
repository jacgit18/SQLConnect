Select * from Customer_T

Update Customer_T set CustomerName = 'ContemporaryCausals', CustomerAddress= '1355 S Hines BLVD', CustomerCity = 'Gainesville', CustomerState='NY',
CustomerPostalCode= '326012871' where 
CustomerID = 1


Update Customer_T set CustomerName = @customername where 
CustomerID = @customerid and VersionNumber = @version



Update Customer_T set CustomerCity = 'Dallas' where 
CustomerID = 2

Update Customer_T set CustomerName = 'Jones', CustomerCity ='NYC' where 
CustomerID = 3