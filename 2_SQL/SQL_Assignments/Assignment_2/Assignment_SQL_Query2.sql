use Assignments

create table tblDEPT
(
	deptno int, -- Primary Key
	dname varchar(30),
	loc varchar(30)
)

insert into tblDEPT values
(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON')

select * from tblDEPT

alter TABLE tblDEPT
ALTER COLUMN deptno INT NOT NULL;
ADD CONSTRAINT PK_deptno PRIMARY KEY (deptno)
------------------------------------------------------------------------------------------------------------

create table tblEMP
(
	empno int, -- Primary key , not null
	ename varchar(30),
	job varchar (30),
	mgr_id int,
	hiredate DATE,
	sal float,
	comm int,
	Deptno int --- Foreign Key
)

insert into tblEMP values
(7369, 'SMITH', 'CLERK', 7902,'1980-12-17' , 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)


alter TABLE tblEMP
ALTER COLUMN empno INT NOT NULL;

alter table tblEMP
ADD CONSTRAINT PK_empno PRIMARY KEY (empno)

ALTER TABLE tblEMP
ADD CONSTRAINT FK_Emp_Deptno FOREIGN KEY (deptno) REFERENCES tblDEPT(deptno)

select * from tblEMP


------------------------------- Queries ---------------------------------------------------------------------------------

----- 1. List all employees whose name begins with 'A'. 
select * from tblEMP
where ename like 'A%'

----- 2. Select all those employees who don't have a manager. 
select ename,mgr_id from tblEMP
where mgr_id is null

----- 3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select ename,empno,sal from tblEMP where sal between 1200 and 1400

----- 4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.
select t2.ename,t2.sal,t1.dname from tblEMP t2 join tblDEPT t1 on t2.Deptno=t1.deptno
where t1.dname='RESEARCH'
update tblEMP
set sal=sal*1.1
where Deptno=(select deptno from tblDEPT where dname='RESEARCH')
select t2.ename,t2.sal as 'Rised salary',t1.dname from tblEMP t2 join tblDEPT t1 on t2.Deptno=t1.deptno
where t1.dname='RESEARCH'

------ 5. Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) as 'Employed CLERKS' from tblEMP
where job='CLERK'

----- 6. Find the average salary for each job type and the number of people employed in each job.
select job,avg(sal) as 'average salary',count(*) as 'number of employees' from tblEMP
group by job

----- 7. List the employees with the lowest and highest salary.
select t1.ename,t1.sal as 'lowest salary',t2.ename,t2.sal as 'highest salary'
from tblEMP t1 ,tblEMP t2
where
t1.sal in (select min(sal) from tblEMP t1)
and
t2.sal in (select max(sal) from tblEMP t2)

----- 8. List full details of departments that don't have any employees. 
select * from tblDEPT 
where deptno not in (select Deptno from tblEMP)

------ 9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select ename,sal from tblEMP
where job = 'ANALYST' and Deptno=20 and sal>1200
order by ename

------ 10. For each department, list its name and number together with the total salary paid to employees in that department. 
select t1.deptno,t1.dname,sum(t2.sal) as 'total salary' from tblEMP t2,tblDEPT t1 where t1.Deptno=t2.deptno
group by t1.dname,t1.deptno

------ 11. Find out salary of both MILLER and SMITH.
--select t1.ename,t1.sal,t2.ename,t2.sal from tblEMP t1,tblEMP t2
--where t1.ename = 'MILLER' and t2.ename='SMITH'
--or
select ename,sal from tblEMP where ename in('MILLER','SMITH')

------ 12. Find out the names of the employees whose name begin with �A� or �M�.
select ename from tblEMP where ename like 'A%' or ename like 'M%'

------ 13. Compute yearly salary of SMITH.
select ename,(sal*12) as 'yearly salary' from tblEMP where ename = 'SMITH'

-------14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename,sal from tblEMP where sal not between 1500 and 2850
--or
--select ename,sal from tblEMP where sal<1500 or sal>2850

------- 15. Find all managers who have more than 2 employees reporting to them
select t1.ename,count(*) as 'no. of employees reporting' from tblEMP t1 join tblEMP t2
on t1.empno = t2.mgr_id
group by t1.ename
having count(*)>2

----------------------------------------------------------------------------------------------------------------------------------