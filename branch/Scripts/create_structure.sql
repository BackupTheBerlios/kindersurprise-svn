CREATE TABLE CHECK_UPDATES
(
	CREATION_DATE DATETIME NOT NULL,
	SCRIPT_NAME VARCHAR(100) NULL,
	SCRIPT_PURPOSE VARCHAR(4000) NULL
) ENGINE = InnoDB;

 
INSERT INTO CHECK_UPDATES (CREATION_DATE,SCRIPT_NAME,SCRIPT_PURPOSE) 
VALUES (NOW(),
	'2009 10 16 11 17 create table check_updates',
	'create table check_updates'
);

CREATE TABLE tCategory
(
	CategoryId INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	CategoryName VARCHAR(150) NOT NULL,
	Description VARCHAR(4000) NULL
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES (CREATION_DATE,SCRIPT_NAME,SCRIPT_PURPOSE) 
VALUES (NOW(),
	'2009 10 16 11 18 create table tCategory',
	'create table Category'
);

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

CREATE TABLE tFigur
(
	FigurId INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	FigurName VARCHAR(150) NOT NULL,
	Description VARCHAR(4000) NULL,
	Price DECIMAL(18, 2) NULL,
	FK_Serie_ID INT NOT NULL,
 	CONSTRAINT FK_Figur_Serie FOREIGN KEY
	(
		FK_Serie_ID
	) REFERENCES tSerie
	(
		SerieId
	)
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES (CREATION_DATE,SCRIPT_NAME,SCRIPT_PURPOSE) 
VALUES (NOW(),
	'2009 10 16 11 20 create table tFigur', 
	'create table Figur'
);

CREATE TABLE tPicture
(
	Id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
	FullPath varchar(400) NOT NULL
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100826_create_Table_tPicture', 'create table to save pictures to every Serie and Figur');

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

ALTER TABLE tPicture ADD FK_Instructions_ID int;

ALTER TABLE tPicture
	ADD CONSTRAINT FK_Picture_Instructions FOREIGN KEY (FK_Instructions_ID)
	REFERENCES tInstructions (Id);

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100828_2210_alter_table_tPicture_addtInstructions', 'alter table tPicture to save also Instructionspictures in the database');
