USE [IMSWeb]
GO
 
IF OBJECT_ID(N'dbo.Ref_Client_Type', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Client_Type]
END
GO

CREATE TABLE [dbo].[Ref_Client_Type](
	[Cd] [varchar](10) NOT NULL,
	[Description] [varchar](100) NOT NULL,
) ON [PRIMARY]
GO


IF OBJECT_ID(N'dbo.Ref_Mailing_Address', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Mailing_Address]
END
 
CREATE TABLE [dbo].[Ref_Mailing_Address](
	[Cd] [varchar](10) NOT NULL,
	[Description] [varchar](100) NOT NULL,
) ON [PRIMARY]
GO 

IF OBJECT_ID(N'dbo.Ref_Status', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Status]
END
GO

CREATE TABLE [dbo].[Ref_Status](
	[Status] [varchar](10) NOT NULL,
	[StatusDesc] [varchar](100) NOT NULL,
) ON [PRIMARY]
GO
  
IF OBJECT_ID(N'dbo.Ref_Business_Type', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Business_Type]
END
GO

CREATE TABLE [dbo].[Ref_Business_Type](
	[Business_TypeCd] [varchar](10)  NULL,
	[Description] [varchar](100) NULL 
) ON [PRIMARY]
GO

IF OBJECT_ID(N'dbo.Ref_Claim_Status', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Claim_Status]
END
GO 

CREATE TABLE [dbo].[Ref_Claim_Status](
	[Cd] [varchar](10)  NULL,
	[Description] [varchar](100)  NULL 
) ON [PRIMARY]
GO

IF OBJECT_ID(N'dbo.Ref_Currency', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Currency]
END
GO
 
CREATE TABLE [dbo].[Ref_Currency](
	[CurrencyCd] [varchar](10) NULL,
	[CurrencyDesc] [varchar](100)  NULL 
) ON [PRIMARY]
GO

IF OBJECT_ID(N'dbo.Ref_Pay_Type', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Pay_Type]
END

CREATE TABLE [dbo].[Ref_Pay_Type](
	[Cd] [varchar](10) NULL,
	[PayType] [varchar](100) NULL
) ON [PRIMARY]
GO


IF OBJECT_ID(N'dbo.Ref_Premium_Type', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Premium_Type]
END
GO

CREATE TABLE [dbo].[Ref_Premium_Type](
	[Cd] [varchar](10) NULL,
	[PremiumType] [varchar](100) NULL
) ON [PRIMARY]
GO


IF OBJECT_ID(N'dbo.Ref_Payment_Mode', N'U') IS NOT NULL
BEGIN
   Drop Table [dbo].[Ref_Payment_Mode]
END
GO

CREATE TABLE [dbo].[Ref_Payment_Mode](
	[Payment_ModeCd] [varchar](10)  NULL,
	[Description] [varchar](100)  NULL,
	[Seq] [int] NULL,
	[Mult] [int] NULL,
	[ShortDesc] [varchar](10) NULL 
) ON [PRIMARY]
GO
 

INSERT INTO [dbo].[Ref_Status]
           ([Status]
           ,[StatusDesc]
)
select 'CP','Current'
union select 'EX','Expired(Renewed)'
union select 'EXPD','Expired(Pending)'
union select 'EXU','Expired(Unrenewed)'
union select 'PD','Pending'
union select 'ICP','Incusion(Current)'
union select 'IEX','Incusion(Complete)'
union select 'PR','Prospect'
GO

insert into [Ref_Client_Type] (cd, Description)
  select '1','Indv.' 
  union select '2','Corp.'

GO

insert into [Ref_Mailing_Address] (cd, Description)
  select 'H','Home' 
  union select 'O','Office'
GO

INSERT INTO [dbo].[Ref_Claim_Status]
           ([Cd]
           ,[Description]
            )
select 'cd','Description'
union select 'D','Denied'
union select 'F','Fully Settled'
union select 'P','Partially Settled'
union select 'U','Unsettled'
GO

INSERT INTO [dbo].[Ref_Currency]
           ([CurrencyCd]
           ,[CurrencyDesc]
            )
select 'P','PHP'
union select '$','USD'
union select '€','EUR'
Go

INSERT INTO [dbo].[Ref_Pay_Type]
           ([Cd]
           ,[PayType])
select '1','Cash'
union select '2','Check'
union select '3','Card'
union select '4','Tel Transfer'
GO


INSERT INTO [dbo].[Ref_Premium_Type]
           ([Cd]
           ,[PremiumType])
select '1','New'
union select '2','Renewal'
union select '3','Inclusion'
union select '4','Subsequent'
GO

INSERT INTO [dbo].[Ref_Business_Type]
           ([Business_TypeCd]
           ,[Description] )
 select '1','New'
union select '2','Rnw'
union select '0','Prospect'
union select '4','Inclusion'
GO

INSERT INTO [dbo].[Ref_Payment_Mode]
           ([Payment_ModeCd]
           ,[Description]
           ,[Seq]
           ,[Mult]
           ,[ShortDesc] )
select '1','Annually',4,1,'A'
union select '12','Monthly',1,12,'M'
union select '2','Semi-Annually',3,2,'SA'
union select '4','Quarterly',2,4,'Q'	  
GO