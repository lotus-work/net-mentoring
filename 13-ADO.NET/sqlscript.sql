-- Drop procedure if exists
IF OBJECT_ID('dbo.sp_GetOrdersFiltered', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetOrdersFiltered;
GO

-- Drop tables in correct order to prevent FK issues
IF OBJECT_ID('dbo.[Order]', 'U') IS NOT NULL
    DROP TABLE dbo.[Order];
GO

IF OBJECT_ID('dbo.[Product]', 'U') IS NOT NULL
    DROP TABLE dbo.[Product];
GO

-- Create Product table
CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Weight] DECIMAL(18, 2) NULL, 
    [Height] DECIMAL(18, 2) NULL, 
    [Width] DECIMAL(18, 2) NULL, 
    [Length] DECIMAL(18, 2) NULL
);
GO

-- Create Order table with foreign key to Product
CREATE TABLE [dbo].[Order]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] NVARCHAR(60) NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedDate] DATETIME NULL, 
    [ProductId] INT NULL,
    CONSTRAINT [FK_Order_ToProduct] 
        FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE CASCADE
);
GO

-- Seed Product table
INSERT INTO [Product] ([Name], [Description], [Weight], [Height], [Width], [Length])
VALUES 
    ('Book', 'Usual Product', 12.3, 23.5, 20.0, 43.0),
    ('Flower', 'Romantic Product', 5.5, 100.5, 10.0, 10.0),
    ('Chocolate', 'Sweet Product', 8.7, 2.5, 5.0, 7.0),
    ('Coffe', 'Morning Product', 6.56, 2.3, 4.5, 12.1);
GO

-- Seed Order table
INSERT INTO [Order] ([Status], [CreatedDate], [UpdatedDate], [ProductId])
VALUES 
    ('NotStarted', '2025-02-02', '2020-02-05', 1),
    ('Loading', '2025-02-03', '2020-02-05', 2),
    ('InProgress', '2025-02-01', '2020-02-07', 3),
    ('Arrived', '2025-02-03', '2020-02-08', 2),
    ('Unloading', '2025-01-28', '2020-02-03', 2),
    ('Cancelled', '2025-01-03', '2020-02-04', 1),
    ('Done', '2025-02-03', '2020-02-05', 3);
GO

-- Create stored procedure to filter orders
CREATE PROCEDURE [dbo].[sp_GetOrdersFiltered]
    @Status NCHAR(15) = NULL,
    @CreatedYear INT = NULL,
    @UpdatedMonth INT = NULL,
    @ProductId INT = NULL
AS
BEGIN
    SELECT *
    FROM [Order] o
    WHERE 
        (@Status IS NULL OR LEN(@Status) = 0 OR o.[Status] = @Status)
        AND (@CreatedYear IS NULL OR YEAR(o.CreatedDate) = @CreatedYear)
        AND (@UpdatedMonth IS NULL OR MONTH(o.UpdatedDate) = @UpdatedMonth)
        AND (@ProductId IS NULL OR o.ProductId = @ProductId);
END;
GO
