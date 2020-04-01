CREATE TABLE [dbo].[Company]
(
	[Id] BIGINT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[Vat] VARCHAR(12) NOT NULL,
	[MainAddressId] BIGINT NOT NULL,
	CONSTRAINT AK_Company UNIQUE(Vat),
	CONSTRAINT [FK_Company_Address] FOREIGN KEY ([MainAddressId]) REFERENCES [Address]([Id])
)
