use EmployeePayrollAPIDB

create table Employee(
ID int not null identity(1,1) primary key,
Name varchar(150) not null,
Gender varchar(10) not null,
Salary bigint not null,
StartDate date not null,
);
select * from Employee

insert into Employee(Name, Gender, Salary,StartDate)values
 ('Pradip', 'M',15000,'2021-03-21' );
insert into Employee(Name, Gender, Salary,StartDate)values 
('Sandip', 'M',120000,'2021-01-08' ),
 ('Sayali', 'F',155000,'2020-11-22' ), 
 ('Priyanka', 'F',110000,'2010-04-04'),
 ('Ranjit', 'M',90000,'2020-05-25' );

 create table Department(
DeptID int not null identity(1000,1) primary key,
DeptName varchar(150) not null);

insert into Department(DeptName)values
('IT'),
('Computer');
delete from Department where DeptID=1001
drop table Department;
select * from Department
select Employee.Name,Employee.Salary,Department.DeptName from Employee
inner join Department 
on Employee.ID=Department.DeptID;
select Employee.Name,Employee.Salary, Department.DeptName from Department
right join Employee
ON Employee.ID=Department.DeptID

insert into Department(DeptName)values
('Mech');
select * from Employee
