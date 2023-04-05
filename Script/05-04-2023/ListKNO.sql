CREATE PROCEDURE [dbo].[ListKNO] 
	-- Add the parameters for the stored procedure here
	@USER_ID int=0
AS
BEGIN
	select * from MST_KNO where USER_ID=@USER_ID
END

GO