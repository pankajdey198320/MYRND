CREATE TABLE [dbo].[Document] (
    [DocumentId]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [DocumentName]      NVARCHAR (50)   NOT NULL,
    [DocumentTypeId]    BIGINT          NOT NULL,
    [CreatedDate]       DATETIME2 (7)   NOT NULL,
    [CreatedBy]         BIGINT          NOT NULL,
    [DocumentData]      VARBINARY (MAX) NULL,
    [DocumentExtension] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([DocumentId] ASC),
    CONSTRAINT [FK_Document_DocumentType] FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentType] ([DocumentTypeId]),
    CONSTRAINT [FK_Document_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([UserId])
);

