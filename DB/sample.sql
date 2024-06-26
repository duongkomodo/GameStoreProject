USE [GameStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/30/2024 1:40:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Avatar] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[JoinDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/30/2024 1:40:09 AM ******/
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
/****** Object:  Table [dbo].[GameKeys]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameKeys](
	[Code] [nvarchar](450) NOT NULL,
	[GameId] [int] NOT NULL,
	[ExpirationDate] [datetime2](7) NULL,
	[OrderDetailOrderId] [int] NULL,
	[OrderDetailGameId] [int] NULL,
 CONSTRAINT [PK_GameKeys] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC,
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 5/30/2024 1:40:09 AM ******/
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
	[Price] [real] NOT NULL,
	[CategoryId] [int] NULL,
	[Discount] [int] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[OrderTime] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[TotalPrice] [real] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCarts]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCarts](
	[UserId] [nvarchar](450) NOT NULL,
	[GameId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_UserCarts] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFavoriteGame]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFavoriteGame](
	[UserId] [nvarchar](450) NOT NULL,
	[GameId] [int] NOT NULL,
 CONSTRAINT [PK_UserGame_Favorite] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620050738_ver1', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620132712_ver2', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620135202_ver3', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230620145050_ver4', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230627120711_ver5', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230703084530_ver6', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230704141150_ver7', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230719142207_ver8', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230722063154_ver9', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230722095024_ver10', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230722160431_ver11', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230724030403_Ver12', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230724135505_ver13', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230724141500_ver14', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230724144807_ver15', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230724152403_ver16', N'6.0.16')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'291bfc48-340e-4ff4-ae9c-cba35e67781e', N'Member', N'MEMBER', N'f9a2af4c-d740-49a3-871d-cd94c0b5f9f1')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7ceded84-12f1-45bd-847a-b9002fbf15c5', N'Manager', N'MANAGER', N'ced40efa-f06a-4c12-a5e1-6937658d8e28')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8e689009-64d3-417d-8c6a-b67af0775e32', N'Admin', N'ADMIN', N'70de2bbf-5288-48ec-b3bf-cc18c57b7a54')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'05ead902-dc7c-4b9b-b9b3-2d788564f92e', N'291bfc48-340e-4ff4-ae9c-cba35e67781e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5308f73b-b511-415f-af9e-36729d19ff44', N'291bfc48-340e-4ff4-ae9c-cba35e67781e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f6b92ad9-27eb-4def-9474-29eed7b4ac58', N'291bfc48-340e-4ff4-ae9c-cba35e67781e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [PasswordHash], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [Address], [JoinDate]) VALUES (N'05ead902-dc7c-4b9b-b9b3-2d788564f92e', N'duy', N'nguyen', NULL, N'duylbhe163097@fpt.edu.vn', N'AQAAAAEAACcQAAAAEJz+jS2wPAjvn2eIYIPIjGA4JAp2pD5kxttXj983/15cUNFbSgu0Y8lZA8uRNhshRA==', N'duylbhe163097@fpt.edu.vn', N'DUYLBHE163097@FPT.EDU.VN', NULL, 1, N'YVITNK6OVANVU76PM2WI2TPY2YVYMVGD', N'75909c37-2768-464c-8664-3cbb9d9afe40', 0, 0, NULL, 1, 0, N'https://upcdn.io/kW15bYA/raw/Avatar/05ead902-dc7c-4b9b-b9b3-2d788564f92e.png', NULL, CAST(N'2023-07-25T10:22:27.8355689' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [PasswordHash], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [Address], [JoinDate]) VALUES (N'5308f73b-b511-415f-af9e-36729d19ff44', N'duong', N'string', NULL, N'duongstablediffusion1@gmail.com', N'AQAAAAEAACcQAAAAECTJNaMf5x98E3oXN1aMkrj+Wj2YCWDfb/r8Jg99/Tu2+Kb+JQNwmYtKcAzTGrw00A==', N'duongstablediffusion1@gmail.com', N'DUONGSTABLEDIFFUSION1@GMAIL.COM', NULL, 1, N'ANWDXJNNLIWP5NZBTX227PEMTQJDOZ7X', N'6405dfd5-4ac8-4a13-b02c-dce8992c9ab7', 0, 0, NULL, 1, 0, N'Assets\blankAvatar.png', NULL, CAST(N'2023-07-22T13:09:58.9988729' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [PasswordHash], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Avatar], [Address], [JoinDate]) VALUES (N'f6b92ad9-27eb-4def-9474-29eed7b4ac58', N'Duong', N'Nguyen', NULL, N'duongcom123hn@gmail.com', N'AQAAAAEAACcQAAAAED7WBLLMA9ti3jLOQsGNkMFN54H9FL2tZEmaM8GsPpDcLnVVeu9seEnTE0xNkHlUqg==', N'duongcom123hn@gmail.com', N'DUONGCOM123HN@GMAIL.COM', NULL, 1, N'BM5D3IKLGU4XCHI2DLZPXXRB2R6NNMO7', N'3da79b6a-6fe1-449b-bb8c-c69dc4033866', 0, 0, NULL, 1, 0, N'https://upcdn.io/kW15bYA/raw/Avatar/f6b92ad9-27eb-4def-9474-29eed7b4ac58.png', N'Thai Nguyen', CAST(N'2002-03-12T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (1, N'Action', N'fast-paced combat, exploration, and platforming elements')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (2, N'Role-Playing', N'player controls a character or a party in a well-defined world, usually with some form of character development and story-telling')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (3, N'Strategy', N'focus on gameplay requiring careful and skillful thinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (4, N'Adventure', N' adventure describes a manner of gameplay without reflex challenges or action. ')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (5, N'Simulation', N'Simulation video games is a diverse super-category of games, generally designed to closely simulate aspects of a real or fictional reality.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (6, N'Sports', N'Sports are video games that simulate sports or arcade-style sports. The opposing team(s) can be controlled by other real life people or artificial intelligence.')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Desc]) VALUES (7, N'Others', N'Non-category games')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'AJOUW-HWJGB-NDUKU', 1, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'YYLE1-XPQPA-OWUBT', 1, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'DFHGP-LLTQV-DMPQU', 2, NULL, 16, 2)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'SVWSS-SUVCV-5YXBV', 2, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'AYZZX-OLZNV-KSE1M', 3, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'ETHQP-QDHEG-RRCEO', 3, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'VJSGV-VHQGP-HUYRY', 4, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'WRUGK-LLMYK-2BJEE', 4, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'EEEEC-CEEPL-RWFSW', 5, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'WQFJC-ESLUT-FKAAT', 5, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'JYJQV-HFOAU-EUMOJ', 6, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'TNEEC-SPZXG-YNGTK', 6, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'CAYMX-JPXPU-GMVFU', 7, NULL, 16, 7)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'UQNOQ-ZZOOL-WQTLB', 7, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'AJBKV-YRTWM-EEWRE', 8, NULL, 16, 8)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'RZKST-OXJTK-ZNKES', 8, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'DQCPQ-FHKLS-UZXMO', 9, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'JLKHS-QXFHJ-UU2CJ', 9, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'QWFOW-EOFAD-A7NNE', 10, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'TE9GP-EVT7B-HOKSQ', 10, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'NONYP-KDJLP-XFOOA', 11, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'WZVAN-AZMJP-PZDJP', 11, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'4OSTW-SRHKK-WJSHQ', 12, NULL, 17, 12)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'VPJDO-TL7OQ-GYA1E', 12, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'BLNBY-EZDMW-ENMFV', 13, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'VOORJ-SGXJT-XRRGM', 13, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'GEGPT-LTTPK-ABWVJ', 14, NULL, 17, 14)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'VXJLL-N3MKC-TDYYB', 14, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'JP7JA-LMLOV-CMFNF', 15, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'NFP9A-UGHZE-QEXAW', 15, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'EFCWS-PKYUH-DTROO', 16, NULL, 17, 16)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'PAURS-UDZOZ-LTTLZ', 16, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'RZMAD-WOUKK-QYFSE', 19, NULL, NULL, NULL)
INSERT [dbo].[GameKeys] ([Code], [GameId], [ExpirationDate], [OrderDetailOrderId], [OrderDetailGameId]) VALUES (N'WJXYF-OYAMH-LEBTS', 19, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (1, N'Cyberpunk 2077', N'Cyberpunk 2077 is an open-world, action-adventure RPG set in the dark future of Night City — a dangerous megalopolis obsessed with power, glamor, and ceaseless body modification.', N' ', N'https://upcdn.io/kW15bYA/raw/Games/CyberPunk2077.jpg
', 0, 2, 495000, 3, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (2, N'Red Dead Redemption 2', N'Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.', N' ', N'https://upcdn.io/kW15bYA/raw/Games/RedDead2.jpg
', 1, 2, 330000, 3, 10)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (3, N'Call of Duty®: Modern Warfare® II ', N'Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the return of the iconic Operators of Task Force 141.', N'', N'https://upcdn.io/kW15bYA/raw/Games/CODMW2.jpg
', 1, 2, 989500, 3, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (4, N'Grand Theft Auto V', N'Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/GTAV.jpg
', 1, 2, 227000, 3, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (5, N'Assassin''s Creed Valhalla', N'Become a legendary Viking on a quest for glory. Raid your enemies, grow your settlement, and build your political power.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/ACValhalla.jpg
', 1, 2, 247500, 3, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (6, N'Fallout 4', N'Bethesda Game Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 – their most ambitious game ever, and the next generation of open-world gaming.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/Fallout4.jpg
', 1, 2, 450000, 4, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (7, N'The Witcher® 3: Wild Hunt', N'You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/TheWitcher3.jpg
', 1, 2, 117000, 4, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (8, N'Stardew Valley', N'You''ve inherited your grandfather''s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home?', NULL, N'https://upcdn.io/kW15bYA/raw/Games/StardewValley.jpg
', 1, 2, 132000, 4, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (9, N'STARFIELD', N'Starfield is the first new universe in 25 years from Bethesda Game Studios, the award-winning creators of The Elder Scrolls V: Skyrim and Fallout 4.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/StarField.jpg
', 1, 2, 1290000, 4, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (10, N'The Elder Scrolls® Online', N'Join over 20 million players in the award-winning online multiplayer RPG and experience limitless adventure in a persistent Elder Scrolls world. Battle, craft, steal, or explore, and combine different types of equipment and abilities to create your own style of play. No game subscription required.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/TheElderScrollsOnline.jpg
', 1, 2, 450000, 4, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (11, N'RimWorld', N'A sci-fi colony sim driven by an intelligent AI storyteller. Generates stories by simulating psychology, ecology, gunplay, melee combat, climate, biomes, diplomacy, interpersonal relationships, art, medicine, trade, and more.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/RimWorld.jpg
', 1, 2, 350000, 6, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (12, N'Stellaris', N'Explore a galaxy full of wonders in this sci-fi grand strategy game from Paradox Development Studios. Interact with diverse alien races, discover strange new worlds with unexpected events and expand the reach of your empire. Each new adventure holds almost limitless possibilities.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/Stellaris.jpg
', 1, 2, 400000, 6, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (13, N'Total War: WARHAMMER III', N'The cataclysmic conclusion to the Total War: WARHAMMER trilogy is here. Rally your forces and step into the Realm of Chaos, a dimension of mind-bending horror where the very fate of the world will be decided. Will you conquer your Daemons… or command them?', NULL, N'https://upcdn.io/kW15bYA/raw/Games/TotalWarWARHAMMER3.jpg
', 1, 2, 1061500, 6, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (14, N'The Death | Thần Trùng', N'The Death | Thần Trùng is a Viet Nam psychological horror adventure game made by three Vietnamese people from a tiny indie studio. The game takes place in Hanoi city in 2022.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/ThanTrung.jpg', 1, 2, 57500, 7, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (15, N'Sea of Thieves 2023 Edition', N'Celebrate five years since Sea of Thieves'' launch with this special edition, including a copy of the game with all permanent content added since launch, plus a 10,000 gold bonus and a selection of Hunter cosmetics: the Hunter Cutlass, Pistol, Compass, Hat, Jacket and Sails.', NULL, N'https://upcdn.io/kW15bYA/raw/Games/SeaOfThieves.jpg', 1, 2, 247500, 7, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (16, N'Terraria', N'Dig, fight, explore, build! Nothing is impossible in this action-packed adventure game. Four Pack also available!', NULL, N'https://upcdn.io/kW15bYA/raw/Games/Terraria.jpg', 1, 2, 120000, 7, 0)
INSERT [dbo].[Games] ([GameId], [Name], [Description], [TechReq], [Image], [IsAvailable], [Quantity], [Price], [CategoryId], [Discount]) VALUES (19, N'Resident Evil 4', N'Survival is just the beginning. Six years have passed since the biological disaster in Raccoon City. Leon S. Kennedy, one of the survivors, tracks the president''s kidnapped daughter to a secluded European village, where there is something terribly wrong with the locals.', N'MINIMUM:
Requires a 64-bit processor and operating system
OS: Windows 10 (64 bit)
Processor: AMD Ryzen 3 1200 / Intel Core i5-7500
Memory: 8 GB RAM
Graphics: AMD Radeon RX 560 with 4GB VRAM / NVIDIA GeForce GTX 1050 Ti with 4GB VRAM
DirectX: Version 12
Network: Broadband Internet connection
Additional Notes: Estimated performance (when set to Prioritize Performance): 1080p/45fps. ・Framerate might drop in graphics-intensive scenes. ・AMD Radeon RX 6700 XT or NVIDIA GeForce RTX 2060 required to support ray tracing.
RECOMMENDED:
Requires a 64-bit processor and operating system
OS: Windows 10 (64 bit)/Windows 11 (64 bit)
Processor: AMD Ryzen 5 3600 / Intel Core i7 8700
Memory: 16 GB RAM
Graphics: AMD Radeon RX 5700 / NVIDIA GeForce GTX 1070
DirectX: Version 12
Network: Broadband Internet connection
Additional Notes: Estimated performance: 1080p/60fps ・Framerate might drop in graphics-intensive scenes. ・AMD Radeon RX 6700 XT or NVIDIA GeForce RTX 2070 required to support ray tracing.', N'https://upcdn.io/kW15bYA/raw/Games/share-re.png', 1, 2, 1322000, 3, 0)
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (16, 2, 330000, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (16, 7, 117000, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (16, 8, 132000, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (17, 12, 400000, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (17, 14, 57500, 1)
INSERT [dbo].[OrderDetails] ([OrderId], [GameId], [Price], [Quantity]) VALUES (17, 16, 120000, 1)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderTime], [Status], [TotalPrice]) VALUES (16, N'f6b92ad9-27eb-4def-9474-29eed7b4ac58', CAST(N'2023-07-24T22:36:06.7659282' AS DateTime2), 2, 579000)
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderTime], [Status], [TotalPrice]) VALUES (17, N'05ead902-dc7c-4b9b-b9b3-2d788564f92e', CAST(N'2023-07-25T10:28:52.0567720' AS DateTime2), 2, 577500)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Avatar]
GO
ALTER TABLE [dbo].[Games] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([real],(0))) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[UserCarts] ADD  DEFAULT ((0)) FOR [GameId]
GO
ALTER TABLE [dbo].[UserCarts] ADD  DEFAULT (CONVERT([real],(0))) FOR [Price]
GO
ALTER TABLE [dbo].[UserCarts] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_Games_GameId]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_OrderDetails] FOREIGN KEY([OrderDetailOrderId], [GameId])
REFERENCES [dbo].[OrderDetails] ([OrderId], [GameId])
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_OrderDetails]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_OrderDetails_OrderDetailOrderId_OrderDetailGameId] FOREIGN KEY([OrderDetailOrderId], [OrderDetailGameId])
REFERENCES [dbo].[OrderDetails] ([OrderId], [GameId])
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_OrderDetails_OrderDetailOrderId_OrderDetailGameId]
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
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[UserCarts]  WITH CHECK ADD  CONSTRAINT [FK_UserCart_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCarts] CHECK CONSTRAINT [FK_UserCart_User]
GO
ALTER TABLE [dbo].[UserCarts]  WITH CHECK ADD  CONSTRAINT [FK_UserCarts_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCarts] CHECK CONSTRAINT [FK_UserCarts_Games_GameId]
GO
ALTER TABLE [dbo].[UserFavoriteGame]  WITH CHECK ADD  CONSTRAINT [FK_Games_User] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[UserFavoriteGame] CHECK CONSTRAINT [FK_Games_User]
GO
ALTER TABLE [dbo].[UserFavoriteGame]  WITH CHECK ADD  CONSTRAINT [FK_User_Games] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserFavoriteGame] CHECK CONSTRAINT [FK_User_Games]
GO
/****** Object:  Trigger [dbo].[update_gamekeys_IsAvailable]    Script Date: 5/30/2024 1:40:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[update_gamekeys_IsAvailable]
ON [dbo].[GameKeys]
AFTER DELETE 
AS
BEGIN
   
  UPDATE Games SET IsAvailable = 0 WHERE GameId IN 
  (SELECT GameId FROM deleted EXCEPT SELECT GameId FROM inserted) AND NOT EXISTS (SELECT * FROM Gamekeys WHERE GameId = Games.GameId);
END
GO
ALTER TABLE [dbo].[GameKeys] ENABLE TRIGGER [update_gamekeys_IsAvailable]
GO
