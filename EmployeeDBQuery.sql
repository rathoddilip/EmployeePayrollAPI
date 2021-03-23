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
 alter table Employee add 
 ProfileImage varchar(50),
 Notes varchar(250);


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
drop table Department;

CREATE TABLE Department (
    DeptID int NOT NULL,
	DeptName varchar(50),
	FOREIGN KEY (DeptID) REFERENCES Employee(ID)	
);
select * from Department;
update  Department set DeptName='IT'  where DeptID=3003 or DeptID=1003
insert into Department(DeptName,DeptID)values('IP',1005);

insert into Department(DeptID)select ID from Employee;
alter table Department add 
 Department2 varchar(50),
 Department3 varchar(50);

insert into Department(DeptName)values
('Mech',1002),
('IP',1003);
delete from Department where DeptID=1003
select * from Employee

EXEC sp_rename 'Department.DeptName', 'Department1','column'; 
select * from Department
select Employee.ID,Employee.Name,Employee.Salary,Employee.StartDate,Employee.ProfileImage,Employee.Notes, Department.DeptID, Department.Department1, Department.Department2, Department.Department3 from Employee
inner join Department 
on Employee.ID=Department.DeptID;

select * from Employee

DECLARE @EmployeeId int;
   INSERT INTO Employee(Name, Gender, Salary, StartDate,ProfileImage,Notes)
	VALUES('Ganesh', 'M', 20000, '2020-02-02','jpg', 'hello'); 
SET @EmployeeId = SCOPE_IDENTITY();
select @EmployeeId;
select * from Employee

delete from Employee where ID=4009