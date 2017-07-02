CREATE TABLE [dbo].[People] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [RegistredOn] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

