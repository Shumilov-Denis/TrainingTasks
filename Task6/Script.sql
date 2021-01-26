USE [Task6]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 26.01.2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Groups] [int] NOT NULL,
	[Session] [int] NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 26.01.2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Student] [int] NOT NULL,
	[Exams] [int] NOT NULL,
	[Grade] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 26.01.2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 26.01.2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateFinish] [date] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 26.01.2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[DateBirth] [date] NOT NULL,
	[Gender] [nvarchar](15) NOT NULL,
	[StudentGroup] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Groups] FOREIGN KEY([Groups])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Groups]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Sessions] FOREIGN KEY([Session])
REFERENCES [dbo].[Sessions] ([id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Sessions]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Exams] FOREIGN KEY([Exams])
REFERENCES [dbo].[Exams] ([id])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Exams]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Students] FOREIGN KEY([Student])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([StudentGroup])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
