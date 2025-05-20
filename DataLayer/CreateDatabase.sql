CREATE DATABASE ShopDatabase;
GO

USE ShopDatabase;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Type NVARCHAR(50)
);

CREATE TABLE Catalog (
    ProductName NVARCHAR(100) PRIMARY KEY,
    Price FLOAT
);

CREATE TABLE State (
    ProductName NVARCHAR(100) PRIMARY KEY,
    Amount INT,
    Cash FLOAT
); 