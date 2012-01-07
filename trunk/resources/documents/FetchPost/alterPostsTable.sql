USE [NewsVn]
GO

/****** Object:  Table [dbo].[FetchLinks]    Script Date: 01/07/2012 19:12:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE Posts
ADD AutoFetch BIT NOT NULL DEFAULT 0

GO

ALTER TABLE Posts
ADD AutoFetchUrl VARCHAR(500) NULL