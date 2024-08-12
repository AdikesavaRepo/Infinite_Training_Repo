select * from tblemployees
select * from tbldepartment
select * from tbldummy

--------------- TRIGGERS ------------------------------------------------
create table tbl_emp_audit(msg varchar(max))

alter table tbl_emp_audit
add AuditDate date

--- INSERT ---------------
create or alter trigger trginsert
on tblemployees
for insert
as
	begin
	select * from inserted
	select * from tblEmployees
end

---- DELETE ------------------
create or alter trigger trgdelete
on tblemployees
for delete
as
	begin
	select * from deleted
	select * from tblEmployees
end


-- eg to insert in audit----------------------------

create or alter trigger trgauditinsert
on tblemployees
for insert
as
begin
declare @id int
select @id=empid from inserted

insert into tbl_emp_audit
values('new employee with Empid '+' ' + cast(@id as varchar(5))+' is added at '+' '+cast(getdate() as nvarchar(15)))
end


select * from tbl_emp_audit

-- eg to delete in audit----------------------------

create or alter trigger trgauditdelete
on tblemployees
for delete
as
begin
declare @id int
select @id=empid from deleted

insert into tbl_emp_audit
values('new employee with Empid '+' ' + cast(@id as varchar(5))+' is deleted at '+' '+cast(getdate() as nvarchar(50)))
end

select * from tbl_emp_audit

----------------------------------------------------

create or alter trigger trgauditUpdateEmp
 on tblemployees
 for update
 as
 begin
   --declare few variables to hold old data
   declare @id int
   declare @oldename varchar(35), @newename varchar(35)
   declare @oldsalary float, @newsalary float
   declare @olddeptid int, @newdeptid int
   select * from inserted
   select * from deleted
   --declare a variable to build the audit string
   declare @auditdata varchar(max)
   --store the newly updated data into a temp table ('#') or use the inserted table
   select * into #temtableforupdation from inserted

   --loop thru all the updated records incase we have updated many rows
   while(exists(select empid from #temtableforupdation))
     begin
	  set @auditdata = ' '
	  --let us select the first row of temporary table
	  select top 1 @id=empid,@newename=empname,
	  @newsalary=salary,@newdeptid=deptno from #temtableforupdation

	  --let us select data from deleted table
	  select @oldename=empname, @oldsalary=salary,
	  @olddeptid=deptno from deleted where empid=@id

	  set @auditdata = 'Employee with Id : '+ cast(@id as varchar(5)) + ' changed '
	  --if old data is updated with newdata, we should track it
	  if(@oldename <> @newename)
	   begin
	   set @auditdata = @auditdata + 'the Name from '+ @oldename + ' to '+ @newename
	   end
	   --salary changes verfification
	   if(@oldsalary <> @newsalary)
	    begin
		set @auditdata = @auditdata + ' Salary from ' + cast(@oldsalary as varchar(10)) + 
		' to ' + cast(@newsalary as varchar(10))
		end
		--dept changes verification
		if(@olddeptid <> @newdeptid)
		begin
		set @auditdata = @auditdata + ' Department from  '+ cast(@olddeptid as varchar(5)) +
		' to ' + cast(@newdeptid as varchar(5))
		end

		--now we have the entire audit data
		insert into tbl_emp_audit(msg,auditdate) values(@auditdata,getdate())

		  --now we should delete the top 1st row after recording changes
		  --so that the second row can be the top row
		  delete from #temtableforupdation where empid=@id
	end
end


select * from tblemployees where DeptNo in(1,2)
--one row and many columns updation
update tblemployees set empname='Sumathi',salary=7500,deptno=5 where empid=210

select * from #temtableforupdation
select * from tbl_emp_audit


--------------------------------------------------------
-- Triggers on dept
--------------------------------------
create or alter triguse assignments

--------------------------------------------------------------------------------------------------------



ger trg_dept_no_modifications
on tbldepartment
instead of insert,update,delete
as
begin
  select 'Permission denied--contact admin'
end
----------------------------------------
-- enable or disable triggers
---------------------------------------
select * from tbldummy

insert into tbldummy values (7,'f','m',6000)

create or alter trigger trg_dummy_no_modifications
on tbldummy
instead of insert,update,delete
as
begin
  select 'Permission denied--contact admin'
end

disable TRIGGER trg_dummy_no_modifications on tbldummy

enable TRIGGER trg_dummy_no_modifications on tbldummy

------------------------------------------------------
--Views
----------------------------------------------------
select * from tblemployees where deptno=4

create view vwmyview1
as
select empid,empname,gender,deptno from tblemployees

select * from vwmyview1 where deptno=4

--------------------------------------------------------------
-- DDL TRIGGERS
----------------------------










---------------------------
-- Cursors
-----------------------------
--eg 2
declare @sal float, @ename varchar(30)
declare empcursor cursor
for select Empname,Salary from tblemployees
open empcursor
fetch next from empcursor into @ename,@sal

while @@FETCH_STATUS =0
 begin
  if(@sal >6700)
     begin
	   print @ename  + ' Earns ' + cast(@sal as varchar(10))
	 end
   else
     begin
	   print @ename + ' needs an increment'
	 end
	 fetch next from empcursor into @ename,@sal
	end

close empcursor
deallocate empcursor

---
--3.static cursor prior 5
declare @staticsal float, @staticname varchar(25)

declare empcursor_static cursor static
for select empname,salary from tblemployees
open empcursor_static
fetch relative 5 from empcursor_static into @staticname, @staticsal
while @@FETCH_STATUS = 0
 begin
   if(@staticsal >6700)
     begin
	   print @staticname  + ' Earns ' + cast(@staticsal as varchar(10))
	 end
   else
     begin
	   print @staticname + ' needs an increment'
	 end
  fetch prior from empcursor_static into @staticname, @staticsal
end

close empcursor_static
deallocate empcursor_static

---




