USE [IMSWeb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[Client_id] [varchar](50) NOT NULL,
	[Last_Name] [varchar](100) NULL,
	[First_Name] [varchar](100) NULL,
	[Middle_Name] [varchar](100) NULL,
	[Nickname] [varchar](100) NULL,
	[Client_Type] [varchar](10) NULL,
	[Title] [varchar](25) NULL,
	[Date_of_Birth] [datetime] NULL,
	[Office_Name] [varchar](100) NULL,
	[Office_Building] [varchar](100) NULL,
	[Office_Street] [varchar](200) NULL,
	[Office_Village] [varchar](200) NULL,
	[Office_City] [varchar](100) NULL,
	[Office_Zip] [varchar](25) NULL,
	[Home_Street] [varchar](200) NULL,
	[Home_Village] [varchar](200) NULL,
	[Home_City] [varchar](100) NULL,
	[Home_Zip] [varchar](75) NULL,
	[Mailing_Address] [varchar](10) NULL,
	[ContactNo] [varchar](500) NULL,
	[Referred_By] [varchar](100) NULL,
	[Created_by] [varchar](25) NULL,
	[Create_date] [datetime] NULL,
	[Updated_by] [varchar](25) NULL,
	[Update_date] [datetime] NULL,
	[ToSync] [bit] NULL,
	[old_id] [int] NULL,
	[Suffix] [varchar](100) NULL,
	[Policy_Id] [varchar](50) NULL,
	[Gender] [varchar](1) NULL,
	[Civil_Status] [varchar](20) NULL,
	[Account] [varchar](100) NULL,
	[Contact_Of] [varchar](100) NULL,
	[Notes] [varchar](max) NULL,
	[mobile] [varchar](500) NULL,
	[phone] [varchar](500) NULL,
	[Email] [varchar](500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT ('sys') FOR [Created_by]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT (getdate()) FOR [Create_date]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT (getdate()) FOR [Update_date]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT ((1)) FOR [ToSync]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT ((0)) FOR [old_id]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT ('') FOR [Suffix]
GO

