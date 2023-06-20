USE [master]
GO
/****** Object:  Database [GameStore]    Script Date: 6/20/2023 10:42:52 AM ******/
CREATE DATABASE [GameStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GameStore', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GameStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GameStore_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GameStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GameStore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GameStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GameStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameStore] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GameStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameStore] SET RECOVERY FULL 
GO
ALTER DATABASE [GameStore] SET  MULTI_USER 
GO
ALTER DATABASE [GameStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GameStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GameStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GameStore', N'ON'
GO
ALTER DATABASE [GameStore] SET QUERY_STORE = ON
GO
ALTER DATABASE [GameStore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GameStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Desc] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameKeys]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameKeys](
	[Code] [nvarchar](450) NOT NULL,
	[GameId] [int] NOT NULL,
	[ExpirationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_GameKeys] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC,
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TechReq] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsAvailable] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderTime] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/20/2023 10:42:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230610055551_ver1', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230612132342_Ver2', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230612132846_Ver3', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230612141038_Ver4', N'6.0.16')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (3, N'
Action', N'fast-paced combat, exploration, and platforming elements')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (4, N'Role-Playing', N'player controls a character or a party in a well-defined world, usually with some form of character development and story-telling')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (6, N'Strategy', N'focus on gameplay requiring careful and skillful thinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (7, N'Adventure', N' adventure describes a manner of gameplay without reflex challenges or action. ')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (8, N'Simulation', N'Simulation video games is a diverse super-category of games, generally designed to closely simulate aspects of a real or fictional reality.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (10, N'Sports', N'Sports are video games that simulate sports or arcade-style sports. The opposing team(s) can be controlled by other real life people or artificial intelligence.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (11, N'Others', N'Non-category games')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (3, N'Cyberpunk 2077', N'Cyberpunk 2077 is an open-world, action-adventure RPG set in the dark future of Night City — a dangerous megalopolis obsessed with power, glamor, and ceaseless body modification.', N' ', N' ', 1, 2, 495000, 3)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (4, N'Red Dead Redemption 2', N'Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.', N' ', N' ', 1, 1, 330000, 3)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (5, N'Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the return of the iconic Operators of Task Force 141.', N'Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the return of the iconic Operators of Task Force 141.', N'', N'', 1, 2, 989500, 3)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (6, N'Grand Theft Auto V', N'Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second.', NULL, NULL, 1, 2, 227000, 3)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (7, N'Assassin''s Creed Valhalla', N'Become a legendary Viking on a quest for glory. Raid your enemies, grow your settlement, and build your political power.', NULL, NULL, 1, 3, 247500, 3)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (8, N'Fallout 4', N'Bethesda Game Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 – their most ambitious game ever, and the next generation of open-world gaming.', NULL, NULL, 1, 3, 450000, 4)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (9, N'The Witcher® 3: Wild Hunt', N'You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world.', NULL, NULL, 1, 2, 117000, 4)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (10, N'Stardew Valley', N'You''ve inherited your grandfather''s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home?', NULL, NULL, 1, 2, 132000, 4)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (11, N'STARFIELD', N'Starfield is the first new universe in 25 years from Bethesda Game Studios, the award-winning creators of The Elder Scrolls V: Skyrim and Fallout 4.', NULL, NULL, 1, 2, 1290000, 4)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (12, N'The Elder Scrolls® Online', N'Join over 20 million players in the award-winning online multiplayer RPG and experience limitless adventure in a persistent Elder Scrolls world. Battle, craft, steal, or explore, and combine different types of equipment and abilities to create your own style of play. No game subscription required.', NULL, NULL, 1, 2, 450000, 4)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (15, N'RimWorld', N'A sci-fi colony sim driven by an intelligent AI storyteller. Generates stories by simulating psychology, ecology, gunplay, melee combat, climate, biomes, diplomacy, interpersonal relationships, art, medicine, trade, and more.', NULL, NULL, 1, 2, 350000, 6)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (16, N'Stellaris', N'Explore a galaxy full of wonders in this sci-fi grand strategy game from Paradox Development Studios. Interact with diverse alien races, discover strange new worlds with unexpected events and expand the reach of your empire. Each new adventure holds almost limitless possibilities.', NULL, NULL, 1, 2, 400000, 6)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (17, N'Total War: WARHAMMER III', N'The cataclysmic conclusion to the Total War: WARHAMMER trilogy is here. Rally your forces and step into the Realm of Chaos, a dimension of mind-bending horror where the very fate of the world will be decided. Will you conquer your Daemons… or command them?', NULL, NULL, 1, 2, 1061500, 6)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (18, N'The Death | Thần Trùng', N'The Death | Thần Trùng is a Viet Nam psychological horror adventure game made by three Vietnamese people from a tiny indie studio. The game takes place in Hanoi city in 2022.', NULL, NULL, 1, 2, 57500, 7)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (19, N'Sea of Thieves 2023 Edition', N'Celebrate five years since Sea of Thieves'' launch with this special edition, including a copy of the game with all permanent content added since launch, plus a 10,000 gold bonus and a selection of Hunter cosmetics: the Hunter Cutlass, Pistol, Compass, Hat, Jacket and Sails.', NULL, NULL, 1, 2, 247500, 7)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (20, N'Terraria', N'Dig, fight, explore, build! Nothing is impossible in this action-packed adventure game. Four Pack also available!', NULL, NULL, 1, 2, 120000, 7)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (21, N'Farming Simulator 22', N'Create your farm and let the good times grow! Harvest crops, tend to animals, manage productions, and take on seasonal challenges.', NULL, NULL, 1, 2, 467000, 8)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId]) VALUES (22, N'Project Zomboid', N'Project Zomboid is the ultimate in zombie survival. Alone or in MP: you loot, build, craft, fight, farm and fish in a struggle to survive. A hardcore RPG skillset, a vast map, massively customisable sandbox and a cute tutorial raccoon await the unwary. So how will you die? All it takes is a bite..', NULL, NULL, 1, 2, 260000, 8)
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PhoneNumber], [Email], [PasswordHash]) VALUES (2, N'Nguyen', N'', NULL, N'duongcom123hn@gmail.com', N'$2y$16$GDIJRxCuHhNLhR99jccip.qAQyiDl6DM5KyPSPHzcoQEJPBHLy6xG')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Games_CategoryId]    Script Date: 6/20/2023 10:42:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Games_CategoryId] ON [dbo].[Games]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_GameId]    Script Date: 6/20/2023 10:42:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_GameId] ON [dbo].[OrderDetails]
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 6/20/2023 10:42:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_Games_GameId]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Categories_CategoryId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_Order_Details_Games]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
USE [master]
GO
ALTER DATABASE [GameStore] SET  READ_WRITE 
GO
