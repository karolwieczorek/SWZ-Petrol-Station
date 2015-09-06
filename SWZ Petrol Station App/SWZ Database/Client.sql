CREATE TABLE [dbo].[Client]
(
	[CLI_id] INT NOT NULL PRIMARY KEY,
	[PER_id] INT NOT NULL,
	[CLI_password] VARCHAR(12),
	[CLI_registration] DATETIME,
	[CLI_PESEL_REGON] INT 
)
