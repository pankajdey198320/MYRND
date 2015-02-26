CREATE TABLE [dbo].[SectionType] (
    [SectionTypeId]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [SectionTypeName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_SectionType] PRIMARY KEY CLUSTERED ([SectionTypeId] ASC)
);

