
CREATE TABLE [dbo].[Users](
	[User_ID] [varchar](25) NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](25) NULL,
	[Designation] [varchar](50) NULL,
	[Initials] [varchar](10) NULL,
	[Admin] [bit] NULL default 0,
	[UserGroup] [varchar](10) NULL,
	[Created_by] [varchar](25) NULL,
	[Create_date] [datetime] NULL,
	[Updated_by] [varchar](25) NULL,
	[Update_date] [datetime] NULL
) ON [PRIMARY]
GO

