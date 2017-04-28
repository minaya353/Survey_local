CREATE TABLE [dbo].[TestSurveyQuestions] (
    [SurveyQuestionID] INT            IDENTITY (1, 1) NOT NULL,
    [Text]             NVARCHAR (512) NOT NULL,
    [IsActive]         BIT            NOT NULL,
    [Titles]           NVARCHAR (256) NULL,
    [Title]            NVARCHAR (256) NULL,
    [IsRequired]       BIT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TestSurveyQuestions] PRIMARY KEY CLUSTERED ([SurveyQuestionID] ASC)
);