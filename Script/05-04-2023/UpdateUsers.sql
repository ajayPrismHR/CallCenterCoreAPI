CREATE PROCEDURE [dbo].[UpdateUsers]
	-- Add the parameters for the stored procedure here
	@User_ID int='',
	@Name varchar(255)='',
	@Address varchar(255)='',
	@Email varchar(255)='',
	@Phone bigint=0,
	@retStatus   INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		update MST_USERS set NAME=@Name, ADDRESS=@Address, EMAIL_ID=@Email, MOBILE_NO=@Phone where USER_ID=@User_ID
		SELECT @retStatus = 1 
END

GO