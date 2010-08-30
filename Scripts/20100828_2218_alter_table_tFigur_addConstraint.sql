ALTER TABLE tPicture ADD FK_Instructions_ID int;

ALTER TABLE tPicture
	ADD CONSTRAINT FK_Instructions_Picture FOREIGN KEY (FK_Instructions_ID)
	REFERENCES tInstructions (Id);

