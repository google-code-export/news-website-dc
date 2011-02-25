USE [ts_stwaco_app]
GO

/****** Object:  Table [dbo].[Albums]    Script Date: 02/25/2011 14:55:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Albums]') AND type in (N'U'))
DROP TABLE [dbo].[Albums]
GO

USE [ts_stwaco_app]
GO

/****** Object:  Table [dbo].[Albums]    Script Date: 02/25/2011 14:55:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Albums](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Avatar] [varchar](200) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Photos] [ntext] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

