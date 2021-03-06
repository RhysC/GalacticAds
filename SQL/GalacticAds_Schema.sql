USE [GalacticAds]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 06/13/2010 21:39:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 06/13/2010 21:39:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [nvarchar](255) NULL,
	[Suburb] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[PostCode] [nvarchar](255) NULL,
	[Provence] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[Latitude] [decimal](19, 5) NULL,
	[Longitude] [decimal](19, 5) NULL,
	[Location]  AS ([geography]::STPointFromText(((('Point('+CONVERT([varchar](10),[Longitude],0))+' ')+CONVERT([varchar](10),[Latitude],0))+')',(4326))),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geographical location' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Address', @level2type=N'COLUMN',@level2name=N'Location'
GO
/****** Object:  Table [dbo].[Advertiser]    Script Date: 06/13/2010 21:39:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertiser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[GeographicalLocation] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 06/13/2010 21:39:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[GeographicalLocation] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertiserCategory]    Script Date: 06/13/2010 21:39:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertiserCategory](
	[CategoryId] [int] NOT NULL,
	[AdvertiserId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK81CEEDE4299973A8]    Script Date: 06/13/2010 21:39:42 ******/
ALTER TABLE [dbo].[Advertiser]  WITH CHECK ADD  CONSTRAINT [FK81CEEDE4299973A8] FOREIGN KEY([GeographicalLocation])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Advertiser] CHECK CONSTRAINT [FK81CEEDE4299973A8]
GO
/****** Object:  ForeignKey [FK5FC5F1E3406826CE]    Script Date: 06/13/2010 21:39:42 ******/
ALTER TABLE [dbo].[AdvertiserCategory]  WITH CHECK ADD  CONSTRAINT [FK5FC5F1E3406826CE] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[AdvertiserCategory] CHECK CONSTRAINT [FK5FC5F1E3406826CE]
GO
/****** Object:  ForeignKey [FK5FC5F1E348C8510]    Script Date: 06/13/2010 21:39:42 ******/
ALTER TABLE [dbo].[AdvertiserCategory]  WITH CHECK ADD  CONSTRAINT [FK5FC5F1E348C8510] FOREIGN KEY([AdvertiserId])
REFERENCES [dbo].[Advertiser] ([Id])
GO
ALTER TABLE [dbo].[AdvertiserCategory] CHECK CONSTRAINT [FK5FC5F1E348C8510]
GO
/****** Object:  ForeignKey [FK5C0EC3F7299973A8]    Script Date: 06/13/2010 21:39:42 ******/
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK5C0EC3F7299973A8] FOREIGN KEY([GeographicalLocation])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK5C0EC3F7299973A8]
GO
