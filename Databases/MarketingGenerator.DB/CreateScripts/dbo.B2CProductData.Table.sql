USE [B2BProductCatalog]
GO

/****** Object:  Table [dbo].[B2CProductData]    Script Date: 01/26/2011 09:19:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2CProductData](
	[PkID] [int] IDENTITY(1,1) NOT NULL,
	[StyleNumber] [varchar](18) NOT NULL,
	[ProductName] [nvarchar](200) NULL,
	[BrandName] [nvarchar](200) NULL,
	[ProductDescEn] [nvarchar](4000) NULL,
	[ProductDescFr] [nvarchar](4000) NULL,
 CONSTRAINT [PK_B2CProductData] PRIMARY KEY CLUSTERED 
(
	[PkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [B2BProductCatalog]
/****** Object:  Index [IX_B2CProductData]    Script Date: 01/26/2011 09:19:27 ******/
CREATE NONCLUSTERED INDEX [IX_B2CProductData] ON [dbo].[B2CProductData] 
(
	[StyleNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO