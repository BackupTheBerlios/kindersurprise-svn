ALTER TABLE tPicture ADD FK_Instructions_ID int;

ALTER TABLE tPicture
	ADD CONSTRAINT FK_Picture_Instructions FOREIGN KEY (FK_Instructions_ID)
	REFERENCES tInstructions (Id);

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100828_2210_alter_table_tPicture_addtInstructions', 'alter table tPicture to save also Instructionspictures in the database');
