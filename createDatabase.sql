CREATE DATABASE Tutor
GO

USE Tutor

CREATE TABLE [dbo].[table_DayLesson] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [Day_Lesson] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[trial_lesson] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50) NOT NULL,
    [Phone] NVARCHAR (50) NOT NULL,
    [Email] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [Patronymic] NVARCHAR (50) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    [Phone]      NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users_TimeLesson] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [User_ID]     INT      NOT NULL,
    [Time_Lesson] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

