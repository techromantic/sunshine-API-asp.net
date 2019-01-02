﻿CREATE TABLE [dbo].[Tasks] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY CONSTRAINT DF_Tasks_Id DEFAULT ( NEWID ( ) )
	,Title NVARCHAR ( 200 ) NOT NULL
	,TaskTypeId TINYINT NOT NULL
	,TaskStatusId TINYINT NOT NULL
	,UserId NVARCHAR ( 128 ) NOT NULL
	,TaskPriority TINYINT
	,Notes NVARCHAR ( MAX )
	,IsDeleted BIT NOT NULL CONSTRAINT DF_Tasks_IsDeleted DEFAULT ( 0 )
	,CreatedDate DATETIME NOT NULL CONSTRAINT DF_Tasks_CreatedDate DEFAULT ( GETDATE ( ) )
	,CreatedBy NVARCHAR ( 50 ) NOT NULL CONSTRAINT DF_Tasks_CreatedBy DEFAULT ( SYSTEM_USER )
	,UpdatedDate DATETIME NOT NULL CONSTRAINT DF_Tasks_UpdatedDate DEFAULT ( GETDATE ( ) )
	,UpdatedBy NVARCHAR ( 50 ) NOT NULL CONSTRAINT DF_Tasks_UpdatedBy DEFAULT ( SYSTEM_USER )
	,CONSTRAINT FK_Tasks_TaskTypeId FOREIGN KEY ( TaskTypeId ) REFERENCES dbo.TaskTypes ( Id )
	,CONSTRAINT FK_Tasks_TaskStatusId FOREIGN KEY ( TaskStatusId ) REFERENCES dbo.TaskStatus ( Id )
	,CONSTRAINT FK_Tasks_UserId FOREIGN KEY ( UserId ) REFERENCES dbo.AspNetUsers ( Id )
);