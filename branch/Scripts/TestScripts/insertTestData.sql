INSERT INTO tCategory
           (CategoryId
           ,CategoryName
           ,Description)
     VALUES
           (1
           ,'Plastik'
           ,'Alles was plaste ist')
;

INSERT INTO tCategory
           (CategoryId
           ,CategoryName
           ,Description)
     VALUES
           (2
           ,'Figur'
           ,'Alle Figuren')
;

INSERT INTO tCategory
           (CategoryId
           ,CategoryName
           ,Description)
     VALUES
           (3
           ,'Zinn'
           ,'Zinnfiguren')
;


INSERT INTO tSerie
           (SerieId
           ,SerieName
           ,Description
           ,PublicationYear
           ,FK_Category_ID)
     VALUES
           (1
           ,'Plaste1'
           ,'Plasteserie 1'
           ,'20080101'
           ,1)
;

INSERT INTO tSerie
           (SerieId
           ,SerieName
           ,Description
           ,PublicationYear
           ,FK_Category_ID)
     VALUES
           (2
           ,'Plaste2'
           ,'Plasteserie 2'
           ,'20080102'
           ,1)
;

INSERT INTO tSerie
           (SerieId
           ,SerieName
           ,Description
           ,PublicationYear
           ,FK_Category_ID)
     VALUES
           (3
           ,'Figuren1'
           ,'Figurenserie 1'
           ,'20080103'
           ,2)
;

INSERT INTO tSerie
           (SerieId
           ,SerieName
           ,Description
           ,PublicationYear
           ,FK_Category_ID)
     VALUES
           (4
           ,'Figuren2'
           ,'Figurenserie 2'
           ,'20080104'
           ,2)
;

INSERT INTO tSerie
           (SerieId
           ,SerieName
           ,Description
           ,PublicationYear
           ,FK_Category_ID)
     VALUES
           (5
           ,'Zinnfiguren'
           ,'Zinnserie'
           ,'20080105'
           ,3)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (1
           ,'PlasteFigur1'
           ,'Plastefigur Serie1'
           ,18.00
           ,1)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (2
           ,'PlasteFigur2'
           ,'Plastefigur Serie1'
           ,9.25
           ,1)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (3
           ,'PlasteFigur1'
           ,'Plastefigur Serie2'
           ,11.00
           ,2)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (4
           ,'PlasteFigur2'
           ,'Plastefigur Serie2'
           ,4.75
           ,2)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (5
           ,'Happy Hippo1'
           ,'Figur'
           ,5.11
           ,3)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (6
           ,'Happy Hippo2'
           ,'Figur'
           ,5.00
           ,3)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (7
           ,'Happy Hippo3'
           ,'Figur'
           ,5.11
           ,3)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (8
           ,'Mr. Sonnenschein'
           ,'Figur'
           ,11.00
           ,4)
;

INSERT INTO tFigur
           (FigurId
           ,FigurName
           ,Description
           ,Price
           ,FK_Serie_ID)
     VALUES
           (9
           ,'Zinnsoldat'
           ,'Zinnfigur'
           ,0.77
           ,5)
;

INSERT INTO tPicture (Id, FullPath, FK_Serie_ID, FK_Figur_ID) VALUES
(1, '1.jpg', 5, NULL),
(2, '2.jpg', NULL, 3),
(3, '3.jpg', NULL, 5),
(4, '4.jpg', NULL, 5);

INSERT INTO `tInstructions` (`Id`, `Name`, `FK_Figur_ID`) VALUES ('1', 'instructions1', '8'), ('2', 'instruction2', '3');

INSERT INTO `tPicture` (`Id`, `FullPath`, `FK_Serie_ID`, `FK_Figur_ID`, `FK_Instructions_ID`) 
VALUES 	('5', 'instructions1.png', NULL, NULL, '1'), 
	('6', 'instructions2.png', NULL, NULL, '2');
