CREATE TABLE tInstructions
(
	Id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
	Name varchar(200) NULL,
	FK_Figur_ID int,
	CONSTRAINT FK_Figur_Instructions FOREIGN KEY (FK_Figur_ID)
	REFERENCES tFigur (FigurId)
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100828_2205_create_Table_tInstructions', 'create table to save instructions');
