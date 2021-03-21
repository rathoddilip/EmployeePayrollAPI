CREATE PROCEDURE [dbo].[sp_UpdateEmployeeRecord]
(
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name			varchar(255),
	@Gender			varchar(10),
	@Salary			bigint,
	@StartDate		Date
)
AS
begin transaction
begin try
   UPDATE Employee SET Name=@Name where ID=@ID
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