CREATE TABLE Photo
(
	PhotoId INT IDENTITY(1,1) PRIMARY KEY,
	TrainingId INT,
	Photo VARBINARY (MAX) NULL,

	CONSTRAINT FK_Photo_Training FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId)
)