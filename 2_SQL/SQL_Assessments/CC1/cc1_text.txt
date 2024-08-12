use Assignments

select * from tblEMP

update tblEMP
set hiredate = '2023-07-16' where empno=7369

update tblEMP
set hiredate = '1981-07-16' where empno=7499

-- 1.	Write a query to display your birthday( day of week)
select datename(dw,'2001-02-03') as birth_day

-- 2.	Write a query to display your age in days
select datediff(dd,'2001-02-03',GETDATE()) as age_in_days

-- 3.	Write a query to display all employees information those who joined before 5 years in the current month
select ename as 'names of employees',hiredate from tblEMP
where datediff(YY, HIREDATE, GETDATE()) >= 5 and month(HIREDATE) = month(GETDATE())

-- 4.	Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction
	-- a. First insert 3 rows 
	-- b. Update the second row sal with 15% increment  
    -- c. Delete first row. After completing above all actions how to recall the deleted row without losing increment of second row.
select * from tblEMP

begin tran
-- a. First insert 3 rows 
save tran t1
insert into tblemp values
(8001,'aadi',' associate',7839,'2024-05-28',30000,NULL,10),
(8002,'kesava','software',7839,'2024-05-29',28000,NULL,10),
(8003,'naidu','engineer',7839,'2024-05-31',28500,NULL,10)

select * from tblEMP where empno in (8001,8002,8003)
-- b. Update the second row sal with 15% increment
save tran t2
update tblEMP
set sal=sal*1.15
where empno=8002

-- c. Delete first row.
save tran t3
delete from tblemp
where empno = 8001
select * from tblEMP where empno in (8001,8002,8003)

rollback tran t1
select * from tblEMP where empno in (8001,8002,8003)
select
-- After completing above all actions how to recall the deleted row without losing increment of second row.
rollback
rollback tran t1

commit

--------------------------------------------------------------------------------------------------------------------------------
-- 5. Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions
	-- a.     For Deptno 10 employees 15% of sal as bonus.
	-- b.     For Deptno 20 employees  20% of sal as bonus
	-- c      For Others employees 5%of sal as bonus

select * from tblEMP
 -- 5th query
create or alter  function fnCalculateBonus (@deptno int, @sal float)
returns float
as
begin
    declare @bonus float
    if @deptno = 10
        set @bonus = @sal * 0.15
    else if @deptno = 20
        set @bonus = @sal * 0.20
    else
        set @bonus = @sal * 0.05
	return @bonus
end


SELECT deptno,dbo.fnCalculateBonus(10, sal) AS Bonus
FROM tblEMP




