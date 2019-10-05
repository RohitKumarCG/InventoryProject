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

select * from RMA.RawMaterial