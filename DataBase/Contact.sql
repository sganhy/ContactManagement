CREATE TABLE [dbo].[Contact]
(
	[Id] BIGINT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NULL,
    [Vat] VARCHAR(12) NULL,
    [MainAddressId] BIGINT NOT NULL,
    CONSTRAINT [FK_Contact_Address] FOREIGN KEY ([MainAddressId]) REFERENCES [Address]([Id])
)

