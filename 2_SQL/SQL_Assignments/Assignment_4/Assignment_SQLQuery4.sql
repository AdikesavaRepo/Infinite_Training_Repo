USE InfiniteTrainingdb

-----------------------------------
-- 1.	Write a T-SQL Program to find the factorial of a given number.

create or alter proc sp_factorial @num int
as
begin
	declare @fact int=1
	declare @i int =1
	while @i<=@num
	begin
		set @fact=@fact*@i
		set @i=@i+1
	end
end
select @fact as 'factorial of given number is'
print 'factorial of number '+cast(@num as varchar(10)) +' '+'is '+cast(@fact as varchar(10))

sp_factorial 4



-- 2.	Create a stored procedure to generate multiplication tables up to a given number.
create or alter proc sp_multiply_tables
@num int
as
begin
	declare @i int = 1
	while @i<=@num
	begin
		declare @j int = 1
		while @j<=10
		begin
			print cast(@i as varchar(10))+'*'+cast(@j as varchar(10))+' '+'='+cast(@i*@j as varchar(10))
			set @j=@j+1
		end
		print '-------------------'
		set @i=@i+1
	end
end
sp_multiply_tables 5
---------------------------------

create or alter proc sp_multiply_table_upto
@num1 int,@num2 int
as
begin
	declare @i int = 1
	while @i<=@num2
	begin
		print cast(@num1 as varchar(10))+'*'+cast(@i as varchar(10))+' '+'='+cast(@num1*@i as varchar(10))
		set @i=@i+1
	end
end

sp_multiply_table_upto 5,6
--------------------------------------



-- 3.  Create a trigger to restrict data manipulation on EMP table during General holidays. 
--     Display the error message like �Due to Independence day you cannot manipulate data� or "Due To Diwali", you cannot manipulate" etc

create table tblholidays
(
holiday_date DATE PRIMARY KEY,
holiday_name VARCHAR(100)
)

insert into tblholidays values
('2024-07-18', 'Independence Day is Today(18-Thursday)'),
('2024-10-12', 'Dusshera'),
('2024-07-19','Diwali is today(19-Friday)'),
('2025-01-01','New year')

select * from tblholidays
select * from tblemployees


----

create or alter trigger trg_no_modification_emp_holiday
on tblemployees
instead of insert,update,delete
as
begin
	declare @holiday int
    select @holiday = count(*) from tblholidays where holiday_date = cast(getdate() as date)
    if @holiday>0
    begin
		declare @h_name varchar(100);
		select @h_name = holiday_name from tblholidays where holiday_date = cast(getdate() as date)
		select 'you cannot modify data because of ' + cast(@h_name as varchar(200))
	end
end
update tblemployees
set salary=100000 where empid=101