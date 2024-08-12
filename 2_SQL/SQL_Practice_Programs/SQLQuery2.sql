use InfiniteTrainingdb

select * from tblemployees

select * from tblDepartment

------------------------ Joins ----------------------------------------------

select td.deptname, td.loc, te.empname,te.salary from tblDepartment td, tblemployees te
where td.DeptNo = te.DeptNo

select td.deptname, td.loc, te.empname,te.salary from tblDepartment td inner join tblemployees te
on td.DeptNo = te.DeptNo

-- left non matching + matching
select td.deptname, td.loc, te.empname,te.salary from tblDepartment td left outer join tblemployees te
on td.DeptNo = te.DeptNo



-------------------- Sub Queries ---------------

select empname, salary from tblemployees
where salary > (select salary from tblemployees where Empname like 'Vaishnavi')