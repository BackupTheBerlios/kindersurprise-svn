CREATE TABLE tPicture
(
	Id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
	FullPath varchar(400) NOT NULL
) ENGINE = InnoDB;

INSERT INTO CHECK_UPDATES(CREATION_DATE, SCRIPT_NAME, SCRIPT_PURPOSE)
VALUES(NOW(), '20100826_create_Table_tPicture', 'create table to save pictures to every Serie and Figur');
