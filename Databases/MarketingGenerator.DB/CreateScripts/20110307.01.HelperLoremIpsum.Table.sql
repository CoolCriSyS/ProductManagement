USE [B2BProductCatalog]
GO

/****** Object:  Table [dbo].[HelperLoremIpsum]    Script Date: 03/07/2011 10:29:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HelperLoremIpsum](
	[PkID] [int] IDENTITY(1,1) NOT NULL,
	[MarketingFakeEn] [nvarchar](3000) NULL,
	[MarketingFakeFr] [nvarchar](3000) NULL,
 CONSTRAINT [PK_HelperLoremIpsum] PRIMARY KEY CLUSTERED 
(
	[PkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO