CREATE PROCEDURE [dbo].[sp_AddEmployeeRecord]
	-- Add the parameters for the stored procedure here
	@Name				varchar(255),
	@Gender				varchar(10),
	@Salary				bigint,
	@StartDate			Date,
	@ProfileImage   	varchar(50),
	@Notes				varchar(250),
	@Department1		varchar(50),
	@Department2		varchar(50),
	@Department3		varchar(50)
AS
BEGIN
SET NOCOUNT ON
IF EXISTS (SELECT * FROM [Employee] WHERE Name = @Name)

BEGIN

RAISERROR ('Record Already Exist',

16, -- Severity,

1 -- State,

)

RETURN -1

END

else

Begin
DECLARE @EmployeeId int;
 SET NOCOUNT ON;
   INSERT INTO Employee(Name, Gender, Salary, StartDate,ProfileImage,Notes)
	VALUES(@Name, @Gender, @Salary, @StartDate,@ProfileImage, @Notes); 
SET @EmployeeId = SCOPE_IDENTITY();
INSERT INTO Department(DeptID, Department1,Department2,Department3)
Values(@EmployeeId,@Department1,@Department2,@Department3)

--select Employee.ID,Employee.Name,Employee.Gender,Employee.Salary,Employee.StartDate,Employee.ProfileImage,Employee.Notes, Department.Department1, Department.Department2, Department.Department3 from Employee
--inner join Department 
--on Employee.ID=Department.DeptID;
END
end