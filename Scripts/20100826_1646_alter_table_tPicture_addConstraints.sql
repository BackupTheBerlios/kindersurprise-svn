ALTER TABLE tPicture ADD FK_Serie_ID int;

ALTER TABLE tPicture
ADD CONSTRAINT FK_Picture_Serie 
	FOREIGN KEY (FK_Serie_ID ) 
	REFERENCES tSerie (SerieId);

ALTER TABLE tPicture ADD FK_Figur_ID int;

ALTER TABLE tPicture
ADD CONSTRAINT FK_Picture_Figur FOREIGN KEY (FK_Figur_ID)
	REFERENCES tFigur (FigurId);

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100826_1646_alter_Table_TPicture_AddConstraints', 'add constraints to tSerie and tFigur');
