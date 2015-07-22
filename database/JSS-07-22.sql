USE [JSS_System]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 22/07/2015 20:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdministratorID] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[AdministratorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Advertise]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertise](
	[AdvertiseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Advertise] PRIMARY KEY CLUSTERED 
(
	[AdvertiseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlertEmail]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertEmail](
	[AlertEmail_ID] [int] IDENTITY(1,1) NOT NULL,
	[AlertEmail_content] [ntext] NOT NULL,
	[Staff_ID] [nvarchar](128) NOT NULL,
	[SendDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AlertEmail] PRIMARY KEY CLUSTERED 
(
	[AlertEmail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppliedJob]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedJob](
	[JobSeekerID] [nvarchar](128) NOT NULL,
	[JobID] [int] NOT NULL,
	[ProfileID] [int] NOT NULL,
	[ApplyDate] [date] NOT NULL,
	[MatchingPercent] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AppliedJob] PRIMARY KEY CLUSTERED 
(
	[JobSeekerID] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Benefit]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Benefit](
	[BenefitID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Benefit] PRIMARY KEY CLUSTERED 
(
	[BenefitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[RecruiterID] [nvarchar](128) NOT NULL,
	[LogoURL] [nvarchar](150) NULL,
	[Company] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[District] [nvarchar](30) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Description] [ntext] NULL,
	[IsVisible] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[RecruiterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyInfoCity]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfoCity](
	[RecuiterID] [nvarchar](128) NOT NULL,
	[CityID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyInfoCity] PRIMARY KEY CLUSTERED 
(
	[RecuiterID] ASC,
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[UserID] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[MaritalStatus] [bit] NOT NULL,
	[Nationality] [bit] NOT NULL,
	[Address] [nvarchar](150) NULL,
	[DateofBirth] [date] NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[CityID] [int] NOT NULL,
	[District] [nvarchar](20) NULL,
	[IsVisible] [bit] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DesiredBenefit]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesiredBenefit](
	[BenefitID] [int] NOT NULL,
	[JobSeekerID] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ResumeBenefit] PRIMARY KEY CLUSTERED 
(
	[BenefitID] ASC,
	[JobSeekerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EducationHistory]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationHistory](
	[EducationHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[School] [nvarchar](50) NOT NULL,
	[SchoolLevel_ID] [int] NOT NULL,
	[Achievement] [ntext] NULL,
	[ProfileID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_EducationHistory] PRIMARY KEY CLUSTERED 
(
	[EducationHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmploymentHistory]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmploymentHistory](
	[EmploymentHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
	[WorkingTime] [int] NOT NULL,
	[Description] [ntext] NULL,
	[ProfileID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_EmploymentHistory] PRIMARY KEY CLUSTERED 
(
	[EmploymentHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpectedCategory]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpectedCategory](
	[ProfileID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ExpectedCategory] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpectedCity]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpectedCity](
	[ProfileID] [int] NOT NULL,
	[CityID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ExpectedCity] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC,
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guest]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestEmail] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[GuestEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Job]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[RecruiterID] [nvarchar](128) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[MinSalary] [money] NULL,
	[MaxSalary] [money] NULL,
	[JobDescription] [ntext] NOT NULL,
	[JobLevel_ID] [int] NOT NULL,
	[MinSchoolLevel_ID] [int] NOT NULL,
	[JobView] [bigint] NOT NULL,
	[StartedDate] [date] NULL,
	[EndedDate] [date] NULL,
	[IsPublic] [bit] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobBenefit]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobBenefit](
	[BenefitID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobBenefit] PRIMARY KEY CLUSTERED 
(
	[BenefitID] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobCategory]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCategory](
	[CategoryID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobCity]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCity](
	[JobID] [int] NOT NULL,
	[CityID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobCity] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobLanguage]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobLanguage](
	[LanguageID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[Description] [ntext] NULL,
	[MinLevel_ID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LangueJob] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobLevel]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobLevel](
	[JobLevel_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LevelNum] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PositionLevel] PRIMARY KEY CLUSTERED 
(
	[JobLevel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobPackage]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPackage](
	[JobPackageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[JobNumber] [int] NOT NULL,
	[PostDuration] [int] NOT NULL,
	[IsHighlight] [bit] NOT NULL,
	[IsCategoryPriority] [bit] NOT NULL,
	[IsHomepagePosting] [bit] NOT NULL,
	[ViewMultiNumber] [int] NULL,
	[MoreDescription] [nvarchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobPackage] PRIMARY KEY CLUSTERED 
(
	[JobPackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jobseeker]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobseeker](
	[JobSeekerID] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Jobseeker] PRIMARY KEY CLUSTERED 
(
	[JobSeekerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobSkill]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSkill](
	[Skill_ID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobSkill] PRIMARY KEY CLUSTERED 
(
	[Skill_ID] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Level]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[Level_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LevelNum] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[Level_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manager]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[ManagerID] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [nvarchar](128) NOT NULL,
	[Message_content] [ntext] NOT NULL,
	[SendTime] [datetime] NOT NULL,
	[IsDeletedBySender] [bit] NOT NULL,
	[IsCanceled] [bit] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageReceiver]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageReceiver](
	[MessageID] [int] NOT NULL,
	[ReceiverID] [nvarchar](128) NOT NULL,
	[ReadTime] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_MessageReceiver] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC,
	[ReceiverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OwnSkill]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnSkill](
	[Skill_ID] [int] NOT NULL,
	[JobSeekerID] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserSkill] PRIMARY KEY CLUSTERED 
(
	[Skill_ID] ASC,
	[JobSeekerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profile]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[YearOfExperience] [int] NOT NULL,
	[HighestSchoolLevel_ID] [int] NOT NULL,
	[MostRecentCompany] [nvarchar](50) NULL,
	[MostRecentPosition] [nvarchar](50) NULL,
	[CurrentJobLevel_ID] [int] NULL,
	[ExpectedPosition] [nvarchar](50) NOT NULL,
	[ExpectedJobLevel_ID] [int] NOT NULL,
	[ExpectedSalary] [money] NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedTime] [datetime] NOT NULL,
	[Objectives] [ntext] NOT NULL,
	[PercentStatus] [int] NOT NULL,
	[JobSeekerID] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfileLanguage]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileLanguage](
	[LanguageID] [int] NOT NULL,
	[ProfileID] [int] NOT NULL,
	[Level_ID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LanguageResume] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC,
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseAdvertise]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseAdvertise](
	[PurchaseAdsID] [int] IDENTITY(1,1) NOT NULL,
	[AdvertiseID] [int] NOT NULL,
	[RecuiterID] [nvarchar](128) NOT NULL,
	[LogoUrl] [nvarchar](200) NOT NULL,
	[LinkUrl] [nvarchar](200) NOT NULL,
	[PurchasedDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[ManagerID] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PurchaseAdvertise_1] PRIMARY KEY CLUSTERED 
(
	[PurchaseAdsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseJobPackage]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseJobPackage](
	[PurchaseJobPackageID] [int] IDENTITY(1,1) NOT NULL,
	[RecruiterID] [nvarchar](128) NOT NULL,
	[JobPackageID] [int] NOT NULL,
	[PurchasedDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[StaffID] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PurchaseJobPackage] PRIMARY KEY CLUSTERED 
(
	[PurchaseJobPackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recruiter]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recruiter](
	[RecruiterID] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Recruiter] PRIMARY KEY CLUSTERED 
(
	[RecruiterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReferencePerson]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferencePerson](
	[ReferencePersonID] [int] IDENTITY(1,1) NOT NULL,
	[ReferencePersonName] [nvarchar](50) NOT NULL,
	[ReferencePersonPosition] [nvarchar](50) NOT NULL,
	[ReferencePersonCompany] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[ReferencePersonPhoneNumber] [nvarchar](20) NULL,
	[ProfileID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReferencePerson] PRIMARY KEY CLUSTERED 
(
	[ReferencePersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[Report_content] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SenderID] [nvarchar](128) NOT NULL,
	[IsSolved] [bit] NOT NULL,
	[SolvedUserID] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolLevel]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolLevel](
	[SchoolLevel_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LevelNum] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SchoolLevel] PRIMARY KEY CLUSTERED 
(
	[SchoolLevel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skill]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Skill_ID] [int] NOT NULL,
	[SkillTag] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[Skill_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topic]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[WriterID] [nvarchar](128) NOT NULL,
	[ImageUrl] [varchar](250) NULL,
	[Topic_content] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedStaffID] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ViewProfile]    Script Date: 22/07/2015 20:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewProfile](
	[RecruiterID] [nvarchar](128) NOT NULL,
	[ProfileID] [int] NOT NULL,
	[ViewedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ViewResume] PRIMARY KEY CLUSTERED 
(
	[RecruiterID] ASC,
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3e373f93-33b3-4c1b-9647-6e3978fe3bff', N'Staff')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'66b87dc2-01d4-49cf-bfb6-051a04358f6d', N'Recruiter')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'755cd5ee-3d9e-4965-ae4e-11a57cfe1514', N'Manager')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bb2518d8-d5a2-4272-87f1-57c0b4ca5650', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4', N'Jobseeker')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10b98978-da79-4a8d-8475-58fb42d589c5', N'bb2518d8-d5a2-4272-87f1-57c0b4ca5650')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10c5c4dd-cf30-4839-a685-62a4ab4479b2', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1c66ea3c-f788-401c-9a07-eb759a55d82d', N'66b87dc2-01d4-49cf-bfb6-051a04358f6d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26e0c6ce-ef68-4584-91d3-84fd6827f25e', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'283ba2b1-b06b-445a-8e09-461d86867d55', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d04b187-250a-4d12-acfe-6fac69c20e70', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3323f625-230e-44ed-9d6c-4a902a104e57', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'368bb9fd-f3a9-4e12-8133-3d200d402864', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'46ffc708-8c2c-49f7-8be3-e8cfb4b8cc3c', N'66b87dc2-01d4-49cf-bfb6-051a04358f6d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f2172c1-5855-47e9-80dc-37c49c8ade11', N'755cd5ee-3d9e-4965-ae4e-11a57cfe1514')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f9b5f1a-710e-4efe-abf3-4e5503539b42', N'66b87dc2-01d4-49cf-bfb6-051a04358f6d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8965fbd1-ff7e-4ec9-805b-f03efe2ccb0a', N'3e373f93-33b3-4c1b-9647-6e3978fe3bff')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a8c539de-9f13-4b29-a0a0-3e113d855194', N'e07f2ea1-c258-46a5-83ad-e40f32f5bad4')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'10b98978-da79-4a8d-8475-58fb42d589c5', N'admin', N'AOO0/t0tqXgfuzD2dnxB+WLB6wOmrp6ysIRRVCAEfx0RJpXhNgcEUyDvd1yN8Yax9Q==', N'551f2e8b-b9e6-4090-a555-04db2fc2d3aa', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'10c5c4dd-cf30-4839-a685-62a4ab4479b2', N'thiennn', N'AP3lA/OdsCVx9kjdPM5oMSwNJRwFhSFxzcjQj/HK/ZktPyTcZMzF8IWaTo6zdUoqMg==', N'ef0206b5-b606-4183-abdc-a5052735d607', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'1c66ea3c-f788-401c-9a07-eb759a55d82d', N'recruitertest', N'AGtKApaEu5iv9/w87OVIZ70jkga8nrX0lPh1OF2qsBvPhxyHrbt+fDDdgcH1lHlhFA==', N'1cb79878-20cc-4cee-b6e9-6c4db7929559', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'26e0c6ce-ef68-4584-91d3-84fd6827f25e', N'jobseeker', N'AEkPwvi3gzDmWKXmNNZCygXd0ucbm/jZBHlsNnDN6XYgDuQfBywRJsKNAFWIyxRRiA==', N'd56b66ab-8ffe-46b1-bd19-4ad0ff93759b', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'283ba2b1-b06b-445a-8e09-461d86867d55', N'abc6', N'AGJBe3Om66xECOUQPizukEt6+JQrlkzYK0QIOZs0Mcecbko9RBvLE19ImnG727M17w==', N'7ecc281c-4eec-4c23-be8d-39671f75e490', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'2d04b187-250a-4d12-acfe-6fac69c20e70', N'abc', N'AAOvOYIbC0FKHc7fzColf8w10sE0fFCFhC/oRUujlPQmwA9hnALz+sIkxXXqZd7Bbw==', N'3b290a6c-f9d3-47a2-927a-a3410d033d1b', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'3323f625-230e-44ed-9d6c-4a902a104e57', N'abc3', N'APiHEqyQL11fEPAU5uQZXVi0Z7s+t6r5A0JeWQwDSY23Dz/BvdTdw8ztTnTgOXId+Q==', N'8582deca-60fd-49d2-b4e2-63ed90d62731', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'368bb9fd-f3a9-4e12-8133-3d200d402864', N'abc4', N'AGz7Q9nesq3R+/rkEG5JEzr6yuaz6UmVlXIafISCeqMVkqwkHiS1rco9iiy2O7t6XQ==', N'9f362937-74d4-42d0-adf1-675d6351dc94', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'46ffc708-8c2c-49f7-8be3-e8cfb4b8cc3c', N'recruiter', N'ADbJJDuDhKlt/ALz/HKUIGfI03jDArf10SuwkRELGofD+oLkzqzDVK6hC48zsfTHRA==', N'bd92b223-a32e-4810-909e-5326db736249', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'5f2172c1-5855-47e9-80dc-37c49c8ade11', N'manager', N'AAhiM0N33CV+cJonadwvi3fyCrdpmFRiQqxGbYn6ZD7FOrH19d1LIlFP6KRVknMypA==', N'240269c2-9f80-449d-ac3a-6f0cc0d607e3', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'5f9b5f1a-710e-4efe-abf3-4e5503539b42', N'abc5', N'AMMAWFK40okuJe6R88Gnzlv4ITWET25Wd5b+fwGOxaG4f3fels5GVkBbGhGd6SrGxg==', N'baa565a2-b870-4e35-86a6-e31a8ec8370f', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'8965fbd1-ff7e-4ec9-805b-f03efe2ccb0a', N'staff', N'ADKByVdoaAeqaBEkPw5xgvfUToNI+jxvaI0Wx+L7myq0r3qcPSpcLXLdvrE7n2c7tw==', N'df65abef-9517-4ba2-9c1c-8d89bae74ef5', N'ApplicationUser', 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [IsActive]) VALUES (N'a8c539de-9f13-4b29-a0a0-3e113d855194', N'jobseekertest', N'AOSIFBLCZLboTkPPRBuMwvq6PsEPhBJE9DAEi20Wu1n7atFRZNjAbQ79z6SaRwp3Nw==', N'864acde6-994d-44bb-907e-0318e32c36fd', N'ApplicationUser', 1)
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [IsDeleted]) VALUES (1, N'Công nghệ thông tin ', N'IT', 1)
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [IsDeleted]) VALUES (3, N'Xây dựng', N'XD', 0)
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [IsDeleted]) VALUES (1002, N'Lao công 2', N'', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityID], [Name], [IsDeleted]) VALUES (1, N'Binh Duong', 1)
INSERT [dbo].[City] ([CityID], [Name], [IsDeleted]) VALUES (2, N'Ho Chi Minh', 1)
INSERT [dbo].[City] ([CityID], [Name], [IsDeleted]) VALUES (1002, N'Long An', 0)
SET IDENTITY_INSERT [dbo].[City] OFF
INSERT [dbo].[Contact] ([UserID], [FullName], [Gender], [MaritalStatus], [Nationality], [Address], [DateofBirth], [PhoneNumber], [CityID], [District], [IsVisible]) VALUES (N'a8c539de-9f13-4b29-a0a0-3e113d855194', N'Huỳnh Đức Tài', 1, 0, 0, N'Phú Mỹ', CAST(0x3A190B00 AS Date), N'0919045146', 1, N'Thủ Dầu Một', 1)
SET IDENTITY_INSERT [dbo].[EducationHistory] ON 

INSERT [dbo].[EducationHistory] ([EducationHistoryID], [Subject], [School], [SchoolLevel_ID], [Achievement], [ProfileID], [IsDeleted]) VALUES (1, N'Kỹ nghệ phần mềm', N'FPT', 5, NULL, 4, 0)
SET IDENTITY_INSERT [dbo].[EducationHistory] OFF
SET IDENTITY_INSERT [dbo].[EmploymentHistory] ON 

INSERT [dbo].[EmploymentHistory] ([EmploymentHistoryID], [Position], [Company], [WorkingTime], [Description], [ProfileID], [IsDeleted]) VALUES (1, N'Android Dev2', N'FSOFT', 1, NULL, 4, 0)
SET IDENTITY_INSERT [dbo].[EmploymentHistory] OFF
INSERT [dbo].[ExpectedCategory] ([ProfileID], [CategoryID], [IsDeleted]) VALUES (1, 1, 0)
INSERT [dbo].[ExpectedCategory] ([ProfileID], [CategoryID], [IsDeleted]) VALUES (4, 3, 0)
INSERT [dbo].[ExpectedCity] ([ProfileID], [CityID], [IsDeleted]) VALUES (1, 2, 1)
INSERT [dbo].[ExpectedCity] ([ProfileID], [CityID], [IsDeleted]) VALUES (4, 1, 0)
SET IDENTITY_INSERT [dbo].[JobLevel] ON 

INSERT [dbo].[JobLevel] ([JobLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (1, N'Trưởng phòng', 3, 0)
INSERT [dbo].[JobLevel] ([JobLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (2, N'Trưởng khoa', 2, 0)
SET IDENTITY_INSERT [dbo].[JobLevel] OFF
INSERT [dbo].[Jobseeker] ([JobSeekerID], [Email], [IsDeleted]) VALUES (N'10c5c4dd-cf30-4839-a685-62a4ab4479b2', N'thiennn@gmail.com', 0)
INSERT [dbo].[Jobseeker] ([JobSeekerID], [Email], [IsDeleted]) VALUES (N'283ba2b1-b06b-445a-8e09-461d86867d55', N'abc@gmail.com', 0)
INSERT [dbo].[Jobseeker] ([JobSeekerID], [Email], [IsDeleted]) VALUES (N'368bb9fd-f3a9-4e12-8133-3d200d402864', N'abc@gmail.com', 0)
INSERT [dbo].[Jobseeker] ([JobSeekerID], [Email], [IsDeleted]) VALUES (N'a8c539de-9f13-4b29-a0a0-3e113d855194', N'taihdse60630@fpt.edu.vn', 0)
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([LanguageID], [Name], [IsDeleted]) VALUES (1, N'Tiếng Việt', 0)
INSERT [dbo].[Language] ([LanguageID], [Name], [IsDeleted]) VALUES (3, N'English', 0)
INSERT [dbo].[Language] ([LanguageID], [Name], [IsDeleted]) VALUES (4, N'日本語', 0)
SET IDENTITY_INSERT [dbo].[Language] OFF
SET IDENTITY_INSERT [dbo].[Level] ON 

INSERT [dbo].[Level] ([Level_ID], [Name], [LevelNum], [IsDeleted]) VALUES (1, N'Sơ cấp', 1, 0)
INSERT [dbo].[Level] ([Level_ID], [Name], [LevelNum], [IsDeleted]) VALUES (2, N'Trung cấp', 2, 0)
INSERT [dbo].[Level] ([Level_ID], [Name], [LevelNum], [IsDeleted]) VALUES (3, N'Cao cấp', 3, 0)
SET IDENTITY_INSERT [dbo].[Level] OFF
SET IDENTITY_INSERT [dbo].[Profile] ON 

INSERT [dbo].[Profile] ([ProfileID], [Name], [YearOfExperience], [HighestSchoolLevel_ID], [MostRecentCompany], [MostRecentPosition], [CurrentJobLevel_ID], [ExpectedPosition], [ExpectedJobLevel_ID], [ExpectedSalary], [CreatedTime], [UpdatedTime], [Objectives], [PercentStatus], [JobSeekerID], [IsActive], [IsDeleted]) VALUES (1, N'BrSE', 0, 5, N'FSOFT', N'Android Dev', 2, N'BrSE', 1, 12000000.0000, CAST(0x0000A4DC01688970 AS DateTime), CAST(0x0000A4DC016C01E9 AS DateTime), N'Onsite Nhật', 25, N'a8c539de-9f13-4b29-a0a0-3e113d855194', 0, 1)
INSERT [dbo].[Profile] ([ProfileID], [Name], [YearOfExperience], [HighestSchoolLevel_ID], [MostRecentCompany], [MostRecentPosition], [CurrentJobLevel_ID], [ExpectedPosition], [ExpectedJobLevel_ID], [ExpectedSalary], [CreatedTime], [UpdatedTime], [Objectives], [PercentStatus], [JobSeekerID], [IsActive], [IsDeleted]) VALUES (4, N'Xây dựng', 2, 3, NULL, NULL, NULL, N'Thợ hồ', 2, 4000000.0000, CAST(0x0000A4DC01720FDA AS DateTime), CAST(0x0000A4DC01720FDA AS DateTime), N'Có việc làm', 25, N'a8c539de-9f13-4b29-a0a0-3e113d855194', 0, 0)
SET IDENTITY_INSERT [dbo].[Profile] OFF
INSERT [dbo].[ProfileLanguage] ([LanguageID], [ProfileID], [Level_ID], [IsDeleted]) VALUES (1, 1, 3, 1)
INSERT [dbo].[ProfileLanguage] ([LanguageID], [ProfileID], [Level_ID], [IsDeleted]) VALUES (4, 4, 1, 0)
INSERT [dbo].[Recruiter] ([RecruiterID], [Email], [IsDeleted]) VALUES (N'1c66ea3c-f788-401c-9a07-eb759a55d82d', N'taihdse60630@fpt.edu.vn', 0)
INSERT [dbo].[Recruiter] ([RecruiterID], [Email], [IsDeleted]) VALUES (N'5f9b5f1a-710e-4efe-abf3-4e5503539b42', N'abc@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[SchoolLevel] ON 

INSERT [dbo].[SchoolLevel] ([SchoolLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (1, N'Trung học cơ sở', 1, 0)
INSERT [dbo].[SchoolLevel] ([SchoolLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (2, N'Trung học phổ thông', 2, 0)
INSERT [dbo].[SchoolLevel] ([SchoolLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (3, N'Nghề', 3, 0)
INSERT [dbo].[SchoolLevel] ([SchoolLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (4, N'Cao đẳng', 4, 0)
INSERT [dbo].[SchoolLevel] ([SchoolLevel_ID], [Name], [LevelNum], [IsDeleted]) VALUES (5, N'Đại học', 5, 0)
SET IDENTITY_INSERT [dbo].[SchoolLevel] OFF
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF__Resume__IsRepres__2F10007B]  DEFAULT ('false') FOR [IsActive]
GO
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD  CONSTRAINT [FK_Administrator_AspNetUsers] FOREIGN KEY([AdministratorID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Administrator] CHECK CONSTRAINT [FK_Administrator_AspNetUsers]
GO
ALTER TABLE [dbo].[AlertEmail]  WITH CHECK ADD  CONSTRAINT [FK_AlertEmail_Staff] FOREIGN KEY([Staff_ID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[AlertEmail] CHECK CONSTRAINT [FK_AlertEmail_Staff]
GO
ALTER TABLE [dbo].[AppliedJob]  WITH CHECK ADD  CONSTRAINT [FK_AppliedJob_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[AppliedJob] CHECK CONSTRAINT [FK_AppliedJob_Job]
GO
ALTER TABLE [dbo].[AppliedJob]  WITH CHECK ADD  CONSTRAINT [FK_AppliedJob_Jobseeker] FOREIGN KEY([JobSeekerID])
REFERENCES [dbo].[Jobseeker] ([JobSeekerID])
GO
ALTER TABLE [dbo].[AppliedJob] CHECK CONSTRAINT [FK_AppliedJob_Jobseeker]
GO
ALTER TABLE [dbo].[AppliedJob]  WITH CHECK ADD  CONSTRAINT [FK_AppliedJob_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[AppliedJob] CHECK CONSTRAINT [FK_AppliedJob_Profile]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_Recruiter] FOREIGN KEY([RecruiterID])
REFERENCES [dbo].[Recruiter] ([RecruiterID])
GO
ALTER TABLE [dbo].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_Recruiter]
GO
ALTER TABLE [dbo].[CompanyInfoCity]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfoCity_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[CompanyInfoCity] CHECK CONSTRAINT [FK_CompanyInfoCity_City]
GO
ALTER TABLE [dbo].[CompanyInfoCity]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfoCity_CompanyInfo] FOREIGN KEY([RecuiterID])
REFERENCES [dbo].[CompanyInfo] ([RecruiterID])
GO
ALTER TABLE [dbo].[CompanyInfoCity] CHECK CONSTRAINT [FK_CompanyInfoCity_CompanyInfo]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_AspNetUsers]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_City]
GO
ALTER TABLE [dbo].[DesiredBenefit]  WITH CHECK ADD  CONSTRAINT [FK_DesiredBenefit_Benefit] FOREIGN KEY([BenefitID])
REFERENCES [dbo].[Benefit] ([BenefitID])
GO
ALTER TABLE [dbo].[DesiredBenefit] CHECK CONSTRAINT [FK_DesiredBenefit_Benefit]
GO
ALTER TABLE [dbo].[DesiredBenefit]  WITH CHECK ADD  CONSTRAINT [FK_DesiredBenefit_Jobseeker] FOREIGN KEY([JobSeekerID])
REFERENCES [dbo].[Jobseeker] ([JobSeekerID])
GO
ALTER TABLE [dbo].[DesiredBenefit] CHECK CONSTRAINT [FK_DesiredBenefit_Jobseeker]
GO
ALTER TABLE [dbo].[EducationHistory]  WITH CHECK ADD  CONSTRAINT [FK_EducationHistory_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[EducationHistory] CHECK CONSTRAINT [FK_EducationHistory_Profile]
GO
ALTER TABLE [dbo].[EducationHistory]  WITH CHECK ADD  CONSTRAINT [FK_EducationHistory_SchoolLevel] FOREIGN KEY([SchoolLevel_ID])
REFERENCES [dbo].[SchoolLevel] ([SchoolLevel_ID])
GO
ALTER TABLE [dbo].[EducationHistory] CHECK CONSTRAINT [FK_EducationHistory_SchoolLevel]
GO
ALTER TABLE [dbo].[EmploymentHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmploymentHistory_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[EmploymentHistory] CHECK CONSTRAINT [FK_EmploymentHistory_Profile]
GO
ALTER TABLE [dbo].[ExpectedCategory]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedCategory_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[ExpectedCategory] CHECK CONSTRAINT [FK_ExpectedCategory_Category]
GO
ALTER TABLE [dbo].[ExpectedCategory]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedCategory_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ExpectedCategory] CHECK CONSTRAINT [FK_ExpectedCategory_Profile]
GO
ALTER TABLE [dbo].[ExpectedCity]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedCity_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[ExpectedCity] CHECK CONSTRAINT [FK_ExpectedCity_City]
GO
ALTER TABLE [dbo].[ExpectedCity]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedCity_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ExpectedCity] CHECK CONSTRAINT [FK_ExpectedCity_Profile]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_JobLevel] FOREIGN KEY([JobLevel_ID])
REFERENCES [dbo].[JobLevel] ([JobLevel_ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_JobLevel]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Recruiter] FOREIGN KEY([RecruiterID])
REFERENCES [dbo].[Recruiter] ([RecruiterID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Recruiter]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_SchoolLevel] FOREIGN KEY([MinSchoolLevel_ID])
REFERENCES [dbo].[SchoolLevel] ([SchoolLevel_ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_SchoolLevel]
GO
ALTER TABLE [dbo].[JobBenefit]  WITH CHECK ADD  CONSTRAINT [FK_JobBenefit_Benefit] FOREIGN KEY([BenefitID])
REFERENCES [dbo].[Benefit] ([BenefitID])
GO
ALTER TABLE [dbo].[JobBenefit] CHECK CONSTRAINT [FK_JobBenefit_Benefit]
GO
ALTER TABLE [dbo].[JobBenefit]  WITH CHECK ADD  CONSTRAINT [FK_JobBenefit_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobBenefit] CHECK CONSTRAINT [FK_JobBenefit_Job]
GO
ALTER TABLE [dbo].[JobCategory]  WITH CHECK ADD  CONSTRAINT [FK_JobCategory_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[JobCategory] CHECK CONSTRAINT [FK_JobCategory_Category]
GO
ALTER TABLE [dbo].[JobCategory]  WITH CHECK ADD  CONSTRAINT [FK_JobCategory_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobCategory] CHECK CONSTRAINT [FK_JobCategory_Job]
GO
ALTER TABLE [dbo].[JobCity]  WITH CHECK ADD  CONSTRAINT [FK_JobCity_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[JobCity] CHECK CONSTRAINT [FK_JobCity_City]
GO
ALTER TABLE [dbo].[JobCity]  WITH CHECK ADD  CONSTRAINT [FK_JobCity_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobCity] CHECK CONSTRAINT [FK_JobCity_Job]
GO
ALTER TABLE [dbo].[JobLanguage]  WITH CHECK ADD  CONSTRAINT [FK_JobLanguage_Job1] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobLanguage] CHECK CONSTRAINT [FK_JobLanguage_Job1]
GO
ALTER TABLE [dbo].[JobLanguage]  WITH CHECK ADD  CONSTRAINT [FK_JobLanguage_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[JobLanguage] CHECK CONSTRAINT [FK_JobLanguage_Language]
GO
ALTER TABLE [dbo].[JobLanguage]  WITH CHECK ADD  CONSTRAINT [FK_JobLanguage_Level] FOREIGN KEY([MinLevel_ID])
REFERENCES [dbo].[Level] ([Level_ID])
GO
ALTER TABLE [dbo].[JobLanguage] CHECK CONSTRAINT [FK_JobLanguage_Level]
GO
ALTER TABLE [dbo].[Jobseeker]  WITH CHECK ADD  CONSTRAINT [FK_Jobseeker_AspNetUsers] FOREIGN KEY([JobSeekerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Jobseeker] CHECK CONSTRAINT [FK_Jobseeker_AspNetUsers]
GO
ALTER TABLE [dbo].[JobSkill]  WITH CHECK ADD  CONSTRAINT [FK_JobSkill_Job1] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobSkill] CHECK CONSTRAINT [FK_JobSkill_Job1]
GO
ALTER TABLE [dbo].[JobSkill]  WITH CHECK ADD  CONSTRAINT [FK_JobSkill_Skill] FOREIGN KEY([Skill_ID])
REFERENCES [dbo].[Skill] ([Skill_ID])
GO
ALTER TABLE [dbo].[JobSkill] CHECK CONSTRAINT [FK_JobSkill_Skill]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_AspNetUsers] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_AspNetUsers]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_AspNetUsers] FOREIGN KEY([SenderID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_AspNetUsers]
GO
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_AspNetUsers] FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_AspNetUsers]
GO
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
GO
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_Message]
GO
ALTER TABLE [dbo].[OwnSkill]  WITH CHECK ADD  CONSTRAINT [FK_OwnSkill_Jobseeker] FOREIGN KEY([JobSeekerID])
REFERENCES [dbo].[Jobseeker] ([JobSeekerID])
GO
ALTER TABLE [dbo].[OwnSkill] CHECK CONSTRAINT [FK_OwnSkill_Jobseeker]
GO
ALTER TABLE [dbo].[OwnSkill]  WITH CHECK ADD  CONSTRAINT [FK_OwnSkill_Skill] FOREIGN KEY([Skill_ID])
REFERENCES [dbo].[Skill] ([Skill_ID])
GO
ALTER TABLE [dbo].[OwnSkill] CHECK CONSTRAINT [FK_OwnSkill_Skill]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_JobLevel] FOREIGN KEY([CurrentJobLevel_ID])
REFERENCES [dbo].[JobLevel] ([JobLevel_ID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_JobLevel]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_JobLevel1] FOREIGN KEY([ExpectedJobLevel_ID])
REFERENCES [dbo].[JobLevel] ([JobLevel_ID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_JobLevel1]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Jobseeker] FOREIGN KEY([JobSeekerID])
REFERENCES [dbo].[Jobseeker] ([JobSeekerID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_Jobseeker]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_SchoolLevel] FOREIGN KEY([HighestSchoolLevel_ID])
REFERENCES [dbo].[SchoolLevel] ([SchoolLevel_ID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_SchoolLevel]
GO
ALTER TABLE [dbo].[ProfileLanguage]  WITH CHECK ADD  CONSTRAINT [FK_ProfileLanguage_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[ProfileLanguage] CHECK CONSTRAINT [FK_ProfileLanguage_Language]
GO
ALTER TABLE [dbo].[ProfileLanguage]  WITH CHECK ADD  CONSTRAINT [FK_ProfileLanguage_Level] FOREIGN KEY([Level_ID])
REFERENCES [dbo].[Level] ([Level_ID])
GO
ALTER TABLE [dbo].[ProfileLanguage] CHECK CONSTRAINT [FK_ProfileLanguage_Level]
GO
ALTER TABLE [dbo].[ProfileLanguage]  WITH CHECK ADD  CONSTRAINT [FK_ProfileLanguage_Profile] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ProfileLanguage] CHECK CONSTRAINT [FK_ProfileLanguage_Profile]
GO
ALTER TABLE [dbo].[PurchaseAdvertise]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseAdvertise_Advertise] FOREIGN KEY([AdvertiseID])
REFERENCES [dbo].[Advertise] ([AdvertiseID])
GO
ALTER TABLE [dbo].[PurchaseAdvertise] CHECK CONSTRAINT [FK_PurchaseAdvertise_Advertise]
GO
ALTER TABLE [dbo].[PurchaseAdvertise]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseAdvertise_Manager] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Manager] ([ManagerID])
GO
ALTER TABLE [dbo].[PurchaseAdvertise] CHECK CONSTRAINT [FK_PurchaseAdvertise_Manager]
GO
ALTER TABLE [dbo].[PurchaseAdvertise]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseAdvertise_Recruiter] FOREIGN KEY([RecuiterID])
REFERENCES [dbo].[Recruiter] ([RecruiterID])
GO
ALTER TABLE [dbo].[PurchaseAdvertise] CHECK CONSTRAINT [FK_PurchaseAdvertise_Recruiter]
GO
ALTER TABLE [dbo].[PurchaseJobPackage]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseJobPackage_JobPackage] FOREIGN KEY([JobPackageID])
REFERENCES [dbo].[JobPackage] ([JobPackageID])
GO
ALTER TABLE [dbo].[PurchaseJobPackage] CHECK CONSTRAINT [FK_PurchaseJobPackage_JobPackage]
GO
ALTER TABLE [dbo].[PurchaseJobPackage]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseJobPackage_Recruiter] FOREIGN KEY([RecruiterID])
REFERENCES [dbo].[Recruiter] ([RecruiterID])
GO
ALTER TABLE [dbo].[PurchaseJobPackage] CHECK CONSTRAINT [FK_PurchaseJobPackage_Recruiter]
GO
ALTER TABLE [dbo].[PurchaseJobPackage]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseJobPackage_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[PurchaseJobPackage] CHECK CONSTRAINT [FK_PurchaseJobPackage_Staff]
GO
ALTER TABLE [dbo].[Recruiter]  WITH CHECK ADD  CONSTRAINT [FK_Recruiter_AspNetUsers] FOREIGN KEY([RecruiterID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Recruiter] CHECK CONSTRAINT [FK_Recruiter_AspNetUsers]
GO
ALTER TABLE [dbo].[ReferencePerson]  WITH CHECK ADD  CONSTRAINT [FK_ReferencePerson_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ReferencePerson] CHECK CONSTRAINT [FK_ReferencePerson_Profile]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_AspNetUsers] FOREIGN KEY([SenderID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_AspNetUsers]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_AspNetUsers1] FOREIGN KEY([SolvedUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_AspNetUsers1]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_AspNetUsers] FOREIGN KEY([StaffID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_AspNetUsers]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_AspNetUsers] FOREIGN KEY([WriterID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_AspNetUsers]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Staff] FOREIGN KEY([UpdatedStaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Staff]
GO
ALTER TABLE [dbo].[ViewProfile]  WITH CHECK ADD  CONSTRAINT [FK_ViewProfile_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ViewProfile] CHECK CONSTRAINT [FK_ViewProfile_Profile]
GO
ALTER TABLE [dbo].[ViewProfile]  WITH CHECK ADD  CONSTRAINT [FK_ViewProfile_Recruiter] FOREIGN KEY([RecruiterID])
REFERENCES [dbo].[Recruiter] ([RecruiterID])
GO
ALTER TABLE [dbo].[ViewProfile] CHECK CONSTRAINT [FK_ViewProfile_Recruiter]
GO
