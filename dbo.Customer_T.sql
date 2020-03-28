CREATE TABLE [dbo].[Customer_T] (
    [CustomerID]         INT           IDENTITY (1, 1) NOT NULL,
    [CustomerName]       NVARCHAR (25) NOT NULL,
    [CustomerAddress]    NVARCHAR (30) NULL,
    [CustomerCity]       NVARCHAR (20) NULL,
    [CustomerState]      NVARCHAR (2)  NULL,
    [CustomerPostalCode] NVARCHAR (9)  NULL,
    [CustomerVersion] ROWVERSION NULL, 
    CONSTRAINT [PK_Customer_T] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

