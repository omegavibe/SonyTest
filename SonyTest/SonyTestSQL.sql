use SonyTest

CREATE TABLE [dbo].[Customer]
(
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	CONSTRAINT [PK_CustomerId] PRIMARY KEY (CustomerId)
)
GO


CREATE TABLE [dbo].[Distributor]
(
	[DistributorId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	CONSTRAINT [PK_DistributorId] PRIMARY KEY ([DistributorId])
)
GO

CREATE TABLE [dbo].[Order]
(
	[OrderId] [uniqueidentifier] NOT NULL DEFAULT newid(),
	[CustomerId] [int] NOT NULL,
	[DistributorId] [int] NOT NULL,
	[CustomerPO] [nvarchar](250) NOT NULL,
	[POValue] [decimal](18,2) NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[DueDate] [DateTime2] NULL,
	[Description] [nvarchar](max) NULL,
	CONSTRAINT [PK_OrderId] PRIMARY KEY ([OrderId]),
	CONSTRAINT [FK_OrderId_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
	CONSTRAINT [FK_OrderId_DistributorId] FOREIGN KEY ([DistributorId]) REFERENCES [dbo].[Distributor]([DistributorId]),
)
GO

CREATE TABLE [dbo].[OrderLocale]
(
	[OrderLocaleId] [uniqueidentifier]  NOT NULL DEFAULT newid(),
	[OrderId] [uniqueidentifier] NOT NULL,
	[LocaleValue] [nvarchar](100) NOT NULL,
	[Territory] [nvarchar](100) NOT NULL,
	[Language] [nvarchar](100) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	CONSTRAINT [PK_OrderLocaleId] PRIMARY KEY ([OrderLocaleId]),
	CONSTRAINT [FK_OrderLocaleId_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
)
GO

INSERT INTO [Customer] 
(CustomerId, Name)
VALUES
(1, 'Sony Pictures Entertainment'),
(2, 'BBCW'),
(3, 'Warner Bros.'),
(4, 'Paramount Pictures'),
(5, 'Village Roadshow')
GO

INSERT INTO [Distributor] 
(DistributorId, Name)
VALUES
(1, 'Netflix'),
(2, 'Hulu'),
(3, 'AB Svensk'),
(4, 'Amazon'),
(5, 'TV Azteca')
GO
