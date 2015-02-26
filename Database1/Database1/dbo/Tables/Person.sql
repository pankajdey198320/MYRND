CREATE TABLE [dbo].[Person] (
    [PersonId]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NULL,
    [MiddleName]   VARCHAR (50)  NULL,
    [LastName]     VARCHAR (50)  NULL,
    [DOB]          DATETIME2 (7) NULL,
    [Sex]          CHAR (2)      NULL,
    [CreationDate] DATETIME2 (7) NULL,
    [CreatedBy]    BIGINT        NULL,
    [Email]        VARCHAR (150) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

