﻿CREATE TABLE [dbo].[TaskStatus]
(
	[Id] TINYINT NOT NULL PRIMARY KEY IDENTITY ( 1, 1 )
	,TaskStatus NVARCHAR ( 50 ) NOT NULL
	,IsActive BIT NOT NULL CONSTRAINT DF_TaskStatus_IsActive DEFAULT ( 1 )
	,CreatedDate DATETIME NOT NULL CONSTRAINT DF_TaskStatus_CreatedDate DEFAULT ( GETDATE ( ) )
	,CreatedBy NVARCHAR ( 50 ) NOT NULL CONSTRAINT DF_TaskStatus_CreatedBy DEFAULT ( SYSTEM_USER )
	,UpdatedDate DATETIME NOT NULL CONSTRAINT DF_TaskStatus_UpdatedDate DEFAULT ( GETDATE ( ) )
	,UpdatedBy NVARCHAR ( 50 ) NOT NULL CONSTRAINT DF_TaskStatus_UpdatedBy DEFAULT ( SYSTEM_USER )
	,CONSTRAINT UK_TaskStatus_TaskStatus UNIQUE ( TaskStatus )
)