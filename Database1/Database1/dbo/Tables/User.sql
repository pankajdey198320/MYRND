CREATE TABLE [dbo].[User] (
    [UserName] VARCHAR (50) NULL,
    [Password] VARCHAR (50) NULL,
    [IsActive] BIT          NULL,
    [UserId]   BIGINT       IDENTITY (1, 1) NOT NULL,
    [PersonId] BIGINT       NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);

