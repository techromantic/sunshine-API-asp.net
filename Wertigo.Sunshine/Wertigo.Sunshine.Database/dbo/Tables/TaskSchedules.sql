CREATE TABLE [dbo].[TaskSchedules]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY CONSTRAINT DF_TaskSchedules_Id DEFAULT ( NEWID ( ) )
	,TaskId UNIQUEIDENTIFIER NOT NULL
	,FrequencyType SMALLINT
	,FrequencyInterval SMALLINT
	,StartDate DATE
	,Duration FLOAT NOT NULL
	,CONSTRAINT FK_TaskSchedules_TaskId FOREIGN KEY ( TaskId ) REFERENCES dbo.Tasks ( Id )
)