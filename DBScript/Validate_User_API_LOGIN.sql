USE [HRMS]
GO
/****** Object:  StoredProcedure [dbo].[Validate_User_API_LOGIN]    Script Date: 18-05-2023 10:01:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Validate_User_API_LOGIN]
	@Username VARCHAR(50) ,
	@Password VARCHAR(50) 
AS
BEGIN
	IF (@Password <> '')
	BEGIN
		IF EXISTS(SELECT 1  from Mst_Employee where Emp_Name = @Username and [Password] = @Password )
			BEGIN 
				SELECT ME.EmpID,ME.Emp_Name,ME.NAME,ME.ROLE_ID,MR.ID,MR.ROLE_NAME,ME.Remember_Me,ME.OFFICE_ID,ME.Latitude,ME.Lognitude,ME.Login_Within_Range,EA.InTime,EA.OutTime,EA.Is_On_Leave
				FROM [dbo].Mst_Employee ME JOIN [dbo].[Mst_Roles] MR ON ME.ROLE_ID=MR.ID
				LEFT OUTER JOIN Emp_Attendance EA ON ME.EmpID=EA.Emp_ID AND CONVERT(DATE,EA.Attendance_Date)=CONVERT(DATE,GETDATE())
				WHERE ME.Emp_Name=@Username AND ME.IS_ACTIVE=1

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
