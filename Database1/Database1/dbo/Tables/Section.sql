CREATE TABLE [dbo].[Section] (
    [SectionId]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [SectionName]        VARCHAR (50)  NOT NULL,
    [SectionDescription] VARCHAR (MAX) NULL,
    [UserId]             BIGINT        NULL,
    [CreationDate]       DATETIME2 (7) NOT NULL,
    [SectionTypeId]      BIGINT        NULL,
    CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED ([SectionId] ASC),
    CONSTRAINT [FK_Section_SectionType] FOREIGN KEY ([SectionTypeId]) REFERENCES [dbo].[SectionType] ([SectionTypeId]),
    CONSTRAINT [FK_Section_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

