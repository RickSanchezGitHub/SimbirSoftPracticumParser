CREATE TABLE [dbo].[WordsStatistics] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UrlId] INT           NOT NULL,
    [Word]  NVARCHAR (50) NOT NULL,
    [Count] INT           NOT NULL,
    CONSTRAINT [PK_WordsStatistics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WordsStatistics_Urls] FOREIGN KEY ([UrlId]) REFERENCES [dbo].[Urls] ([Id])
);

