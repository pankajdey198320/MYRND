CREATE TABLE [dbo].[SectionTag] (
    [SectionTagId] BIGINT        NOT NULL,
    [SectionId]    BIGINT        NULL,
    [TagId]        BIGINT        NULL,
    [CreationDate] DATETIME2 (7) CONSTRAINT [DF_SectionTag_CreationDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_SectionTag] PRIMARY KEY CLUSTERED ([SectionTagId] ASC),
    CONSTRAINT [FK_sectiontag_section] FOREIGN KEY ([SectionTagId]) REFERENCES [dbo].[Section] ([SectionId]),
    CONSTRAINT [FK_sectiontag_Tag] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([TagId])
);

