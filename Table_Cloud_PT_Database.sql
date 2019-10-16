--Script to create table

--creating database
use [13th Aug CLoud PT Immersive]
Go

--creating schema
Create SCHEMA Team_D
Go

--creating table for RawMaterial
CREATE Table Team_D.RawMaterial
(
--Developed by Rohit Kumar on 28/09/2019
RawMaterialID uniqueidentifier CONSTRAINT RawMaterialPK PRIMARY KEY,
RawMaterialName varchar(30) NOT NULL,
RawMaterialCode varchar(5) NOT NULL CONSTRAINT RMCodeUnique UNIQUE,
RawMaterialUnitPrice decimal NOT NULL CONSTRAINT RMPriceNotNegative Check (RawMaterialUnitPrice > 0),
CreationDateTime datetime2,
LastUpdateDateTime datetime2
)

create table Team_D.supplier
(
--Developed by Pushpraj kaushik on 28/09/2019
 supplierID     uniqueidentifier primary key,
 SupplierName   varchar(40) NOT NULL ,
 SupplierMobile   char(10) NOT NULL ,
 SupplierEmail  varchar(50) NOT NULL unique,
 SupplierPassword   varchar(15) NOT NULL ,
 creationDateTime   datetime,
 lastModifiedDateTime datetime
)

create table Team_D.supplierAddress
(
--Developed by Pushpraj kaushik on 28/09/2019
 supplierAddressID uniqueidentifier primary key,
 supplierID uniqueidentifier references Team_D.supplier(supplierID) Not Null,
 AddressLine1   varchar(255) NOT NULL ,
 AddressLine2   varchar(255) NOT NULL ,
 PinCode  char(6) NOT NULL unique,
 City   varchar(50) NOT NULL unique,
 [state] varchar(50) NOT NULL,
)

Create Table Team_D.Rawmaterialorder
 (
 --Developed by Ritwik Sinha on 28/09/2019
 CreationDateTime          Datetime, 
 LastmodifiedDateTime      datetime,
 RawMaterialOrderID        uniqueidentifier     primary key,
 RawMaterialOrderDate      datetime             not null ,
 SupplierID                uniqueidentifier     not null ,
 RawMaterialTotalPrice     decimal            constraint k_RM_price check (RawMaterialTotalPrice > 0),
 RawMaterialTotalQuantity  decimal            constraint k_RM_quantity check (RawMaterialTotalQuantity > 0),	    
 )

 create table Team_D.Rawmaterialorderdetails
 (
 --Developed by Ritwik Sinha on 28/09/2019
 RawMaterialOrderDetailID uniqueidentifier,
 RawMaterialOrderID    uniqueidentifier, 
 foreign key (RawMaterialOrderID) references Team_D.Rawmaterialorder(RawMaterialOrderID), 
 RawMaterialID          uniqueidentifier,
 foreign key (RawMaterialID) references Team_D.RawMaterial(RawMaterialID),
 RawMaterialUnitPrice    decimal,
 RawMaterialQuantity     decimal,
 RawMaterialTotalPrice   decimal
 )

 --creating table for Product
CREATE Table Team_D.Product
(
--Developed by Rohit Kumar on 28/09/2019
ProductID uniqueidentifier CONSTRAINT ProductPK PRIMARY KEY,
ProductName varchar(30) NOT NULL,
ProductCode varchar(5) NOT NULL CONSTRAINT PCodeUnique UNIQUE,
ProductUnitPrice decimal NOT NULL CONSTRAINT PPriceNotNegative Check (ProductUnitPrice > 0),
ProductType varchar(12) NOT NULL CONSTRAINT PTypeIN Check (ProductType in('Mocktail','Soft Drink','Energy Drink','Juice','Tonic Water')),
CreationDateTime datetime2,
LastUpdateDateTime datetime2
)

create table Team_D.Distributor
(
--Developed by Sowrasree Banerjee on 28/09/2019
DistributorID uniqueidentifier constraint Distributor_pk primary key,
DistributorName varchar(40) Not Null unique,
DistributorMobile char(10)  Not Null unique,
DistributorEmail varchar(30) not null unique,
DistributorPassword varchar(15) not null unique,
CreateDateTime dateTime Not Null,
LastModifiedDateTime DateTime not Null,
)

create table Team_D.DistributorAddress
(
--Developed by Sowrasree Banerjee on 28/09/2019
DistributoraddressID uniqueidentifier constraint Distributoraddress_pk primary key,
DistributorID uniqueidentifier references Team_D.Distributor(DistributorID) ,
AddressLine1 varchar(30) not null unique,
AddressLine2 varchar (30),
Pincode char(6),
City varchar(10),
DistributorState varchar(10),
)

create table Team_D.ProductOrders(
--Developed by Sai Jahnavi on 28/09/2019
ProductOrderID   uniqueidentifier primary key,
ProductOrderDate DateTime Not NUll, 
LastModifiedDate DateTime  Not Null,
DistributorID uniqueidentifier, foreign key(DistributorID)  references Team_D.Distributor(DistributorID),
ProductOrderAmount decimal constraint Amount_constraint  check (ProductOrderAmount >0.0),
PaymentStatus bit Not NuLL,
TotalQuantity decimal constraint quantity_constraint check (TotalQuantity>0.0), 
DistributorAddressID uniqueidentifier references Team_D.DistributorAddress(DistributorAddressID) Not Null,
)

create table Team_D.ProductOrderDetails(
--Developed by Sai Jahnavi on 28/09/2019
ProductOrderDetailID  uniqueidentifier primary key,
ProductOrderID uniqueidentifier references Team_D.ProductOrders(ProductOrderID) Not Null,
ProductID uniqueidentifier references Team_D.Product(ProductID) Not Null,
DistributorID uniqueidentifier references Team_D.Distributor(DistributorID) Not Null,
ProductTotalPrice decimal constraint Price_constraint  check (ProductTotalPrice >0.0),
ProductQuantity decimal constraint Prod_quantity_constraint check (ProductQuantity>0.0),
ProductUnitPrice decimal constraint Unit_price_constraint check (ProductUnitPrice>0.0),
)