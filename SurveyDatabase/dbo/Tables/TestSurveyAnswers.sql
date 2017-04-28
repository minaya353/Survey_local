CREATE TABLE [dbo].[TestSurveyAnswers] (
    [SurveyAnswerID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (256) NOT NULL,
    [Email]           NVARCHAR (256) NULL,
	[Age]       INT            NOT NULL,
	[Gender]    NVARCHAR(256) NOT NULL,
	[Country]   NVARCHAR(256) NOT NULL,
    [Comment]            NVARCHAR (512) NULL,    
    CONSTRAINT [PK_TestSurveyAnswers] PRIMARY KEY CLUSTERED ([SurveyAnswerID] ASC)
);