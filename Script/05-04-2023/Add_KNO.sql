CREATE PROCEDURE [dbo].[Add_KNO](
	@USER_ID int=0,
	@KNO bigint=0,
	@retStatus   INT OUTPUT
	)
AS
BEGIN
	DECLARE @count BIGINT
	SELECT @count=COUNT(*) FROM MST_KNO WHERE KNO = @KNO

	IF @count = 0
    BEGIN
        INSERT INTO MST_KNO(USER_ID,KNO,IS_ACTIVE,IS_DELETED,TIME_STAMP) VALUES (@USER_ID, @KNO,1,0,GETDATE())
		set @retStatus=1
    END
	else
		set @retStatus=0
END
