-- BookstorePOS database script (SQL Server / LocalDB)
-- Creates BookstoreDB, its tables and sample data.
-- Run against (localdb)\MSSQLLocalDB (or SQL Server Express).

IF DB_ID(N'BookstoreDB') IS NULL
    CREATE DATABASE BookstoreDB;
GO

USE BookstoreDB;
GO

SET QUOTED_IDENTIFIER ON; -- required by the persisted computed column
GO

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name       NVARCHAR(100) NOT NULL UNIQUE,
    IsActive   BIT NOT NULL DEFAULT 1
);

CREATE TABLE Books (
    BookId     INT IDENTITY(1,1) PRIMARY KEY,
    ISBN       NVARCHAR(20)  NOT NULL UNIQUE,
    Title      NVARCHAR(200) NOT NULL,
    Author     NVARCHAR(150) NOT NULL,
    CategoryId INT NOT NULL,
    Price      DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    Stock      INT NOT NULL CHECK (Stock >= 0),
    MinStock   INT NOT NULL DEFAULT 5 CHECK (MinStock >= 0),
    IsActive   BIT NOT NULL DEFAULT 1,
    CreatedAt  DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Books_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

CREATE TABLE Sales (
    SaleId        INT IDENTITY(1,1) PRIMARY KEY,
    SaleDate      DATETIME2 NOT NULL DEFAULT GETDATE(),
    TotalAmount   DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    PaymentMethod NVARCHAR(50) NOT NULL
);

CREATE TABLE SaleDetails (
    SaleDetailId INT IDENTITY(1,1) PRIMARY KEY,
    SaleId       INT NOT NULL,
    BookId       INT NOT NULL,
    Quantity     INT NOT NULL CHECK (Quantity > 0),
    UnitPrice    DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    Subtotal     AS (Quantity * UnitPrice) PERSISTED,
    CONSTRAINT FK_SaleDetails_Sales FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    CONSTRAINT FK_SaleDetails_Books FOREIGN KEY (BookId) REFERENCES Books(BookId)
);
GO

-- Sample data
INSERT INTO Categories (Name) VALUES
    (N'Fiction'),
    (N'Software Engineering'),
    (N'History'),
    (N'Personal Finance');

INSERT INTO Books (ISBN, Title, Author, CategoryId, Price, Stock, MinStock) VALUES
    (N'978-0132350884', N'Clean Code',        N'Robert C. Martin', 2, 45.99, 9,  5),
    (N'978-0201633610', N'Design Patterns',   N'Erich Gamma',      2, 54.50, 2,  5),
    (N'978-0141036144', N'1984',              N'George Orwell',    1, 15.00, 13, 5),
    (N'978-0062316097', N'Sapiens',           N'Yuval Noah Harari',3, 22.90, 9,  3),
    (N'978-1612680194', N'Rich Dad Poor Dad', N'Robert Kiyosaki',  4, 18.50, 2,  5);
GO
