use infinitetrainingdb

create or alter function fncountbygender()
returns int
as
begin
	return (select count(*) from tblemployees where gender='male')
end

select dbo.fncountbygender() as 'total male emps'

--------------------------------------
create or alter function fnsum(@n1 int,@n2 int)
returns int
as
begin
	return @n1+@n2
end

select dbo.fnadd(3,5) as 'total sum'

----------------------------------------------------

select * from tblemployees

create index idxname on tblemployees(empname)

create unique nonclustered index idxsal on tblemployees(salary)
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.tblemployees' and the index name 'idxsal'. The duplicate key value is (6900).

create index idx_salary on tblemployees(salary) where salary>1600

select salary from tblemployees where salary>1600
sp_help tblemployees
-----------------------------------
update tblemployees
set salary =5000 where empid = 104

-------- Transactions

begin transaction
insert into tblemployees values(190,'againnew','female',6599,2,123458)
select * from tblemployees

delete from tblemployees where empid=120
select * from tblemployees

update tblDepartment set budget=60000 where DeptNo=4
select * from tblDepartment

rollback

commit

-------------------------------------------------------------------------
create table tbldummy
(dumid nvarchar, dumname nvarchar,dumgend nvarchar,dumsal float)

select * from tbldummy

insert into tbldummy values
(1,'a','m',1000),
(2,'b','f',2000),
(3,'c','m',3000),
(4,'d','m',5000),
(5,'e','f',4000)
---------------------------------------------------------------------------------

select dumname from tbldummy where dumsal not like 2000

select dumname from tbldummy where dumsal <> 2000

select dumname from tbldummy where dumsal != 2000


begin tran


update tbldummy
set dumsal=9999 where dumid=1
save tran t1
rollback tran t1


insert into tbldummy values (8,'e','f',7000)

save tran t2

rollback tran t1


commit

--------------------------------------------------------------------------------------------

--procedure with exception handling,transactions,tsql and few dml operations
 create table tblProducts
 (ProductId int primary key,
 Productname varchar(30) not null,
 Price int,
 QuantityAvailable int)

 --let us populate data into products

 insert into tblProducts values(101,'Laptops',55000,100),
 (102,'Desktops',35000,50),(103,'Tablets',60000,45),(104,'SmartPhones',45000,25)


 --product sales table
 create table tblProductSales 
 (SaleId int primary key,
 ProductId int references tblProducts(ProductId),
 QuantitySold int)

 select * from tblProducts
 select * from tblProductSales

 select max(saleid) from tblProductSales

 --------------------------------------------------------------
 create or alter proc sp_Sales
 @pid int, @qty_to_sell int
 as
 begin
  --first we need to check if there is enough stock available to sell
  declare @stockavailable int
  select @stockavailable = Quantityavailable from tblProducts where ProductId = @pid
  --we need to throw an error if the stock i sless than the qty to sell
  if(@stockavailable < @qty_to_sell)
    begin
	  raiserror('Not Enough Stock on hand to sell',16,1)
	end
  else
    begin -- we shall start a transaction
	begin tran
	-- we need to update the qty available in products table and also insert one rsale record
	-- in productsales table
	update Products
	set QuantityAvailable = (QuantityAvailable - @qty_to_sell)
	where ProductId = @pid

	-- now let us insert one row into productsales
	-- inorder not to have pk violetion, we should not hard code ant data for sale id
	--we can write a logic that autogenerates the saleid, by finding the max saleid
	declare @maxsaleid int
	select @maxsaleid = case
	   when max(SaleId) is null then 0
	   else max(SaleId)
	   end
	   from ProductSales
	   -- we will increment the @maxsaleid by 1, to avoid Pk violation
	    set @maxsaleid = @maxsaleid + 1

	   insert into ProductSales values(@maxsaleid, @pid, @qty_to_sell)
	   --@@Error , a global variable will have 0 if no errors
	   if(@@Error <> 0)
	    begin
		  rollback transaction
		  Print 'something went wrong.. try later, rolling back'
        end
	   else
	    begin
		  commit transaction
		  Print 'Transaction Successfull'
		end
  end
end

--let us execute the above proc
Sales 101,10

-----------------------------------------------------
create or alter proc sales
@pid int,@qty_to_sell int

as
begin
	declare @stockavailable int
	select @stockavailable=quantityavailable from tblProducts where ProductId=@pid
	if(@stockavailable<@qty_to_sell)
		begin
			raiserror('we have no stock',15,1)
		end
	else
		begin tran
		update tblproducts
		set QuantityAvailable=QuantityAvailable-@qty_to_sell where ProductId=@pid

		insert into tblProductSales(@pid,@qty_to_sell)

-------------------------------------------------------

create ao alter trigger trgupemp
on tblemployees
for update
as
begin
seelct * from deleted
select * from inserted
