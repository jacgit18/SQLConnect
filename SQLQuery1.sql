Update Customer_T set CustomerName = 'joe' where 
CustomerID = 2 and VersionNumber = 5

--Customer ID : 2  Name:Smith   Version : 5  when we did select


--Customer ID : 2  Name:Smith   Version : 6  when we do update 1 records updated

--..others have updated the record
--Customer ID : 2  Name:jack   Version : 6  when we do update 0 records updated

---  Version parm is the Version number of the record when we did thhe select

