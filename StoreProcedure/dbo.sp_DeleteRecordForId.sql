CREATE   PROCEDURE [dbo].[sp_DeleteRecordForId]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @row_count INTEGER
    -- Insert statements for procedure here
	DELETE from  Employee where ID=@Id;
	SELECT @row_count = @@ROWCOUNT
	return  @row_count

END