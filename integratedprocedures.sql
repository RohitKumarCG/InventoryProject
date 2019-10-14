--Integrated stored procedures 
--Developed by Team D on 2/10/19



alter procedure AddRawMaterial(@rawmaterialid varchar(36), @rawmaterialname varchar(30), @rawmaterialcode varchar(5), 
	@rawmaterialprice int)
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to add a raw material into table
begin
	if @rawmaterialname = ''
	throw 50001, 'Raw Material Name cannot be empty', 1
	if exists (Select RawMaterialName from RMA.RawMaterial where RawMaterialName = @rawmaterialname)
	throw 50002, 'Raw Material with same name already exists', 1
	if @rawmaterialcode = ''
	throw 50003, 'Raw Material Code cannot be empty', 1
	if exists (Select RawMaterialCode from RMA.RawMaterial where RawMaterialCode = @rawmaterialcode)
	throw 50004, 'Raw Material with same code already exists', 1
	if @rawmaterialprice <= 0
	throw 50005, 'Raw material Price cannot be less than or equal to zero', 1

	insert into RMA.RawMaterial(RawMaterialID, RawMaterialName, RawMaterialCode, RawMaterialPrice, CreationDateTime, LastUpdateDateTime)
	values(@rawmaterialid, @rawmaterialname, @rawmaterialcode, @rawmaterialprice, sysdatetime(), sysdatetime())
end


alter procedure UpdateRawMaterial(@rawmaterialid varchar(36), @rawmaterialname varchar(30), @rawmaterialcode varchar(5),
	@rawmaterialprice int, @lastmodifieddatetime datetime)
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to update a raw material
begin
	if @rawmaterialname = ''
	throw 50001, 'Raw Material Name cannot be empty', 1
	if exists (Select RawMaterialName from RMA.RawMaterial where RawMaterialName = @rawmaterialname)
	throw 50002, 'Raw Material with same name already exists', 1
	if @rawmaterialcode = ''
	throw 50003, 'Raw Material Code cannot be empty', 1
	if exists (Select RawMaterialCode from RMA.RawMaterial where RawMaterialCode = @rawmaterialcode)
	throw 50004, 'Raw Material with same code already exists', 1
	if @rawmaterialprice <= 0
	throw 50005, 'Raw material Price cannot be less than or equal to zero', 1
	
	if exists (select RawMaterialID from RMA.RawMaterial where RawMaterialID = @rawmaterialid)
		begin
			update RMA.RawMaterial
			set	RawMaterialName = @rawmaterialname,
				RawMaterialCode = @rawmaterialcode,
				RawMaterialPrice = @rawmaterialprice,
				LastUpdateDateTime = sysdatetime()
			where RawMaterialID = @rawmaterialid
		end
	else 
		throw 50003, 'Raw material id does not exists', 1			
end


alter procedure DeleteRawMaterial(@rawmaterialid varchar(36))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to delete a raw material
begin
	if exists (select RawMaterialID from RMA.RawMaterial where RawMaterialID = @rawmaterialid)
		begin
			delete from RMA.RawMaterial
			where RawMaterialID = @rawmaterialid
		end
	else
		throw 50004, 'Raw Material Code does not exists', 1
end


alter procedure GetAllRawMaterials
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to list all the raw materials
begin
	select * from RMA.RawMaterial
end



alter procedure GetRawMaterialByRawMaterialName(@rawmaterialname varchar (40))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search raw material by name
begin
	if exists (select RawMaterialName from RMA.RawMaterial where RawMaterialName = @rawmaterialname)
		begin
			select * from RMA.RawMaterial
			where RawMaterialName = @rawmaterialname
		end
	else
		throw 50004, 'Raw Material Name does not exists', 1
end


alter procedure GetRawMaterialByRawMaterialID(@rawmaterialid varchar (36))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search raw material by id
begin
	if exists (select RawMaterialName from RMA.RawMaterial where RawMaterialID = @rawmaterialid)
		begin
			select * from RMA.RawMaterial
			where RawMaterialID = @rawmaterialid
		end
	else
		throw 50004, 'Raw Material ID does not exists', 1
end


alter procedure GetRawMaterialByRawMaterialCode(@rawmaterialcode varchar (5))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search raw material by code
begin
	if exists (select RawMaterialCode from RMA.RawMaterial where RawMaterialCode = @rawmaterialcode)
		begin
			select * from RMA.RawMaterial
			where RawMaterialCode = @rawmaterialcode
		end
	else
		throw 50004, 'Raw Material Code does not exists', 1
end


alter procedure AddProduct(@productid varchar(36), @producttype varchar(20), @productname varchar(30), @productcode varchar(5), 
	@productprice int)
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to add a product into the table
begin
	if @productname = ''
	throw 50001, 'Product Name cannot be empty', 1
	if exists (Select ProductName from Prod.Product where ProductName = @productname)
	throw 50002, 'Product with same name already exists', 1
	if @productcode = ''
	throw 50003, 'Product Code cannot be empty', 1
	if exists (Select ProductCode from Prod.Product where ProductCode = @productcode)
	throw 50004, 'Product with same code already exists', 1
	if @productprice <= 0
	throw 50005, 'Product Price cannot be less than or equal to zero', 1

	insert into Prod.Product(ProductID,ProductType, ProductName, ProductCode, ProductPrice, CreationDateTime, LastUpdateDateTime)
	values(@productid, @producttype, @productname, @productcode,@productprice, sysdatetime(), sysdatetime())
end


alter procedure UpdateProduct(@productid varchar(36), @productname varchar(30), @productcode varchar(5),
	@productprice int, @lastmodifieddatetime datetime)
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to update a product
begin
	if @productname = ''
	throw 50001, 'Product Name cannot be empty', 1
	if exists (Select RawMaterialName from RMA.RawMaterial where RawMaterialName = @productname)
	throw 50002, 'Product with same name already exists', 1
	if @productcode = ''
	throw 50003, 'Product Code cannot be empty', 1
	if exists (Select RawMaterialCode from RMA.RawMaterial where RawMaterialCode = @productcode)
	throw 50004, 'Product with same code already exists', 1
	if @productprice <= 0
	throw 50005, 'Product Price cannot be less than or equal to zero', 1
	
	if exists (select ProductID from Prod.Product where ProductID = @productid)
		begin
			update Prod.Product
			set	ProductName = @productname,
				ProductCode = @productcode,
				ProductPrice = @productprice,
				LastUpdateDateTime = sysdatetime()
			where ProductID = @productid
		end
	else 
		throw 50003, 'Raw material id does not exists', 1			
end


alter procedure DeleteProduct(@productid varchar(36))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to delete a product
begin
	if exists (select ProductID from Prod.Product where ProductID = @productid)
		begin
			delete from Prod.Product
			where ProductID = @productid
		end
	else
		throw 50004, 'Product Code does not exists', 1
end


alter procedure GetAllProducts
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to list all the products
begin
	select * from Prod.Product
end


alter procedure GetProductByProductID(@productid varchar (36))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search product by ID
begin
	if exists (select ProductID from Prod.Product where ProductID = @productid)
		begin
			select * from Prod.Product
			where ProductID = @productid
		end
	else
		throw 50004, 'Product ID does not exists', 1
end


alter procedure GetProductByProductName(@productname varchar (30))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search product by Name
begin
	if exists (select ProductName from Prod.Product where ProductName = @productname)
		begin
			select * from Prod.Product
			where ProductName = @productname
		end
	else
		throw 50004, 'Product Name does not exists', 1
end


alter procedure GetProductByProductCode(@productcode varchar (5))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search product by Code
begin
	if exists (select ProductCode from Prod.Product where ProductCode = @productcode)
		begin
			select * from Prod.Product
			where ProductCode = @productcode
		end
	else
		throw 50004, 'Product Code does not exists', 1
end


alter procedure GetProductsByProductType(@producttype varchar (12))
as
--Developed by Rohit Kumar on 30/09/2019
--procedure to search product by Code
begin
	if exists (select ProductType from Prod.Product where ProductType = @producttype)
		begin
			select * from Prod.Product
			where ProductType = @producttype
		end
	else
		throw 50004, 'Product Type does not exists', 1
end



select * from RMA.RawMaterial

SOURASREE

create table Prod.Distributor
(DistributorID varchar(20) constraint Distributor_pk primary key,
DistributorName varchar(40) Not Null unique,
DistributorMobile char(10)  Not Null unique,
DistributorEmail varchar(30) not null unique,
DistributorPassword varchar(15) not null unique,
CreateDateTime dateTime Not Null,
LastModifiedDateTime DateTime not Null,
)
go
select* from Prod.DistributorAddress
Go
drop table prod.DistributorAddress
go
create table Prod.DistributorAddress
(DistributoraddressID varchar(20) constraint Distributoraddress_pk primary key,
DistributorID varchar(20) references Prod.Distributor(DistributorID) ,
AddressLine1 varchar(30) not null unique,
AddressLine2 varchar (30),
Pincode char(6),
City varchar(10),
DistributorState varchar(10),
)
go



use Inventory
go

create procedure Prod.AddDistributor
 ( @disId varchar(30),
 @disName varchar(40),
  @disMob char(10),
  @disEmail varchar(30),
  @disPas varchar(15),
  @creationDateTime dateTime,
  @lastModifiedDate dateTime
)
 as 
 --Procedure to add Distributor into the table.
--Developed by Sowrasree Banerjee on 01-10-2019
 begin
		if @disName=''
		throw 50001, 'Distributor name cannot be empty',1
		if @disMob=''
		throw 50002, 'Distributor Mobile cannot be empty',1
		if @disEmail=''
		throw 50003, 'Distributor Email cannot be empty',1
		if @disPas=''
		throw 50003, 'Distributor Password cannot be empty',1

	insert into Prod.Distributor(DistributorID,DistributorName,DistributorMobile,DistributorEmail,DistributorPassword,CreateDateTime,LastModifiedDateTime )
	values (@disId,@disName,@disMob,@disEmail,@disPas,@creationDateTime,@lastModifiedDate)
end

 select *from prod.Distributor
 

 exec  prod.AddDistributor '15','112','9876543298','aastha@gmail.com','Ajay03','21-oct-2019','21-oct-2019'


 insert into Prod.Distributor(DistributorID,DistributorName,DistributorMobile,DistributorEmail,DistributorPassword,CreateDateTime,LastModifiedDateTime )
 values('11','ajay','9876543298','ajay@gmail.com'
 ,'Ajay@03','21-oct-2019','21-oct-2019')

 go
 
 select *from Prod.Distributor
 go
create procedure GetAllDistributors
as
 --Procedure to get all distributors.
--Developed by Sowrasree Banerjee on 01-10-2019 
begin
begin try
select*from prod.Distributor
end try
begin catch
PRINT @@ERROR;
throw 500001 ,'invalid values fetched ',2
return 0
end catch
end 
go

create procedure DeleteDistributor(@distributorID varchar(30))
as
 --Procedure to delete distributor from table.
--Developed by Sowrasree Banerjee on 01-10-2019 
begin
begin try
DELETE FROM prod.Distributor WHERE DistributorID=@distributorID
end try
begin catch
PRINT @@ERROR;
throw 500001,'invalid values fetched',3
return 0
end catch
end
 go
 
 create procedure UpdateDistributor(@disId varchar(30),
 @disName varchar(40),
  @disMob char(10),
  @disEmail varchar(30),
  @disPas varchar(15))
 as
 --Procedure to update distributor in table.
--Developed by Sowrasree Banerjee on 01-10-2019 
 begin
 begin try
 UPDATE prod.Distributor
 SET DistributorName=@disName, DistributorMobile=@disMob,DistributorEmail=@disEmail,DistributorPassword=@disPas
 WHERE DistributorID=@disId
 end try
 begin catch
 Print @@ERROR;
 throw 500001,'invalid values fetched',4
 return 0
 end catch
 end 
 go
 
 create procedure GetDistributorByDistributorID(@disId varchar (30))
 as
  --Procedure to get distributor by distributor ID.
--Developed by Sowrasree Banerjee on 01-10-2019 
 begin 
 begin try
 SELECT * FROM prod.Distributor where DistributorID=@disId
 end try
 begin catch
Print  @@ERROR;
throw 5001,'invalid values fetched',5
return 0
end catch
end 
go

create procedure GetDistributorByDistributorName(@disName varchar(40))
as
 --Procedure to get Distributor by distributor name.
--Developed by Sowrasree Banerjee on 01-10-2019
begin
begin try
select *from prod.Distributor where DistributorName=@disName
end try
begin catch
Print @@ERROR;
throw 5001,'invalid values fetched',6
return 0
end catch
end 
go 
select*from Prod.Distributor
go

 exec  prod.AddDistributor '16','ram','9276543298','ram@gmail.com','ram03','21-oct-2019','21-oct-2019'
 go
 
 exec  prod.AddDistributor '17','sham','9876540298','sham@gmail.com','sham03','21-oct-2019','21-oct-2019'
 go

 exec  prod.AddDistributor '18','vyam','9870540298','vyam@gmail.com','vyam03','21-oct-2019','21-oct-2019'
 go

exec  GetAllDistributors 
exec  DeleteDistributor '15'
go
exec  UpdateDistributor '18','rohit','9707342318','ram@gmail.com','rohan03'
go
exec   GetDistributorByDistributorID '16'
exec  GetDistributorByDistributorName 'vyam'


use Inventory
go

create procedure Prod.AddDistributorAddress
(@disAddId varchar(20),
 @disID varchar(20),
 @addline1 varchar(30),
 @addline2 char(30),
 @pincode varchar(6),
 @city varchar(10),
 @state varchar(10)
)
 as 
 --Procedure to add Distributor into the table.
--Developed by Sowrasree Banerjee on 01-10-2019
 begin
		
		if @addline1=''
		throw 50002, 'Address Line1 cannot be empty',1
		if @addline2=''
		throw 50003, 'Address Line2 cannot be empty',1
		if @pincode=''
		throw 50003, 'Pincode cannot be empty',1
		if @city=''
		throw 50003, 'City cannot be empty',1
		if @state=''
		throw 50003, 'State cannot be empty',1
	
	insert into Prod.DistributorAddress(DistributorID,DistributoraddressID,addressLine1,AddressLine2,Pincode,City,DistributorState )
	values (@disAddId,@disID,@addline1,@addline2,@pincode,@city,@state)
end

	select *from prod.DistributorAddress
	exec  prod.AddDistributorAddress '16','10','hemu nagar','flat 505','494004','mumbai','Maharastra'

 insert into Prod.DistributorAddress(DistributorID,DistributoraddressID,addressLine1,AddressLine2,Pincode,City,DistributorState )
 values('11','ajay','9876543298','ajay@gmail.com'
 ,'Ajay@03','21-oct-2019','21-oct-2019')

 go
 
 select *from Prod.Distributor
 go


create procedure GetAllDistributorAddress
as
 --Procedure to get all distributor Address.
--Developed by Sowrasree Banerjee on 01-10-2019 
begin
begin try
select*from prod.DistributorAddress
end try
begin catch
PRINT @@ERROR;
throw 500001 ,'invalid values fetched ',2
return 0
end catch
end 
go

create procedure DeleteDistributorAddress(@distributoraddID varchar(30))
as
 --Procedure to delete distributor from table.
--Developed by Sowrasree Banerjee on 01-10-2019 
begin
begin try
DELETE FROM prod.DistributorAddress WHERE DistributorAddressID=@distributoraddID
end try
begin catch
PRINT @@ERROR;
throw 500001,'invalid values fetched',3
return 0
end catch
end
 go
 
 create procedure UpdateDistributorAddress(@disAddId varchar(30),
 @AddLine1 varchar(40),
  @AddLine2 char(10),
  @pincode varchar(30),
  @city varchar(10),
  @state varchar(10))
 as
 --Procedure to update distributor address in table.
--Developed by Sowrasree Banerjee on 01-10-2019 
 begin
 begin try
 UPDATE prod.DistributorAddress
 SET AddressLine1=@AddLine1, AddressLine2=@AddLine2,Pincode=@pincode,City=@city,DistributorState=@state
 WHERE DistributorAddressID=@disAddId
 end try
 begin catch
 Print @@ERROR;
 throw 500001,'invalid values fetched',4
 return 0
 end catch
 end 
 go
  
 create procedure GetDistributoraddressByDistributorAddressID(@disAddId varchar (30))
 as
  --Procedure to get distributor Address by distributor Address ID.
--Developed by Sowrasree Banerjee on 01-10-2019 
 begin 
 begin try
 SELECT * FROM prod.DistributorAddress where DistributorAddressID=@disAddId
 end try
 begin catch
Print  @@ERROR;
throw 5001,'invalid values fetched',5
return 0
end catch
end 
go

create procedure GetDistributorAddressByAdressLine1(@disAddLine1 varchar(40))
as
 --Procedure to get Distributor Address by distributor addressLine1.
--Developed by Sowrasree Banerjee on 01-10-2019
begin
begin try
select *from prod.DistributorAddress where AddressLine1=@disAddLine1
end try
begin catch
Print @@ERROR;
throw 5001,'invalid values fetched',6
return 0
end catch
end 
go 
select*from Prod.DistributorAddress
go

 exec  prod.AddDistributorAddress '17','18','ram nagar','flat 5','458996','raipur','mp'
 go
 exec  prod.AddDistributorAddress '18','19','ramu nagar','flat 59','458096','raipur','mp'
 go
 
 

exec  GetAllDistributorAddress
exec  DeleteDistributorAddress '18'
go
exec  UpdateDistributor '19','rohit','flat6','876559','nagpur','cg'
go
exec   GetDistributorAddressByDistributorAddressID '16'
exec  GetDistributorByAddressLine1 'ramu nagar'


--Developed by Ritwik Sinha on 30/09/2019
--procedure to add a raw material order into table
 alter  procedure AddRawmaterialOrder ( @RawMaterialOrderID varchar(30), @RawMaterialOrderDate datetime,@SupplierID varchar(30),
 @RawMaterialTotalPrice decimal, @RawMaterialTotalQuantity  decimal)
 as 
 --Developed by Ritwik on 30/09/2019
 begin
 if isnull(@RawMaterialTotalPrice,0) = 0
   throw 50001, 'raw material total price cannot be 0 ', 1
 if isnull(@RawMaterialTotalQuantity,0) = 0
 throw 50002, 'raw material total quantity cannot be 0', 1
 if @RawMaterialTotalPrice <0
   throw 50003, 'raw material total price cannot be negative ', 1
 if @RawMaterialTotalQuantity <0 
 throw 50004, 'raw material total quantity cannot be negative', 1
 insert into RMAO.Rawmaterialorder(CreationDateTime, LastmodifiedDateTime,RawMaterialOrderID , RawMaterialOrderDate ,SupplierID ,
 RawMaterialTotalPrice , RawMaterialTotalQuantity)
 values ( sysdatetime(), sysdatetime(),@RawMaterialOrderID , @RawMaterialOrderDate,@SupplierID ,
 @RawMaterialTotalPrice, @RawMaterialTotalQuantity)
 end
 select * from  RMAO.Rawmaterialorder
 exec AddRawmaterialOrder '1001','10-oct-2019', '2', 100, 10

--Procedure to get all the RawMaterial orders
go
create procedure GetAllRawMaterialOrder
as 
begin 
	begin try 
	select*from RMAO.RawMaterialOrder
	end try
	begin catch
		PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',2
		return 0
    end catch
end
GO

--Procedure to delete RawMaterial Order
--Developed by Ritwik on 30/09/2019
alter procedure DeleteRawMaterialOrder(@RawMaterialOrderID varchar(40) )
as 
begin
	begin try
		DELETE FROM RMAO.RawMaterialOrder where RawMaterialOrderID=@RawMaterialOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',3
		return 0
    end catch
end
GO
--Procedure to update RawMaterial order
--Developed by Ritwik on 30/09/2019
create procedure UpdateRawMaterialOrder( @RawMaterialOrderID varchar(30), @RawMaterialOrderDate datetime,@SupplierID varchar(30),
 @RawMaterialTotalPrice decimal, @RawMaterialTotalQuantity  decimal)
as
begin
	begin try
		UPDATE RMAO.RawMaterialOrder
		SET RawMaterialTotalPrice=@RawMaterialTotalPrice, RawMaterialTotalQuantity= @RawMaterialTotalQuantity
		WHERE RawMaterialOrderID=@RawMaterialOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',4
		return 0
    end catch
end
GO
--Procedure to get RawMaterial order by rawmaterial OrderID 
--Developed by Ritwik on 30/09/2019
create procedure GetRawMaterialOrderbyRawMaterialOrderID(@RawMaterialOrderID varchar(40))
as 
begin
	begin try
		SELECT* FROM RMAO.RawMaterialOrder where RawMaterialOrderID=@RawMaterialOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
end
GO

--Procedure to get RawMaterial order by rawmaterial Order Date 
--Developed by Ritwik on 30/09/2019
create procedure GetRawMaterialOrdersByOrderDate(@RawMaterialOrderDate datetime)
as 
begin
	begin try
		SELECT * FROM RMAO.RawMaterialOrder where RawMaterialOrderDate=@RawMaterialOrderDate
	end try
	begin catch
	PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
end
GO


 alter  procedure AddRawmaterialOrder ( @RawMaterialOrderID varchar(30), @RawMaterialOrderDate datetime,@SupplierID varchar(30),
 @RawMaterialTotalPrice decimal, @RawMaterialTotalQuantity  decimal)
--procedure to add a raw material order into table
--Developed by Ritwik on 30/09/2019

 as 
 begin
 if isnull(@RawMaterialTotalPrice,0) = 0
   throw 50001, 'raw material total price cannot be 0 ', 1
 if isnull(@RawMaterialTotalQuantity,0) = 0
 throw 50002, 'raw material total quantity cannot be 0', 1
 if @RawMaterialTotalPrice <0
   throw 50003, 'raw material total price cannot be negative ', 1
 if @RawMaterialTotalQuantity <0 
 throw 50004, 'raw material total quantity cannot be negative', 1
 insert into RMAO.Rawmaterialorder(CreationDateTime, LastmodifiedDateTime,RawMaterialOrderID , RawMaterialOrderDate ,SupplierID ,
 RawMaterialTotalPrice , RawMaterialTotalQuantity)
 values ( sysdatetime(), sysdatetime(),@RawMaterialOrderID , @RawMaterialOrderDate,@SupplierID ,
 @RawMaterialTotalPrice, @RawMaterialTotalQuantity)
 end
 select * from  RMAO.Rawmaterialorder
 exec AddRawmaterialOrder '1001','10-oct-2019', '2', 100, 10







create database Inventory
go
use Inventory
go
create schema RMA

drop table supplier
--Created by Pushpraj kaushik on 4/10/19
--created table for supplier
create table RMA.supplier
(
 supplierID     int NOT NULL primary key,
 SupplierName   varchar(40) NOT NULL ,
 SupplierMobile   char(10) NOT NULL ,
 SupplierEmail  varchar(50) NOT NULL unique,
 SupplierPassword   varchar(15) NOT NULL ,
 creationDateTime   datetime,
 lastModifiedDateTime datetime
 
 
)

drop table supplier
select*from RMA.supplier

--Created by Pushpraj kaushik on 4/10/19
--created procedure for adding new supplier

alter procedure AddSupplier(@supID int, @supName varchar(40), @supMob char(10),@supEmail varchar(50) ,@supPass varchar(15))
as 
begin
if @supID IS NULL OR @supID=''
throw 50001,'Invalid SupplierID',1
if exists (select SupplierID from supplier where SupplierID=@supID)
if @supName IS NULL OR @supName=''
throw 50001,'Invalid Supplier name',2
if exists (select SupplierName from supplier where supplierName=@supName)
if @supMob IS NULL OR @supMob=''
throw 50001,'Invalid Mobile number',3
if exists (select supplierMobile from supplier where supplierMobile=@supMob)
if @supEmail IS NULL OR @supEmail=''
throw 50001,'Invalid Supplier Email',4
if exists (select supplierEmail from supplier where supplierEmail=@supEmail)
if @supPass IS NULL OR @supPass=''
throw 50001,'Invalid Supplier password',5

insert into supplier(supplierID,supplierName,supplierMobile,supplierEmail, supplierPassword,creationDateTime,lastmodifiedDateTime)
values (@supID,@supName,@supMob,@supEmail,@supPass,sysdatetime(),sysdatetime())

end

exec AddSupplier 61,'Pushpraj','8871032037','kaushik123@gmail.com',Don@1234
exec AddSupplier 56,'kaushik','8871678037','pushprajk@gmail.com',Sonn@1234
exec AddSupplier 57,'Rohit','8871932037','rohit@gmail.com',DonRohit@14

select*from supplier



--PROCEDURE CREATED
create procedure GetAllSupplier
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting all the suppliers

as 
begin 
	begin try 
	select*from supplier
	end try
	begin catch
		PRINT @@ERROR;
		throw 50001,'Invalid Values Fetched',2
		return 0
    end catch
end
GO
exec GetAllSupplier

--PROCEDURE CREATED
alter procedure DeleteSupplier(@supID int)
as 
--Created by Pushpraj kaushik on 4/10/19
--created procedure for deleting existing supplier
begin
	if exists (select supplierID from RMA.supplier where supplierID=@supID)
	begin
	DELETE FROM supplier where supplierID=@supID
	end
	else
	throw 50001,'Invalid Values Fetched',3
	
end
GO
exec DeleteSupplier 50



alter procedure UpdateSupplier(@supID int, @supName varchar(40), @supMob char(10),@supEmail varchar(50) )
--Created by Pushpraj kaushik on 4/10/19
--created procedure for updating the supplier details
as 
begin
	if @supName = ''
	throw 50003, 'SupplierName cannot be empty', 1
	
	if @supEmail = ''
	throw 50003, 'SupplierEmail cannot be empty', 1
		
	
	if exists (select supplierID from RMA.supplier where supplierID = @supID)
		begin
			update RMA.supplier
			set	supplierName = @supname,
				supplierID = @supID,
				supplierEmail = @supEmail,
				supplierMobile= @supMob
			where supplierID = @supID
		end
	else 
		throw 50003, 'supplier id does not exists', 1			
end

GO
exec UpdateSupplier 61,'kaushikji1','8871008037','pushprajk1@gmail.com'
select * from supplier
--PROCEDURE CREATED

alter procedure GetSupplierbySupplierID(@supID int)
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting supplier by supplier ID
as
begin
if exists (select supplierID from RMA.supplier where supplierID = @supID)
		begin
			select* from RMA.supplier
			where supplierID = @supID
		end
	else 
		throw 50003, 'supplier id does not exists', 1			
end
GO
exec GetSupplierbySupplierID 55
--PROCEDURE CREATED

alter procedure GetSupplierbySupplierName( @supName varchar(40))
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting all the suppliers by their name
as
begin
if exists (select supplierName from RMA.supplier where supplierName = @supName)
		begin
			select* from RMA.supplier
			where supplierName = @supName
		end
	else 
		throw 50003, 'supplier name does not exists', 1			
end
GO

exec GetSupplierbySupplierName 'kaushikji'
--PROCEDURE CREATED


alter procedure GetSupplierbyEmail(@supEmail varchar(50))
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting the supplier by email
as
begin
if exists (select supplierEmail from RMA.supplier where supplierEmail = @supEmail)
		begin
			select* from RMA.supplier
			where supplierEmail = @supEmail
		end
	else 
		throw 50003, 'supplier Email does not exists', 1			
end
GO

exec GetSupplierbyEmail 'pushprajk1@gmail.com'
--PROCEDURE CREATED
alter procedure GetSupplierbySupplierEmailandPass(@supEmail varchar(50) ,@supPass varchar(15))
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting the supplier by email and password
as
begin
if exists (select supplierEmail,supplierPassword from supplier where supplierEmail = @supEmail and supplierPassword = @supPass)
		begin
			SELECT* FROM RMA.supplier where supplierEmail=@supEmail and supplierPassword=@supPass

		end
	else 
		throw 50003, 'supplier Email and password does not exists', 1			
end
GO
select*from supplier
exec GetSupplierbySupplierEmailandPass 'pushprajk@gmail.com','@SonAyush123'

-- PROCEDURE CREATED
alter procedure UpdateSupplierPass(@supID int, @supName varchar(40),@supPass varchar(15))
--Created by Pushpraj kaushik on 4/10/19
--created procedure for updating the supplier by password 
as
begin
		if exists (select supplierID from RMA.supplier where supplierID = @supID)
		begin
			update supplier
			set	supplierName = @supname,
				supplierID = @supID,
				supplierPassword = @supPass
			where supplierID = @supID
		end
	else 
		throw 50003, 'supplier id does not exists', 1			
end

GO
exec UpdateSupplierPass 56,'kaushikji','@SonAyush1234'
select*from supplier
drop table supplierAddress
create table RMA.supplierAddress
( 
   SupplierAddressID int primary key NOT NULL, 
   SupplierID int  NOT NULL,
   AddressLine1 varchar(255) NOT NULL,
   AddressLine2 varchar(255) NOT NULL,
   PinCode char(6) NOT NULL,
   City  varchar (20) NOT NULL,         
   State varchar(20) NOT NULL
)

select*from RMA.supplierAddress
create procedure AddSupplierAddress(@supAdID int, @supID int, @AdLine1 char(255),@AdLine2 varchar(255) ,@pcode varchar(15),@city varchar(20),@State varchar(20) )
--Created by Pushpraj kaushik on 4/10/19
--created procedure for adding the supplier address 
as 
begin
if @supAdID IS NULL OR @supAdID=''
throw 50001,'Invalid Supplier addressID',1
if @supID IS NULL OR @supID=''
throw 50001,'Invalid Supplier ID',2
if @AdLine1 IS NULL OR @AdLine1=''
throw 50001,'Invalid Adress line1',3
if @AdLine2 IS NULL OR @AdLine2=''
throw 50001,'Invalid Address line2',4
if @pcode IS NULL OR @pcode=''
throw 50001,'Invalid PinCode',5
if @city IS NULL OR @city=''
throw 50001,'Invalid City name',6
if @State IS NULL OR @State=''
throw 50001,'Invalid State name',7


insert into supplierAddress(SupplierAddressID,SupplierID,AddressLine1,AddressLine2,PinCode,City,State )
values (@supAdID,@supID,@AdLine1,@AdLine2,@pcode,@city,@State)
end

exec AddSupplierAddress 157,56,'B-002,sector9','Airoli Circle','400708','Mumbai','CG' 
select * from supplierAddress
--PROCEDURE CREATED
create procedure GetAllSupplierAddress
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting all the supplier address
as 
begin 
select*from RMA.supplierAddress
end
GO
exec GetAllSupplierAddress
alter procedure UpdateSupplierAddress(@supAdID int,@supID int,@AdLine1 varchar(255),@AdLine2 varchar(255),@pcode char(6),@city varchar(20),@state varchar(20))
--Created by Pushpraj kaushik on 4/10/19
--created procedure for updating the supplier address
as
begin
    if @supAdID =''
	throw 50003, 'Supplier Address ID cannot be empty', 1
	if @supID =''
	throw 50003, 'SupplierID cannot be empty', 1
	if @AdLine1 IS NULL OR @AdLine1=''
	throw 50001,'Invalid Adress line1',3
	if @AdLine2 IS NULL OR @AdLine2=''
	throw 50001,'Invalid Address line2',4
	if @pcode IS NULL OR @pcode=''
	throw 50001,'Invalid PinCode',5
	if @city IS NULL OR @city=''
	throw 50001,'Invalid City name',6
	if @State IS NULL OR @State=''
	throw 50001,'Invalid State name',7

	
	if exists (select supplierAddressID from supplierAddress where supplierAddressID = @supAdID)
		begin
			update RMA.supplierAddress
			set	SupplierID=@supID, AddressLine1=@AdLine1,AddressLine2=@AdLine2,PinCode=@pcode,City=@city,State=@state
			where supplierAddressID = @supAdID
		end
	else 
		throw 50003, 'supplier address id does not exists', 1			
end

GO
 
exec UpdateSupplierAddress 155,56,'B-001,sector15','Airoli Square','476890','Thane','MH'
select*from Supplieraddress
--PROCEDURE CREATED
alter procedure DeleteSupplierAddress(@supAdID int)
--Created by Pushpraj kaushik on 4/10/19
--created procedure for deleting the supplier address
as 
begin
	if exists (select supplierAddressID from RMA.supplierAddress where supplierAddressID=@supAdID)
	begin
	DELETE FROM RMA.supplierAddress where supplierAddressID=@supAdID
	end
	else
	throw 50001,'Invalid Values Fetched',3
end
GO


exec DeleteSupplierAddress 154
select*from supplierAddress

alter procedure GetSupplierAddressbySupplierAddressID(@supAdID int)
--Created by Pushpraj kaushik on 4/10/19
--created procedure for getting the supplier address by suppplier address ID
as 
begin
	if exists (select supplierAddressID from RMA.supplierAddress where supplierAddressID=@supAdID)
	begin
	SELECT * FROM RMA.supplierAddress where supplierAddressID=@supAdID
	end
	else
	throw 50001,'Invalid Values Fetched',3
end
GO
exec GetSupplierAddressbySupplierAddressID 157

--Developed by Maski Saijahnavi
--creation date : 01/10/2019


alter procedure AddProductOrder(@ProductOrderID varchar(40),@DistributorID varchar(40), @ProductOrderAmount decimal,@paymentStatus bit , @TotalQuantity decimal, @distributorAddressID varchar(40) )
--Procedure to add all the product orders
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
if @ProductOrderID IS NULL OR @ProductOrderID =''
throw 500001,'Invalid ProductOrderID',1
if @DistributorID IS NULL OR @DistributorID=''
throw 500001,'Invalid Distributor ID',2
if @ProductOrderAmount<=0
throw 500001,'Product Order amount should be greater than or equal to zero',3
if @paymentStatus IS NULL
throw 500001,'Payment status should not be null',4
if @TotalQuantity<=0 
throw 500001,'Total quantity should be greater than or equal to zero',5
if @distributorAddressID IS NULL OR @distributorAddressID =''
throw 500001,'Invalid ProductOrderID',1

insert into Prod.ProductOrders(ProductOrderID, ProductOrderDate,LastModifiedDate,DistributorID,ProductOrderAmount,PaymentStatus,TotalQuantity ,DistributorAddressID)
values (@ProductOrderID,GetDate(),GetDate(),@DistributorID,@ProductOrderAmount,@paymentStatus,@TotalQuantity,@distributorAddressID)
end
--PROCEDURE CREATED


go
create procedure GetAllProductOrders
--Procedure to get all the product orders
--Developed by Maski Saijahnavi on 01/10/19
as 
begin 
	begin try 
	select*from Prod.ProductOrders
	end try
	begin catch
		PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',2
		return 0
    end catch
end
GO

create procedure DeleteProductOrder(@ProductOrderID varchar(40) )
--Procedure to delete Product Order
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		DELETE FROM Prod.ProductOrders where ProductOrderID=@ProductOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',3
		return 0
    end catch
end
GO

alter procedure UpdateProductOrder(@ProductOrderID varchar(40),@ProductOrderAmount decimal, @PaymentStatus bit,@TotalQuantity decimal ,@DistributorAddressID varchar(15))
--Procedure to update product order
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		UPDATE Prod.ProductOrders
		SET ProductOrderAmount=@ProductOrderAmount,PaymentStatus =@PaymentStatus, TotalQuantity= @TotalQuantity,DistributorAddressID = @DistributorAddressID
		WHERE ProductOrderID=@ProductOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',4
		return 0
    end catch
end
GO

create procedure GetProductOrderbyProductOrderID(@ProductOrderID varchar(40))
--Procedure to get order by OrderID
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		SELECT* FROM Prod.ProductOrders where ProductOrderID=@ProductOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
end
GO

create procedure GetProductOrdersByOrderDate(@ProductOrderDate datetime)
--Procedure to get Product Orders by Date
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		SELECT * FROM Prod.ProductOrders where ProductOrderDate=@ProductOrderDate
	end try
	begin catch
	PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
end
GO

select * from Prod.DistributorAddress
insert into  Prod.DistributorAddress values('123222','kalyandurg','Ananta','Anantapur','AndhraPradesh','515761','12345')
insert into Prod.Distributors values('12345','sairam', '9494416698','sai@gmail.com','Sai@1998',GetDate(),GetDate())
exec AddProductOrder '1234568', '12345',20.9, 0, 30,'123222'
exec AddProductOrder '', '12345',20.9, 0, 30,'123222'

select * from Prod.ProductOrders
exec UpdateProductOrder '1234568',32,1,39,'123222'

--procedure to add product order details
--Developed by Maski Saijahnavi on 01/10/19
create procedure AddProductOrderDetails(@ProductOrderDetailID varchar(40),@ProductOrderID varchar(40), @ProductID varchar(40),@DistributorID varchar(40) , @ProductTotalPrice decimal,@ProductQuantity decimal, @ProductUnitPrice decimal)
as 
begin
if @ProductOrderDetailID IS NULL OR @ProductOrderDetailID =''
throw 500001,'Invalid ProductOrderDetailID',1
if @ProductOrderID IS NULL OR @ProductOrderID =''
throw 500001,'Invalid ProductOrderID',1
if @DistributorID IS NULL OR @DistributorID=''
throw 500001,'Invalid Distributor ID',2
if @ProductTotalPrice<=0
throw 500001,'Product Total Price should be greater than or equal to zero',3
if @ProductQuantity <=0
throw 500001,'Product Quantity should be greater than or equal to zero',4
if @ProductUnitPrice<=0 
throw 500001,'ProductUnitPrice should be greater than or equal to zero',5
if @ProductID IS NULL OR @distributorAddressID =''
throw 500001,'Invalid ProductID',1

insert into Prod.ProductOrderDetails(ProductOrderDetailID, ProductOrderID,ProductID,DistributorID,ProductTotalPrice,ProductQuantity,ProductUnitPrice)
values (@ProductOrderDetailID,@ProductOrderID,@ProductID,@DistributorID,@ProductTotalPrice,@ProductQuantity,@ProductUnitPrice)
end
--PROCEDURE CREATED


go
create procedure GetAllProductOrderDetails
--Procedure to get all the product order details
--Developed by Maski Saijahnavi on 01/10/19
as 
begin 
	begin try 
	select*from Prod.ProductOrderDetails
	end try
	begin catch
		PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',2
		return 0
    end catch
end
GO

create procedure DeleteProductOrder(@ProductOrderDetailID varchar(40) )
--Procedure to delete Product Order detail
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		DELETE FROM Prod.ProductOrderDetails where ProductOrderDetailID=@ProductOrderDetailID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',3
		return 0
    end catch
end
GO

alter procedure UpdateProductOrderDetail(@ProductOrderID varchar(40),@ProductOrderAmount decimal, @PaymentStatus bit,@TotalQuantity decimal ,@DistributorAddressID varchar(15))
--Procedure to update product order detail
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		UPDATE Prod.ProductOrders
		SET ProductOrderAmount=@ProductOrderAmount,PaymentStatus =@PaymentStatus, TotalQuantity= @TotalQuantity,DistributorAddressID = @DistributorAddressID
		WHERE ProductOrderID=@ProductOrderID
	end try
	begin catch
	PRINT @@ERROR;
		throw 500001,'Invalid Values Fetched',4
		return 0
    end catch
end
GO

create procedure GetProductOrderDetailbyProductOrderDetailID(@ProductOrderDetailID varchar(40))
--procudure to get order detail by order detail ID
--Developed by Maski Saijahnavi on 01/10/19
as 
begin
	begin try
		SELECT* FROM Prod.ProductOrderDetails where ProductOrderDetailID=@ProductOrderDetailID
	end try
	begin catch
	PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
end
GO





exec GetProductByProductID '1002'
exec GetProductByProductName 'MangoJuice'
exec GetProductByProductCode 'MJ'
exec GetProductsByProductType 'Juice'
exec GetAllProducts
exec UpdateProduct '1001','FruitJuice','FJ',20,'12-Oct-2019'

select * from Prod.Product
exec AddProduct '1002', 'Juice','MangoJuice', 'MJ', 20
exec AddProduct '1001', 'Juice','FruitJuice', 'FJ', 25

exec DeleteProduct '1002'

exec GetAllRawMaterials

exec GetRawMaterialByRawMaterialName 'Mango'

exec GetRawMaterialByRawMaterialID '1101'

exec GetRawMaterialByRawMaterialCode 'BA'

exec AddRawMaterial '1104','Bananaa','BAA',20

exec UpdateRawMaterial '1102', 'Banana', 'BA', 20, '12-Oct-2019'

exec DeleteRawMaterial '1103'





   





