CREATE PROCEDURE [dbo].[sp_AddEmployeeRecord]
	-- Add the parameters for the stored procedure here
	@Name			varchar(255),
	@Gender			varchar(10),
	@Salary			bigint,
	@StartDate		Date
AS
begin transaction
begin try
   INSERT INTO Employee(Name, Gender, Salary,StartDate)
	VALUES(@Name, @Gender, @Salary, @StartDate );
end try
begin catch
   SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage;
   while(@@trancount > 0)
   begin
      rollback transaction
   end
end catch
if (@@trancount <> 0)
begin
   commit transaction;
end

