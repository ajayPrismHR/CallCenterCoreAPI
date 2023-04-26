USE [AVVNL_CALL_CENTER]
GO
/****** Object:  StoredProcedure [dbo].[PUSH_SMS_DETAIL]    Script Date: 25-04-2023 17:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SONAL>
-- Create date: <02-03-2023>
-- Description:	<INSERT SMS DETAIL>
-- =============================================
create PROCEDURE [dbo].[UPDATE_SMS_DETAIL]
	@id bigint,
	@DELIVERY_RESPONSE NVARCHAR(500)
AS
BEGIN
	UPDATE SMS_DETAIL SET DELIVERY_RESPONSE=@DELIVERY_RESPONSE WHERE ID=@id
END
