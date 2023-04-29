USE [AVVNL_CALL_CENTER]
GO

/****** Object:  Table [dbo].[CallAbandonAndWaiting]    Script Date: 29-04-2023 23:55:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CallAbandonAndWaiting](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total_Calls_Offered] [bigint] NULL,
	[Total_Calls_Answered] [bigint] NULL,
	[Calls_Answered_within_60_Sec] [bigint] NULL,
	[Calls_Answered_After_60_Sec] [bigint] NULL,
	[Percent_Calls_Attended_within_60_Second] Decimal(18,2) NULL,
	[Percent_Calls_Attended_After_60_Second] Decimal(18,2) NULL,
	[Calls_Abandon] [bigint] NULL,
	[Call_Abandon_Percentage] Decimal(18,2) NULL,
	[Calls_Abandon_within_60_Sec] [bigint] NULL,
	[Total_Call_Wait_Time] [bigint] NULL,
	[Call_Wait_Time_more_than_60_Sec] [bigint] NULL,
	Is_Active bit null,
	Is_Deleted bit null,
	Time_Stamp datetime null,
 CONSTRAINT [PK_CallAbandonAndWaiting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


