USE [InstituteOfFineArtsDB]
GO
/****** Object:  Table [dbo].[Competition]    Script Date: 3/21/2023 19:35:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition](
	[CompetitionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Detail] [nvarchar](max) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Status] [int] NULL,
	[RewardId] [int] NULL,
 CONSTRAINT [PK_Competition] PRIMARY KEY CLUSTERED 
(
	[CompetitionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desigin]    Script Date: 3/21/2023 19:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desigin](
	[DesiginId] [int] IDENTITY(1,1) NOT NULL,
	[Path] [varchar](200) NULL,
	[Name] [nvarchar](200) NULL,
	[Topic] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [date] NULL,
	[Mark] [nvarchar](10) NULL,
	[Remark] [nchar](10) NULL,
	[Exhibition] [int] NULL,
	[Status] [int] NULL,
	[UserId] [int] NULL,
	[CompetitionId] [int] NULL,
	[RewardId] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Desigin] PRIMARY KEY CLUSTERED 
(
	[DesiginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reward]    Script Date: 3/21/2023 19:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reward](
	[RewardId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](200) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Reward] PRIMARY KEY CLUSTERED 
(
	[RewardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/21/2023 19:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [bigint] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Competition] ON 

INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (3, N'BO it! 2023 International Illustration Competition', N'	
BO it! 2023 International Illustration Competition
"BO it!" is an illustration contest open to people born before 25 February 2005.

The theme of this edition focuses on climate change and carbon neutrality.

The competition is free to enter.
', CAST(N'2023-03-15' AS Date), CAST(N'2023-04-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (4, N'BDFIL – Caran d''Ache Prize', N'The competition is open to emerging comic artists aged 15 and over.This year''s theme is EUREKA. You may submit a complete comic story, on one board, with or without text.', CAST(N'2023-05-15' AS Date), CAST(N'2023-06-15' AS Date), 0, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (5, N'Wells Art Contemporary Awards 2023', N'	
The competition is open to artists over the age of 18.

Entries can be any medium – painting, sculpture, drawing, printmaking, photography, installation or video.

The entry fee is £17.50 per work or £10 per work for current students.', CAST(N'2023-01-01' AS Date), CAST(N'2023-02-01' AS Date), 2, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (6, N'International Award on Scientific Illustration', N'The competition is open to illustrators over the age of 18.The subject of the illustrations must be related to science or nature and the technique is free.The competition is free to enter.There are three prizes of $ 1,000 each.', CAST(N'2023-05-15' AS Date), CAST(N'2023-10-01' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (7, N' The 25th Short Film Festival ', N'The International Short Film Festival "Ciudad de Soria" invites artists to design a poster for the 25th edition of the Festival.The competition is free to enter.The winner will receive a cash prize of 1,000 €.', CAST(N'2023-01-01' AS Date), CAST(N'2023-04-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (8, N'The Future Generation Art Prize 2023', N'	
The Future Generation Art Prize is a world-wide competition open to artists aged between 18 and 35.

All works of art, regardless of category or media are eligible for submission.

The competition is free to enter.

The main prize winner receives US $100,000 split', CAST(N'2023-01-01' AS Date), CAST(N'2023-06-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (9, N'Aesthetica Art Prize 2023', N'	
The Aesthetica Art Prize is an annual award organized by Aesthetica, an international art and culture magazine.

The Art Prize is open to works in any genre, and on any theme.

Entry fee: £25.

• Main Art Prize: £10,000
• Emerging Art Prize: £1,000', CAST(N'2023-05-15' AS Date), CAST(N'2023-06-15' AS Date), 0, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (10, N'9th Annual Printmaking Contest ON PAPER', N'	
Each artist can submit one artwork on paper. Only traditional printmaking techniques will be accepted, including screenprinting, lithography, etching, monotype etc.

The entry fee is 26 €.

The winner will receive a cash prize of 1,000 €.', CAST(N'2023-03-15' AS Date), CAST(N'2023-03-20' AS Date), 2, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (11, N'The 12th Kochi International', N'	The competition is open to artists from around the world.All entries must be original prints on paper.The entry fee for artists from Japan is ¥ 9,000. If the entrant submits his/her work from overseas, they will be exempt from the entry fee.• 1st Prize: 1,000,000 yen• 2nd Prize: 500,000 yen• 3rd Prize: 300,000 yen', CAST(N'2023-02-15' AS Date), CAST(N'2023-04-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (12, N'Ruth Borchard Self-Portrait Prize 2023', N'	
Artists of all backgrounds, established and emerging, are invited to enter.

The artwork must be a self-portrait.

Submission fees:
• £38 from a UK based bank account
• International entry fee: £48

The winner will receive a cash prize of £10,000.', CAST(N'2023-01-01' AS Date), CAST(N'2023-04-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (13, N'Wildlife Artist of the Year 2023', N'	
The competition is open to all artists, both amateur and professional, aged 15 years and over.

All traditional artistic mediums are accepted (oil, acrylic, watercolor, pencil, mixed media, bronze, plaster, wire, collage, textiles).

The entry fee is £25 per an artwork for the first two entries, thereafter it is £15 per entry.

The overall winner will receive a cash prize of £5,000.', CAST(N'2023-02-15' AS Date), CAST(N'2023-06-15' AS Date), 1, 5)
INSERT [dbo].[Competition] ([CompetitionId], [Name], [Detail], [StartDate], [EndDate], [Status], [RewardId]) VALUES (14, N'Comic/Manga School Contest 2023', N'	The competition is open to students worldwide.This year''s theme is "Light and Darkness".Entries will be accepted for the following six categories: Comic / Manga / Bande Dessinée / Webtoon / Storyboard / Illustration.Entry is free.The overall winner will receive a cash prize of US$3,300 and the new Wacom Cintiq Pro 16.', CAST(N'2023-02-15' AS Date), CAST(N'2023-04-15' AS Date), 1, 5)
SET IDENTITY_INSERT [dbo].[Competition] OFF
GO
SET IDENTITY_INSERT [dbo].[Desigin] ON 

INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (30, N'/Uploads/2023321_1613_best-art-contests-4.jpg', N'WATERMEDIA ', N'Painting ', N'The Watermedia Showcase awards original art created primarily with water-based media (watercolor, acrylic, casein, gouache, or egg tempera) on a surface created for water media. Judged by the editors of Watercolor Artist, all winners, and honorable mentions will have their work featured in the magazine.', CAST(N'2023-03-21' AS Date), N'A', N'Very Good ', 0, 0, 4, 10, 1, 20000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (31, N'/Uploads/2023321_1615_an-orchard-in-spring-by-claude-monet-600x472.jpg', N'Competition organizers', N'Painting ', N'An organization or institution may be offering a spot as an artist-in-residence.  Often, a non-profit organization or public funds pay the artist’s salary and expenses. Artist-in-residency competitions may be selected based on a theme, geography, history, or to explore an ongoing project.

Your work and practice will need to match the project, and you will need to ensure you are available for the dates set out in the competition.

We have more information on taking part and applying for residencies in our blog.', CAST(N'2023-03-21' AS Date), N'A', N'Good      ', 0, 0, 4, 9, 2, 18000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (32, N'/Uploads/2023321_1622_audrey-zhang-doodle-4-google-competition.jpg', N'Doodle 4 Google', N'Annual ', N'Doodle 4 Google is an annual competition designed especially for school children, providing them with a unique opportunity to have their design featured on the Google homepage. The competition runs in many different countries with a changing theme each year. Children must submit their doodle along with an application form and short description of what they have created and why. All submissions are grouped and judged in age groups and are critiqued in terms of artistic merit, creativity, and how well the theme is communicated through the artwork', CAST(N'2023-03-21' AS Date), N'A', N'Nice Pic  ', 0, 1, 9, 14, 1, 15000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (33, N'/Uploads/2023321_1623_black.jpg', N'Black & White ', N'Online Art ', N'All winning artists (Merit Award & Honorable Mention) will receive a digital award certificate. Winning artwork (Best of Show) will be on the poster of the show. All winning artists will receive a digital award certificate. Open to all artists worldwide over 18 years of age.', CAST(N'2023-03-21' AS Date), N'A', N'Well Well ', 0, 0, 9, 13, 1, 10000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (34, N'/Uploads/2023321_1628_NoraLloyd_SarahB.jpg', N'All Women', N'Painting ', N'Prizes include Memberships to Contemporary Art Gallery Online, Extensive Marketing, Digital Winner''s Certificates, and more. Jurors: Sharon Drinkard, Michael Harris, Portia T. Webb, Anissa Harris, Kelsey Hails. All work must belong to the person submitting the application', CAST(N'2023-03-21' AS Date), N'A', N'Good Job  ', 0, 1, 7, 9, 2, 5000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (35, N'/Uploads/2023321_1629_17231.jpg', N'"Yellow" Call for Entry', N'Online Art ', N'seeks entries for an online art exhibition, May 1-31, 2023. Cash award will be given to the Best of Show winner. Juror: Janelle Cogan. Theme- "Yellow" This primary color is often associated with happiness, spontaneity, amusement, gentleness, but also with envy, jealousy, and cowardice. Yellow symbolizes many things and has different meanings in different cultures. We would like to see your interpretation of this color. We will be donating 10% of all entry fees to Soles4Souls. Soles4Souls creates sustainable jobs and provides relief through the distribution of shoes and clothing around the world.', CAST(N'2023-03-21' AS Date), N'A', N'Beautifull', 0, 0, 7, 7, 2, 3000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (36, N'/Uploads/2023321_1642_Spinale_M_BendingInTheWind.jpg', N'For Pastels Only', N'Painting ', N' Juror of Selection: Corey Pitkin; Juror of Awards: Christine Ivers. Open to all pastelists. Paintings must be entirely the work of the artist and at least 80% soft pastels, no oil pastels, created within last three years, not larger than 48" framed in any direction, has not won one of the top four awards in any national or international juried pastel society show as of the entry deadline, and not previously shown at a PPSCC or Cultural Center exhibition.', CAST(N'2023-03-21' AS Date), N'A', N'Prefect   ', 0, 1, 8, 11, 1, 6000)
INSERT [dbo].[Desigin] ([DesiginId], [Path], [Name], [Topic], [Description], [Date], [Mark], [Remark], [Exhibition], [Status], [UserId], [CompetitionId], [RewardId], [Price]) VALUES (37, N'/Uploads/2023321_1643_plant_life.jpg', N'Plant Life', N'Tree', N' Juror: Linda Robinson, Gallery Director, MWCP. The Plant Life exhibition will feature photographs from a wide variety of plant species that are grown year around and appreciated in our lives. As we celebrate plant life in all its forms, all photographic interpretations are welcome for exhibition; images of flowers and plants from subtle to bold, whether captured through still-life photography or through exploration of nature photography approaches. Selected artists will have their work featured in the gallery and online. Open to all photographers internationally.', CAST(N'2023-03-21' AS Date), N'A', N'Execlien  ', 0, 1, 8, 8, 1, 65000)
SET IDENTITY_INSERT [dbo].[Desigin] OFF
GO
SET IDENTITY_INSERT [dbo].[Reward] ON 

INSERT [dbo].[Reward] ([RewardId], [Name], [Detail], [Price]) VALUES (1, N'Champion', N'1st', 10000)
INSERT [dbo].[Reward] ([RewardId], [Name], [Detail], [Price]) VALUES (2, N'runner-up', N'2st', 6000)
INSERT [dbo].[Reward] ([RewardId], [Name], [Detail], [Price]) VALUES (3, N'third rate', N'3st', 3000)
INSERT [dbo].[Reward] ([RewardId], [Name], [Detail], [Price]) VALUES (4, N'1st,2st,3st', N'all award for competition', 20000)
INSERT [dbo].[Reward] ([RewardId], [Name], [Detail], [Price]) VALUES (5, N'All Award', N'All award for competition', 50000)
SET IDENTITY_INSERT [dbo].[Reward] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (1, N'Nguyen Thai ', N'Male', N'can tho', N'nguyenthai@gmail.com', 9875489657, N'admin', N'12345', 0)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (2, N'My Linh', N'Female', N'can tho', N'mylinh@gmail.com', 1245789689, N'teacher', N'12345', 2)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (3, N'Viet', N'Male', N'can tho', N'viet@gmail.com', 2585264987, N'manager', N'12345', 1)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (4, N'Quoc Anh', N'Male', N'can tho', N'qanh@gmail.com', 2356891849, N'student', N'12345', 3)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (7, N'David', N'Male', N'usa', N'David@gmail.com', 6549832659, N'david', N'12345', 3)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (8, N'lisa', N'Femal', N'russia', N'lisa@gmail.com', 6549873568, N'lisa', N'12345', 3)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (9, N'kevin', N'Male', N'new york', N'kevin@gmail.com', 6541234598, N'kevin', N'12345', 3)
INSERT [dbo].[User] ([UserId], [FullName], [Gender], [Address], [Email], [Phone], [Username], [Password], [UserType]) VALUES (10, N'Seria', N'Femal', N'england', N'seria@gmail.com', 1236549879, N'seria', N'12345', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Competition]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Reward] FOREIGN KEY([RewardId])
REFERENCES [dbo].[Reward] ([RewardId])
GO
ALTER TABLE [dbo].[Competition] CHECK CONSTRAINT [FK_Competition_Reward]
GO
ALTER TABLE [dbo].[Desigin]  WITH CHECK ADD  CONSTRAINT [FK_Desigin_Competition] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competition] ([CompetitionId])
GO
ALTER TABLE [dbo].[Desigin] CHECK CONSTRAINT [FK_Desigin_Competition]
GO
ALTER TABLE [dbo].[Desigin]  WITH CHECK ADD  CONSTRAINT [FK_Desigin_Reward] FOREIGN KEY([RewardId])
REFERENCES [dbo].[Reward] ([RewardId])
GO
ALTER TABLE [dbo].[Desigin] CHECK CONSTRAINT [FK_Desigin_Reward]
GO
ALTER TABLE [dbo].[Desigin]  WITH CHECK ADD  CONSTRAINT [FK_Desigin_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Desigin] CHECK CONSTRAINT [FK_Desigin_User]
GO
