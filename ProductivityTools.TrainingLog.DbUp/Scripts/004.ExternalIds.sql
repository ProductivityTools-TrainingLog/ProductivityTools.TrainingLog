CREATE TABLE TrainingExternalId
(
	TrainingId INT IDENTITY(1,1),
	Application VARCHAR(100),
	[Key] VARCHAR(100),

	CONSTRAINT PK_TrainingExternalId PRIMARY KEY (TrainingId,Application),
	CONSTRAINT FK_TrainingExternalId_Training FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId)
)
