USE [TestDB]
GO

/****** Object:  Table [dbo].[customers]    Script Date: 20/4/2015 обнГ 10:18:15 ******/
DROP TABLE [dbo].[customers]
GO

/****** Object:  Table [dbo].[customers]    Script Date: 20/4/2015 обнГ 10:18:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[customers](
	[CustID] UNIQUEIDENTIFIER,
	[FirstName] [NVARCHAR](100) NOT NULL,
	[LastName] [NVARCHAR](100) NOT NULL,
	Mobile NVARCHAR(100) NULL,
	[PhoneNum] [NVARCHAR](100) NULL,
	[DoB] [DATE] NULL,
	[Email] [NVARCHAR](100) NULL,
	[cust_address] [NVARCHAR](50) NULL,
	[cust_city] [NVARCHAR](50) NULL,
	[cust_state] [NVARCHAR](50) NULL,
	[cust_zip] [NVARCHAR](50) NULL,
	[cust_country] [NVARCHAR](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


