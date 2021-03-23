
CREATE PROCEDURE [dbo].[sp_GetEmployeePayrollAllData] 

AS BEGIN
--SELECT * FROM Employee;
select Employee.ID,Employee.Name,Employee.Gender,Employee.Salary,Employee.StartDate,Employee.ProfileImage,Employee.Notes, Department.DeptID, Department.Department1, Department.Department2, Department.Department3 from Employee
inner join Department 
on Employee.ID=Department.DeptID;
END;