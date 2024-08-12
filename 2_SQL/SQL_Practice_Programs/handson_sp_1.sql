USE InfiniteTrainingdb

select * from tblemployees

select e1.Empid, e1.empname from tblemployees e1
where salary > (select avg(salary) from tblemployees e2 where e2.DeptNo = e1.DeptNo)
/*
101	 Abishek Lomte	 Male   	6300	3	2345677
102	 Adikeshava	     Male   	6500	1	3333221
103  Anitha Gayathri Female 	6400	2	2222211
105	 Bindu	         Female 	6300	2	432125
106	 Aman Ullah	     Male   	6400	4	73522380
107	 Ayesha	         Female 	6400	4	768522380
110	 Shreyash	     Male   	6620	5	768989
113	 Kajal	         Female 	6600	4	56272211
114	 Vijendra	     Male   	6620	4	9892765
115	 Naman	         Male   	6555	5	967879
120	 vaishnavi	     Female 	6550	5	988765
*/

begin
declare @newsal int
select @newsal = Salary from tblemployees
where empid = 103
print 'salary of emp 103 is' +' ' + cast(@newsal as varchar(10))
update tblemployees
SET Salary = Salary + 100
WHERE Salary < @newsal
select * from tblemployees
end


-- procedure with parameter
create or alter proc sp_updatesal(@eid int, @sal float)
as
begin
 declare @revisedsalary float
 declare @ename varchar(10)
 select @ename = empname from tblemployees where empid = @eid
 if(@sal <=6300)
   begin
   set @revisedsalary = @sal+100
   print 'salary for' + @ename + 'from' + cast(@sal as varchar(19)) + 'to' + cast(@revisedsalary as varchar(19))
   end
end

sp_updatesal 103,6100

----------------------------------------------------------------------------------------------
create or alter proc sp_updatesal(@eid int)
as
begin
declare @sal float
declare @ename varchar(10)
declare @revisedsalary float
select @ename = empname from tblemployees where empid = @eid
select @sal = salary from tblemployees where empid = @eid
if(@sal <=6300)
   begin
   set @revisedsalary = @sal+100
   print 'Previos salary for ' + @ename + 'is ' + cast(@sal as varchar(19)) + ' updated salary is ' + cast(@revisedsalary as varchar(19))
   end
end
 
sp_updatesal 101


----------------------------------------------------------------------------------------------------

create or alter proc sp_updatesal(@eid int)
as
begin
 declare @sal float
 declare @ename varchar(10)
 declare @revisedsalary float

 select @ename = empname from tblemployees where empid = @eid
 select @sal = salary from tblemployees where empid = @eid

 if(@sal <=7000)
   begin
   set @revisedsalary = @sal+100
   update tblemployees
   set Salary = @revisedsalary
   --select * from tblemployees where Empid=@eid
   select Empname,Salary as 'Previos salary',@ename as 'emp name',@revisedsalary as 'updated salary' from tblemployees where empid = @eid

   print 'Previos salary for ' + @ename + 'is '+ cast(@sal as varchar(19)) + ' updated salary is ' + cast(@revisedsalary as varchar(19))
   end
end

sp_updatesal 101


select * from tblemployees where Empid=101


-----------------------------------------------------------------------------------------------------------
create or alter proc sp_newupdatesal(@eid int)
as
begin
 declare @sal float
 declare @ename varchar(10)
 declare @revisedsalary float

 select @ename = empname from tblemployees where empid = @eid
 select @sal = salary from tblemployees where empid = @eid

 if(@sal <=6500)
   begin
   select @ename,@sal from tblemployees where @eid = Empid
   print 'Previos salary for ' + @ename + 'is '+ cast(@sal as varchar(19))
   set @revisedsalary = @sal+100
   --update tblemployees
   --set @sal = @revisedsalary
   select @ename,@revisedsalary from tblemployees where @eid = Empid
   print ' updated salary is ' + cast(@revisedsalary as varchar(19))
   end
end

sp_updatesal 101

---------------------------------------------------------------------------------------

create or alter proc sp_updatesal(@eid int)
as
begin
declare @sal float
declare @ename varchar(10)
declare @revisedsalary float
select @ename = empname from tblemployees where empid = @eid
select @sal = salary from tblemployees where empid = @eid
if(@sal <=6300)
   begin
   set @revisedsalary = @sal+100
   print 'Previos salary for ' + @ename + 'is ' + cast(@sal as varchar(19)) + ' updated salary is ' + cast(@revisedsalary as varchar(19))
  select @ename,@sal from tblemployees where empid=@eid
  update tblemployees
   set Salary=@revisedsalary
   end
end

  select empname,Salary from tblemployees where empid=101
sp_updatesal 101

