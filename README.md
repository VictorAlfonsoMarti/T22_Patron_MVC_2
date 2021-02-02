DATABASE USADA:




USE [T22_Patron_MVC_2]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 02/02/2021 20:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NULL,
	[apelido] [nvarchar](255) NULL,
	[direccion] [nvarchar](255) NULL,
	[dni] [int] NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[videos]    Script Date: 02/02/2021 20:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[director] [nvarchar](255) NULL,
	[cli_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id], [nombre], [apelido], [direccion], [dni], [fecha]) VALUES (1, N'victor', N'alfonso', N'1', 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[cliente] ([id], [nombre], [apelido], [direccion], [dni], [fecha]) VALUES (2, N'a', N'a', N'a', 2, CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [apelido]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [direccion]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [dni]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [fecha]
GO
ALTER TABLE [dbo].[videos] ADD  DEFAULT (NULL) FOR [title]
GO
ALTER TABLE [dbo].[videos] ADD  DEFAULT (NULL) FOR [director]
GO
ALTER TABLE [dbo].[videos] ADD  DEFAULT (NULL) FOR [cli_id]
GO
ALTER TABLE [dbo].[videos]  WITH CHECK ADD  CONSTRAINT [videos_fk] FOREIGN KEY([cli_id])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[videos] CHECK CONSTRAINT [videos_fk]
GO
