USE [B2BProductCatalog]
GO

/****** Object:  Table [dbo].[FlagInfo]    Script Date: 03/03/2011 13:12:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FlagInfo_Backup](
	[pkId] [int] IDENTITY(1,1) NOT NULL,
	[FlagId] [varchar](15) NULL,
	[FlagName] [varchar](50) NOT NULL,
	[FlagNameFr] [varchar](75) NULL,
	[FlagDescription] [varchar](4000) NULL,
	[FlagDescriptionFr] [varchar](4000) NULL,
	[Category] [varchar](50) NOT NULL,
	[FileName] [varchar](50) NULL,
	[SalesOrg] [varchar](4) NOT NULL,
	[DistributionChannel] [varchar](2) NOT NULL,
	[Sequence] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[Locale] [nchar](2) NULL,
 CONSTRAINT [PK_FlagInfo_Backup] PRIMARY KEY CLUSTERED 
(
	[pkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


