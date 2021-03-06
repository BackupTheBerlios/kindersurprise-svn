CREATE TABLE tSerie
(
	SerieId INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	SerieName VARCHAR(150) NOT NULL,
	Description VARCHAR(4000) NULL,
	PublicationYear DATETIME NULL,
	FK_Category_ID INT Not Null,
 	CONSTRAINT FK_Serie_Category FOREIGN KEY
	(
		FK_Category_ID
	) REFERENCES tCategory
	(
		CategoryId
	)
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES (CREATION_DATE,SCRIPT_NAME,SCRIPT_PURPOSE) 
VALUES (NOW(),
	'2009 10 16 11 19 create table tSerie', 
	'create table Serie'
);
