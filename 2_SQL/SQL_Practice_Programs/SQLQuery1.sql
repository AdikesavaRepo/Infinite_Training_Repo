create database InfiniteTrainingdb

use InfiniteTrainingdb

select * from tblDepartment

select * from tblemployees


create table tblDepartment
(  DeptNo int primary key,        --column level constraint
   DeptName varchar(15) not null,
   Budget float 
)
-- -- ---------- INSERTING DATA -----------------------------------------

--now let us add some data to the 2 tables
insert into tblDepartment values(1,'IT',2000000)

--to insert multiple rows/tuples with single insert into then we give as below
insert into tblDepartment values(2,'HR',null),
(5,'Testing',1000000),(3,'Admin',3000000),(4,'Operations',null)

-- inserting data into table with only selected columns
insert into tblDepartment(DeptNo,DeptName) values(6,'Accounts')

------------------ adding column-------------------------------------------------------------
--add a column to a table with data
alter table tbldepartment
add Loc nvarchar(20) 

--we need to update the column Loc that was added after the table had data in it
update tblDepartment set loc = 'Pune' where deptno=6

update tblDepartment set loc = 'usa' where deptno=1














---------------------------------------------------------------------------------------------------------------------------------
create table tblemployees(
Empid int primary key,
Empname varchar(40) not null,
Gender char(7),
Salary float,
DeptNo int references tbldepartment(DeptNo),  --foreign key 
)

--alter the table to add a column without data
alter table tblemployees
add Phoneno varchar(10) unique   -- constraint while adding a column after table creation



--inserting the default value for city
insert into tblemployees(Empid,Empname,Salary,DeptNo,phoneno) 
values(106,'Aman Ullah', 6300,4,73522380)

update tblemployees set gender ='Male' where empid=106

--inserting other than default value for the city column

insert into tblemployees(Empid,Empname,Salary,DeptNo,phoneno,city) 
values(107,'Ayesha', 6300,4,768522380,'Hyderabad')

update tblemployees set gender ='Female' where empid=107

--------------- inserting data -------------------
-- now let us add some data to the employee table
insert into tblemployees values(103, 'Anitha Gayathri', 'Female',6100,2, 2222211),
(102,'Adikeshava','Male',6200,1,3333221),(105,'Bindu','Female',6200,2,432125),
(101,'Abishek Lomte', 'Male',6000,3,'2345677')

alter table tblemployees
add City varchar(30)

alter table tblemployees
add constraint city_def default 'Bangalore' for City

alter table tblemployees
drop constraint city_def 

--dropping a column from a table after dropping the constaint
alter table tblemployees
drop column City

insert into tblemployees values(113, 'Kajal', 'Female',6500,4, 56272211),
(110,'Shreyash', 'Male',6520,5,768989), (115,'Naman','Male',6455,5,0967879),
(114,'Vijendra','Male',6520,4,09892765),(120,'vaishnavi','Female',6450,5,0988765)

----------------------------------------------------------------------------------------------------------------------------------------

--joining 2 tables and qualifying with thier original names
select tbldepartment.DeptName, sum(salary) as 'Total Salary for Dept' from tblemployees,tblDepartment
where tblDepartment.DeptNo = tblemployees.DeptNo
group by tblDepartment.DeptName
having sum(salary)>13000

--5. dept wise average salary having average salary > 6300
select deptno,avg(salary) as 'Average Salary' from tblemployees
where deptno is not null
group by deptno
having avg(salary)>6300
order by deptno desc

select count(gender) from tblemployees
where gender = 'male'
