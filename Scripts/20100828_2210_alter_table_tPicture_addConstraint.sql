ALTER TABLE tPicture
	ADD CONSTRAINT FK_Figur_Instructions FOREIGN KEY (FK_Figur_ID)
	REFERENCES tFigur (FigurId);

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100828_2210_alter_table_tPicture_addtInstructions', 'alter table tPicture to save also Instructionspictures in the database');
