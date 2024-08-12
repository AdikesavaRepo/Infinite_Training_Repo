use Assignments

--ex 2. 
--create a procedure that takes an employee no, and outputs the manager id and the salary of the employee

create or alter proc sp_GetMan_salary @eid int
as
begin
    declare @mid INT
    declare @sal INT
	declare @ename varchar(100)
	select @mid = mgr_id,@sal = sal,@ename = ename from tblEMP WHERE empno = @eid
    if @mid IS NOT NULL
    begin
        print 'Manager ID of the Employee of ID' + cast(@eid AS VARCHAR(10))+' '+@ename+' ' + 'is ' + cast(@mid AS VARCHAR(10))
        print 'Salary for the Employee of ID' + cast(@eid AS VARCHAR(10))+' '+@ename+' ' + 'is ' + cast(@sal AS VARCHAR(10))
    end
    else
    begin
        print 'Employee with ID' + cast(@eid AS VARCHAR(10)) + ' not found/not having manager';
    end
end

 
sp_GetMan_salary 7369


------------------------------------------
--ex 3.
-- create a procedure that takes deptno as input and 
-- ouputs the average salary of that department, and also
-- returns the count of employees in that department



create or alter proc sp_avgsal @dno int, @avgsal float output
as
begin
	declare @sal float
	select @sal = sal from tblEMP
	select @avgsal= avg(sal) from tblEMP where Deptno=@dno
	return (select count(deptno) from tblEMP where Deptno=@dno)
end
declare @empcount int
declare @avg float
exec @empcount = sp_avgsal 10,@avg output
print ' average of salaries is ' + cast(@avg as varchar(100))+' ' +'count of employees is '+ cast(@empcount as varchar(100))