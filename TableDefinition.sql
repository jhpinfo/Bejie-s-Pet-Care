CREATE TABLE [dbo].[Pets] (
    [Id]       INT           NOT NULL,
    [Name]     VARCHAR (50)  NOT NULL,
    [IsOnCare] BIT           NOT NULL,
    [Notes]    VARCHAR (200) not NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

