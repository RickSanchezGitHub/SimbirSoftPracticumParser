CREATE TABLE [dbo].[Urls] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Url] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Urls] PRIMARY KEY CLUSTERED ([Id] ASC)
);

