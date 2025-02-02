use assignments
select * from tblEMP
/*
1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions

Print the payslip neatly with all details
*/


create or alter proc sp_payslip
@eid int
as
begin
	declare @sal float,@ename varchar(10)
	select @sal = sal,@ename = ename from tblEMP where @eid = empno
	declare @HRA float,@DA float,@PF float,@IT float,@Deductions float,@Gross_salary float,@net_salary float
	set @HRA = 0.1*@sal
	set @DA = 0.2*@sal
	set @PF = 0.08*@sal
	set @IT = 0.05*@sal
	set @Deductions = @PF+@IT
	set @Gross_salary = @sal+@HRA+@DA
	set @net_salary = @Gross_salary-@Deductions

	print '---- Payslip of Employee '+cast(@eid as varchar(10)) + ' is generated as below: --------'
	print 'Employee ID = ' + cast(@eid as varchar(10))
	print 'Employee Name = '+cast(@ename as varchar(10))
	print 'Basic salary = '+ cast(@sal as varchar(10))
	print 'HRA = '+cast(@HRA as varchar(10))
	print 'DA = ' + cast(@DA as varchar(10))
	print 'PF Deductions = '+cast(@PF as varchar(10))
	print 'IT Deductions = '+cast(@IT as varchar(10))
	print 'Total Deductions (PF+IT) = '+cast(@Deductions as varchar(10))
	print 'Total Gross salary = '+cast(@Gross_salary as varchar(10))
	print 'Total Net Salary = '+cast(@net_salary as varchar(10))
	print 'Payslip Generated Successfully...'

	select empno as 'Employee id',ename as 'Employee Name',@sal as 'Basic salary',@HRA as 'HRA',@DA as 'DA',@PF as 'PF Deductions',
			@IT as 'IT Deductions',@Deductions as 'Total Deductions',@Gross_salary as 'Total Gross salary',
			@net_salary as 'net salary' from tblEMP where empno=@eid
end

exec sp_payslip 7369




