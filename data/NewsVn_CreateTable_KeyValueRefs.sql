USE [NewsVn]
GO

/****** Object:  Table [dbo].[KeyValueRefs]    Script Date: 08/16/2011 01:34:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KeyValueRefs]') AND type in (N'U'))
DROP TABLE [dbo].[KeyValueRefs]
GO

USE [NewsVn]
GO

/****** Object:  Table [dbo].[KeyValueRefs]    Script Date: 08/16/2011 01:34:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KeyValueRefs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](200) NOT NULL,
	[Key] [varchar](200) NOT NULL,
	[Value] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_KeyValueRefs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


