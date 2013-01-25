USE [B2BProductCatalog]
GO

/****** Object:  Table [dbo].[FlagCategory]    Script Date: 03/07/2011 09:42:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FlagCategory_Exceptions](
	[pkId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[CategoryId] [varchar](15) NOT NULL,
	[Sequence] [int] NOT NULL,
	[SalesOrg] [varchar](4) NOT NULL,
	[DistributionChannel] [varchar](2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[Locale] [nchar](2) NULL,
 CONSTRAINT [PK_FlagCategory_Exceptions] PRIMARY KEY CLUSTERED 
(
	[pkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


