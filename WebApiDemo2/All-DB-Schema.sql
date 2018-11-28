USE [BreffiTestDB]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/28/2018 5:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[ID] [uniqueidentifier] NOT NULL,
	[Descr] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Brand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tool]    Script Date: 11/28/2018 5:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tool](
	[ID] [uniqueidentifier] NOT NULL,
	[Descr] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[BrandID] [uniqueidentifier] NOT NULL,
	[ToolTypeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Tool] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToolType]    Script Date: 11/28/2018 5:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolType](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DescrAppl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ToolType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Tool] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ToolType] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tool_dbo.Brand_BrandID] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_dbo.Tool_dbo.Brand_BrandID]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tool_dbo.ToolType_ToolTypeID] FOREIGN KEY([ToolTypeID])
REFERENCES [dbo].[ToolType] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_dbo.Tool_dbo.ToolType_ToolTypeID]
GO
