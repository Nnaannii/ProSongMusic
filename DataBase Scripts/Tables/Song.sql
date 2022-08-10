CREATE TABLE [dbo].[Song] (
    [Song_ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (MAX) NULL,
    [Song_Group] NVARCHAR (MAX) NULL,
    [Song_Year]  NVARCHAR (10)  NULL,
    [Gene]       NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Song_ID] ASC)
);

