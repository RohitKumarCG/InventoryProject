--Developed by Rohit Kumar
--Creation Date: 28/09/2019
--Modified Date: 
--Script to create table


--creating database
Create Database Inventory
Go

--using the created database
use Inventory
Go

--creating schema
CREATE SCHEMA RMA
Go

--creating table for RawMaterial
CREATE Table RMA.RawMaterial
(
RawMaterialID uniqueidentifier CONSTRAINT RawMaterialPK PRIMARY KEY,
RawMaterialName varchar(30) NOT NULL,
RawMaterialCode varchar(5) NOT NULL CONSTRAINT RMCodeUnique UNIQUE,
RawMaterialPrice decimal NOT NULL CONSTRAINT RMPriceNotNegative Check (RawMaterialPrice > 0),
CreationDateTime datetime2,
LastUpdateDateTime datetime2
)
Go



--creating schema
CREATE SCHEMA Prod
Go

--creating table for Product
CREATE Table Prod.Product
(
ProductID uniqueidentifier CONSTRAINT ProductPK PRIMARY KEY,
ProductName varchar(30) NOT NULL,
ProductCode varchar(5) NOT NULL CONSTRAINT PCodeUnique UNIQUE,
ProductPrice decimal NOT NULL CONSTRAINT PPriceNotNegative Check (ProductPrice > 0),
ProductType varchar(12) NOT NULL CONSTRAINT PTypeIN Check (ProductType in('Mocktail','Soft Drink','Energy Drink','Juice','Tonic Water')),
CreationDateTime datetime2,
LastUpdateDateTime datetime2
)
Go