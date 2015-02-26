CREATE TABLE [dbo].[Tag] (
    [TagId]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [TagName]      VARCHAR (50)  NOT NULL,
    [CreationDate] DATETIME2 (7) CONSTRAINT [DF_Tag_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([TagId] ASC)
);

