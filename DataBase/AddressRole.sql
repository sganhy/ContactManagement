CREATE TABLE [dbo].[AddressRole]
(
	[Id] BIGINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[AddressId] BIGINT NOT NULL,
	[CompanyId] BIGINT NOT NULL,
	CONSTRAINT AK_AddressRole UNIQUE(AddressId, CompanyId),
	CONSTRAINT [FK_AddressRole_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
	CONSTRAINT [FK_AddressRole_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id])
)
