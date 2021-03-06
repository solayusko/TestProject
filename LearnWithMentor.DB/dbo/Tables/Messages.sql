﻿CREATE TABLE Messages
(
    Id INT IDENTITY,
	UserTask_Id INT NOT NULL,
    User_Id INT NOT NULL,
    Text NVARCHAR(1000) NOT NULL,
    Send_Time DATETIME,

CONSTRAINT PK_Masssage_Id PRIMARY KEY (Id),
CONSTRAINT FK_Masssage_To_Users FOREIGN KEY (User_Id)  REFERENCES Users (Id),
CONSTRAINT FK_Masssage_To_UserTasks FOREIGN KEY (UserTask_Id)  REFERENCES UserTasks (Id)
)
GO
CREATE TRIGGER T_Insert_Messages
ON Messages AFTER INSERT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM INSERTED) OR (TRIGGER_NESTLEVEL() > 1)
		RETURN
	UPDATE Messages
	SET Send_Time = GETDATE()
	WHERE Id IN (SELECT Id FROM INSERTED)
END;
