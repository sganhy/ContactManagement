CREATE TABLE [dbo].[ContactRole]
(
	[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[CompanyId] BIGINT NOT NULL,
	[ContactId] BIGINT NOT NULL,
    CONSTRAINT AK_ContactRole UNIQUE(CompanyId, ContactId),
	CONSTRAINT [FK_ContactRole_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id]),
	CONSTRAINT [FK_ContactRole_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id])
)
