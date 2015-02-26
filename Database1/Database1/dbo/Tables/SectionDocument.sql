CREATE TABLE [dbo].[SectionDocument] (
    [SectionId]   BIGINT        NOT NULL,
    [DocumentId]  BIGINT        NOT NULL,
    [Description] VARCHAR (100) NULL,
    CONSTRAINT [PK_SectionDocument] PRIMARY KEY CLUSTERED ([SectionId] ASC, [DocumentId] ASC)
);

