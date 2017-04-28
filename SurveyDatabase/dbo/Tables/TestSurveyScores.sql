CREATE TABLE [dbo].[TestSurveyScores] (
    [ID] INT            IDENTITY (1, 1) NOT NULL,
    [SurveyAnswerID] INT    NOT NULL,
	[SurveyQuestionID] INT NOT NULL,
    [Rating]          INT NOT NULL,    
    CONSTRAINT [PK_TestSurveyScores] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TestSurveyScores_TestSurveyAnswers] FOREIGN KEY ([SurveyAnswerID]) REFERENCES [dbo].[TestSurveyAnswers] ([SurveyAnswerID])	
);