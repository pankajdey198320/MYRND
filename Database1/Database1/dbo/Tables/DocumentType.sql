CREATE TABLE [dbo].[DocumentType] (
    [DocumentTypeId]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [DocumentTypeName]        VARCHAR (MAX) NOT NULL,
    [DocumentTypeDescription] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED ([DocumentTypeId] ASC)
);

