
/* CREATE ROLE [sch_HiltiLocalDB_exec] AUTHORIZATION [dbo]; */
/* go */
/* CREATE SCHEMA [sch_HiltiLocalDB] AUTHORIZATION [dbo]; */
/* go */

USE HiltiLocalDB
go

/*CREATE SOP TABLE */
CREATE TABLE [dbo].[Shop]
(
	[Id_Shop] INT IDENTITY(1,1) NOT NULL, 
    [CreatedOn] NVARCHAR(50) NOT NULL,
	[ShopId] INT NOT NULL, 
    [ShopName] NVARCHAR(50) NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [CustomerName] NVARCHAR(50) NOT NULL,
	[ItemId] INT NOT NULL, 
    [ItemName] NVARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Price] NVARCHAR(50) NOT NULL,	
CONSTRAINT [PK_shop] PRIMARY KEY CLUSTERED
	(
	[Id_Shop] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go

USE HiltiLocalDB
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE ReadDataShop    
AS
BEGIN    
    SET NOCOUNT ON;
    select CreatedOn, ShopId, ShopName, CustomerId, CustomerName, ItemId, ItemName, Quantity, Price from Shop
END
GO

--/*CREATE CUSTOMER TABLE */
--CREATE TABLE [dbo].[Customer]
--(
--    [Id_Customer] INT IDENTITY(1,1) NOT NULL, 
--    [CustomerId] NUMERIC NULL, 
--    [CustomerName] NVARCHAR(50) NULL,
--	[Id_Shop] [int] NULL,
--	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
--	(
--	[Id_Customer] ASC
--	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--go

--/*CREATE CUSTOMER CONSTRAINT */
--ALTER TABLE [dbo].[Customer] WITH CHECK ADD CONSTRAINT [PK_Customer_Shop] FOREIGN KEY (Id_Shop)
--REFERENCES [dbo].[Shop](Id_Shop) ON DELETE CASCADE
--go

--ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT  [PK_Customer_Shop]
--go

--/*CREATE CUSTOMER INDEX */
--CREATE INDEX IX_FK_Customer_Shop
-- ON [dbo].[Customer](Id_Shop)
--go

--/*CREATE ITEM TABLE */
--CREATE TABLE [dbo].[Item]
--(
--	[Id_Item] INT IDENTITY(1,1) NOT NULL,
--	[Id_Customer] INT NULL, 
--    [ItemId] NUMERIC NULL, 
--    [ItemName] NVARCHAR(50) NULL, 
--    [Quantity] NUMERIC NULL, 
--    [Price] DECIMAL NULL,
--	CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED
--	(
--	[Id_Item] ASC
--	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--go

--/*CREATE Item CONSTRAINT */
--ALTER TABLE [dbo].[Item] WITH CHECK ADD CONSTRAINT [PK_Item_Customer] FOREIGN KEY (Id_Customer)
--REFERENCES [dbo].[Customer](Id_Customer) ON DELETE CASCADE
--go

--ALTER TABLE [dbo].[Item] CHECK CONSTRAINT  [PK_Item_Customer]
--go

--/*CREATE ITEM INDEX */
--CREATE INDEX IX_FK_Item_Customer
-- ON [dbo].[Item](Id_Customer)
--go


