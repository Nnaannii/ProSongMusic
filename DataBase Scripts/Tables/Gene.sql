CREATE TABLE [dbo].[Gene] (
    [Gene_ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Gene_ID] ASC)
);

