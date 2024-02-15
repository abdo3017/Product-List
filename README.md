# Product-List
- ## Backend  side i used some Topics:
 - ### 3 Tiers architecture
 - ### Action Filter for validate body serialzation
 - ### Exeption Filter
 - ### DI for services
 - ### Repository pattern
 - ### EF Core
 - ### clean code

- ## frontend(angular) side i used some Topics:
 - ### HttpService
 - ### NGPrime
 - ### clean code

## How to Setup backend Project?
- ### Update **DefaultConnection** in **ConnectionStrings** sections and **connectionString** in **Serilog** section with yor database connection string in the **appsettings.json** file
- ### Run the below SQL script in your database

```sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Logs]   ******/
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[AvailableAmount] [int] NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[SellerId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

```

## How to use APIs?
### Throw postman collection [URL](https://documenter.getpostman.com/view/9247279/2sA2r6Y4w2) you can run any end point with custom data
