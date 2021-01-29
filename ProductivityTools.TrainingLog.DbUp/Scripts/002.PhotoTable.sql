CREATE TABLE Photograph
(
	PhotoId INT IDENTITY(1,1) PRIMARY KEY,
	TrainingId INT,
	PhotographFileHash VARBINARY (MAX) NULL,
	PhotographFile VARBINARY (MAX) NULL,

	CONSTRAINT FK_Photo_Training FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId)
)