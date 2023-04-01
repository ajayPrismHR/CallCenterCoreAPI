USE [CALL_CENTER_NEW]
GO
/****** Object:  StoredProcedure [dbo].[Validate_User]    Script Date: 01-04-2023 14:10:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[Validate_User] 
CREATE PROCEDURE [dbo].[Validate_User_API]
	@Username VARCHAR(50) ,
	@Password VARCHAR(50) 
AS
BEGIN
		IF (@Password <> '')
			BEGIN
					IF EXISTS(SELECT 1  from [MST_USERS_API] where [USER_NAME] = @Username and [Password] = @Password )
						BEGIN 
							SELECT MU.ID,MU.USER_NAME
							FROM [dbo].[Mst_Users_API] MU
							WHERE MU.USER_NAME=@Username 

							SELECT 1 as retStatus
						END
					ELSE
						BEGIN
							SELECT -1 as retStatus
						END
			END
		ELSE
			BEGIN
				SELECT -2 as retStatus
			END
END










