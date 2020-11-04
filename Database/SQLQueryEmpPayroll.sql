Select * from sys.databases

CREATE DATABASE payroll_service;

use payroll_service

CREATE TABLE employeePayroll
(
  id int IDENTITY(1,1),
  name varchar(30) not null,
  salary money not null,
  start date not null,
)

SELECT * FROM employeePayroll

iNSERT INTO employeePayroll values
('Bili' , 100000.00, '2018-01-03'),
('Teresa' , 200000.00, '2019-11-13'),
('Charlie' , 300000.00, '2015-01-03')

SELECT * FROM employeePayroll

SELECT * FROM employeePayroll where name='Bili'

SELECT * FROM employeePayroll where start between CAST('2018-01-01' AS DATE) AND CAST('2020-01-01' AS DATE)

alter table employeePayroll add gender char(1) 

update employeePayroll set gender='M' where name='Bili' or name= 'Charlie' 
update employeePayroll set gender='F' where name='Teresa'


SELECT sum(salary) as CombineSalary from employee_payroll where gender='M' group by gender


Alter table employeePayroll add Phone_number varchar(14)
Alter table employeePayroll add Address varchar(50)

Alter table employeePayroll add constraint Default_Address default 'Indian' for Address

Alter table employeePayroll add department varchar(20)
insert into employeePayroll(name, salary,start) values ('nill', 30000, '2018-07-09')

sp_rename 'employeePayroll.salary' , 'basic_pay'

Alter table employeePayroll add
Deduction float,
taxable_pay real,
incometax float,
netpay real;


Select * from sys.databases

CREATE DATABASE payroll_service;

use payroll_service

CREATE TABLE employeePayroll
(
  id int IDENTITY(1,1),
  name varchar(30) not null,
  salary money not null,
  start date not null,
)

SELECT * FROM employeePayroll

iNSERT INTO employeePayroll values
('Bili' , 100000.00, '2018-01-03'),
('Teresa' , 200000.00, '2019-11-13'),
('Charlie' , 300000.00, '2015-01-03')

SELECT * FROM employeePayroll

SELECT * FROM employeePayroll where name='Bili'

SELECT * FROM employeePayroll where start between CAST('2018-01-01' AS DATE) AND CAST('2020-01-01' AS DATE)

alter table employeePayroll add gender char(1) 

update employeePayroll set gender='M' where name='Bili' or name= 'Charlie' 
update employeePayroll set gender='F' where name='Teresa'


SELECT sum(salary) as CombineSalary from employee_payroll where gender='M' group by gender


Alter table employeePayroll add Phone_number varchar(14)
Alter table employeePayroll add Address varchar(50)

Alter table employeePayroll add constraint Default_Address default 'Indian' for Address

Alter table employeePayroll add department varchar(20)
insert into employeePayroll(name, salary,start) values ('nill', 30000, '2018-07-09')

sp_rename 'employeePayroll.salary' , 'basic_pay'

Alter table employeePayroll add
Deduction float,
taxable_pay real,
incometax float,
netpay real;

update employeePayroll set department='designer' where name='nill'
insert into employeePayroll values
('nill', 60000, '2017-10-18','F','9083637299','India','graphic',2300,1900,700,40000)



