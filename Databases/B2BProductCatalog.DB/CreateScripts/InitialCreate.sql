USE [B2BProductData]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](30) NOT NULL,
	[B2CBrandName] [varchar](30) NOT NULL,
	[Password] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (1, N'Bates', N'Bates', N'pass1')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (2, N'Cat Footwear', N'Cat Footwear', N'pass2')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (3, N'Chaco', N'Chaco', N'pass3')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (4, N'Cushe', N'Cushe', N'pass4')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (5, N'Harley-Davidson Footwear', N'Harley-Davidson', N'pass5')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (6, N'Hush Puppies', N'Hush Puppies', N'pass6')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (7, N'Hytest', N'Hytest', N'pass7')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (8, N'Merrell', N'Merrell', N'pass8')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (9, N'Merrell Apparel', N'Merrell Apparel', N'pass9')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (10, N'Patagonia Footwear', N'Patagonia', N'pass10')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (11, N'Sebago', N'Sebago', N'pass11')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (12, N'Sebago Apparel', N'Sebago Apparel', N'pass12')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (13, N'Wolverine Apparel', N'Wolverine Apparel', N'pass13')
INSERT [dbo].[Brand] ([Id], [BrandName], [B2CBrandName], [Password]) VALUES (14, N'Wolverine Footwear', N'Wolverine', N'pass14')
SET IDENTITY_INSERT [dbo].[Brand] OFF
/****** Object:  Table [dbo].[Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[DisplayName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Locale] ON
INSERT [dbo].[Locale] ([Id], [Name], [DisplayName]) VALUES (1, N'en-us', N'English (USA)')
INSERT [dbo].[Locale] ([Id], [Name], [DisplayName]) VALUES (2, N'fr-ca', N'French (Canada)')
SET IDENTITY_INSERT [dbo].[Locale] OFF
/****** Object:  Table [dbo].[PatternInfoType]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatternInfoType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PatternInfoType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[ApplicationName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](128) NOT NULL,
	[Comment] [nvarchar](255) NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordQuestion] [nvarchar](255) NULL,
	[PasswordAnswer] [nvarchar](255) NULL,
	[IsApproved] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[IsOnLine] [bit] NULL,
	[IsLockedOut] [bit] NULL,
	[LastLockedOutDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NULL,
	[FailedPasswordAnswerAttemptCount] [int] NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NULL,
	[PrevLoginDate] [datetime] NULL,
 CONSTRAINT [PK__Users__1788CCAC778AC167] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlagCategory]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FlagCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_FlagCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[SalesOrg] [varchar](4) NOT NULL,
	[DistChan] [varchar](2) NOT NULL,
 CONSTRAINT [PK_Brand_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Brand_Locale] ON
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (1, 1, 1, N'1000', N'09')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (2, 1, 2, N'4100', N'45')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (3, 2, 1, N'1000', N'10')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (4, 2, 2, N'4100', N'43')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (5, 3, 1, N'3000', N'38')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (6, 3, 2, N'4100', N'48')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (7, 4, 1, N'1000', N'18')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (8, 4, 2, N'4100', N'47')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (9, 5, 1, N'1000', N'15')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (10, 5, 2, N'4100', N'44')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (11, 6, 1, N'1000', N'02')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (12, 6, 2, N'4100', N'41')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (13, 7, 1, N'1000', N'20')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (14, 8, 1, N'3000', N'30')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (15, 8, 2, N'4100', N'31')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (16, 9, 1, N'3000', N'AA')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (17, 9, 2, N'4100', N'AB')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (18, 10, 1, N'3000', N'85')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (19, 10, 2, N'4100', N'87')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (20, 11, 1, N'1700', N'80')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (21, 11, 2, N'4100', N'46')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (22, 12, 1, N'1700', N'AG')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (23, 12, 2, N'4100', N'AH')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (24, 13, 1, N'1000', N'AD')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (25, 13, 2, N'4100', N'AE')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (26, 14, 1, N'1000', N'06')
INSERT [dbo].[Brand_Locale] ([Id], [BrandId], [LocaleId], [SalesOrg], [DistChan]) VALUES (27, 14, 2, N'4100', N'42')
SET IDENTITY_INSERT [dbo].[Brand_Locale] OFF
/****** Object:  Table [dbo].[Pattern]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pattern](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Pattern] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FlagInfo]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FlagInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[FlagCategoryId] [int] NOT NULL,
	[ImagePath] [varchar](50) NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_FlagInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FlagCategory_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FlagCategory_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlagCategoryId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FlagCategory_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Style]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Style](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatternId] [int] NOT NULL,
	[StyleNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Style] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatternInfoType_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatternInfoType_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[Type] [varchar](30) NOT NULL,
 CONSTRAINT [PK_PatternInfoType_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatternInfo]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatternInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PatternInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pattern_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pattern_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatternId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](4000) NULL,
	[Gender] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Pattern_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatternInfo_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatternInfo_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatternInfoId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[Text] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_PatternInfo_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FlagInfo_Locale]    Script Date: 03/22/2011 10:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FlagInfo_Locale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlagInfoId] [int] NOT NULL,
	[LocaleId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_FlagInfo_Locale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_PatternInfoType_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfoType]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfoType_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[PatternInfoType] CHECK CONSTRAINT [FK_PatternInfoType_Brand]
GO
/****** Object:  ForeignKey [FK_Users_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Brand]
GO
/****** Object:  ForeignKey [FK_FlagCategory_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagCategory]  WITH CHECK ADD  CONSTRAINT [FK_FlagCategory_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[FlagCategory] CHECK CONSTRAINT [FK_FlagCategory_Brand]
GO
/****** Object:  ForeignKey [FK_Brand_Locale_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Brand_Locale]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Locale_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Brand_Locale] CHECK CONSTRAINT [FK_Brand_Locale_Brand]
GO
/****** Object:  ForeignKey [FK_Brand_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Brand_Locale]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[Brand_Locale] CHECK CONSTRAINT [FK_Brand_Locale_Locale]
GO
/****** Object:  ForeignKey [FK_Pattern_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Pattern]  WITH CHECK ADD  CONSTRAINT [FK_Pattern_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Pattern] CHECK CONSTRAINT [FK_Pattern_Brand]
GO
/****** Object:  ForeignKey [FK_FlagInfo_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagInfo]  WITH CHECK ADD  CONSTRAINT [FK_FlagInfo_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[FlagInfo] CHECK CONSTRAINT [FK_FlagInfo_Brand]
GO
/****** Object:  ForeignKey [FK_FlagInfo_FlagCategory]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagInfo]  WITH CHECK ADD  CONSTRAINT [FK_FlagInfo_FlagCategory] FOREIGN KEY([FlagCategoryId])
REFERENCES [dbo].[FlagCategory] ([Id])
GO
ALTER TABLE [dbo].[FlagInfo] CHECK CONSTRAINT [FK_FlagInfo_FlagCategory]
GO
/****** Object:  ForeignKey [FK_FlagCategory_Locale_FlagCategory]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagCategory_Locale]  WITH CHECK ADD  CONSTRAINT [FK_FlagCategory_Locale_FlagCategory] FOREIGN KEY([FlagCategoryId])
REFERENCES [dbo].[FlagCategory] ([Id])
GO
ALTER TABLE [dbo].[FlagCategory_Locale] CHECK CONSTRAINT [FK_FlagCategory_Locale_FlagCategory]
GO
/****** Object:  ForeignKey [FK_FlagCategory_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagCategory_Locale]  WITH CHECK ADD  CONSTRAINT [FK_FlagCategory_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[FlagCategory_Locale] CHECK CONSTRAINT [FK_FlagCategory_Locale_Locale]
GO
/****** Object:  ForeignKey [FK_Style_Pattern]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Style]  WITH CHECK ADD  CONSTRAINT [FK_Style_Pattern] FOREIGN KEY([PatternId])
REFERENCES [dbo].[Pattern] ([Id])
GO
ALTER TABLE [dbo].[Style] CHECK CONSTRAINT [FK_Style_Pattern]
GO
/****** Object:  ForeignKey [FK_PatternInfoType_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfoType_Locale]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfoType_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[PatternInfoType_Locale] CHECK CONSTRAINT [FK_PatternInfoType_Locale_Locale]
GO
/****** Object:  ForeignKey [FK_PatternInfoType_Locale_PatternInfoType]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfoType_Locale]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfoType_Locale_PatternInfoType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[PatternInfoType] ([Id])
GO
ALTER TABLE [dbo].[PatternInfoType_Locale] CHECK CONSTRAINT [FK_PatternInfoType_Locale_PatternInfoType]
GO
/****** Object:  ForeignKey [FK_PatternInfo_Brand]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfo]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfo_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[PatternInfo] CHECK CONSTRAINT [FK_PatternInfo_Brand]
GO
/****** Object:  ForeignKey [FK_PatternInfo_PatternInfoType]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfo]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfo_PatternInfoType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[PatternInfoType] ([Id])
GO
ALTER TABLE [dbo].[PatternInfo] CHECK CONSTRAINT [FK_PatternInfo_PatternInfoType]
GO
/****** Object:  ForeignKey [FK_Pattern_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Pattern_Locale]  WITH CHECK ADD  CONSTRAINT [FK_Pattern_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[Pattern_Locale] CHECK CONSTRAINT [FK_Pattern_Locale_Locale]
GO
/****** Object:  ForeignKey [FK_Pattern_Locale_Pattern]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[Pattern_Locale]  WITH CHECK ADD  CONSTRAINT [FK_Pattern_Locale_Pattern] FOREIGN KEY([PatternId])
REFERENCES [dbo].[Pattern] ([Id])
GO
ALTER TABLE [dbo].[Pattern_Locale] CHECK CONSTRAINT [FK_Pattern_Locale_Pattern]
GO
/****** Object:  ForeignKey [FK_PatternInfo_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfo_Locale]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfo_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[PatternInfo_Locale] CHECK CONSTRAINT [FK_PatternInfo_Locale_Locale]
GO
/****** Object:  ForeignKey [FK_PatternInfo_Locale_PatternInfo]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[PatternInfo_Locale]  WITH CHECK ADD  CONSTRAINT [FK_PatternInfo_Locale_PatternInfo] FOREIGN KEY([PatternInfoId])
REFERENCES [dbo].[PatternInfo] ([Id])
GO
ALTER TABLE [dbo].[PatternInfo_Locale] CHECK CONSTRAINT [FK_PatternInfo_Locale_PatternInfo]
GO
/****** Object:  ForeignKey [FK_FlagInfo_Locale_FlagInfo]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagInfo_Locale]  WITH CHECK ADD  CONSTRAINT [FK_FlagInfo_Locale_FlagInfo] FOREIGN KEY([FlagInfoId])
REFERENCES [dbo].[FlagInfo] ([Id])
GO
ALTER TABLE [dbo].[FlagInfo_Locale] CHECK CONSTRAINT [FK_FlagInfo_Locale_FlagInfo]
GO
/****** Object:  ForeignKey [FK_FlagInfo_Locale_Locale]    Script Date: 03/22/2011 10:02:30 ******/
ALTER TABLE [dbo].[FlagInfo_Locale]  WITH CHECK ADD  CONSTRAINT [FK_FlagInfo_Locale_Locale] FOREIGN KEY([LocaleId])
REFERENCES [dbo].[Locale] ([Id])
GO
ALTER TABLE [dbo].[FlagInfo_Locale] CHECK CONSTRAINT [FK_FlagInfo_Locale_Locale]
GO
