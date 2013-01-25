USE [B2BProductCatalog]
GO

/****** Object:  Table [dbo].[ImageData]    Script Date: 05/03/2011 09:35:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ImageData](
	[pkId] [int] IDENTITY(1,1) NOT NULL,
	[StockNumber] [varchar](15) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Url] [varchar](150) NOT NULL,
	[FileName] [varchar](150) NULL,
	[Size] [int] NULL,
	[MediaType] [int] NULL,
	[Locale] [nchar](2) NULL,
 CONSTRAINT [PK_ImageData] PRIMARY KEY CLUSTERED 
(
	[pkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
