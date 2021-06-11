﻿-- <Migration ID="099d5119-8dcd-4cb1-85a0-05a2937cf834" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Load data into pubs tables
**************************************************************************/
insert dbo.titles_xref_authors(author_id,author_code,title_id,title_code,author_order,royaltyper)
VALUES
(1,'409-56-7008', 2,'BU1032', 1, 60)
,(21,'486-29-1786', 3,'PS7777', 1, 100)
,(21,'486-29-1786', 18,'PC9999', 1, 100)
,(19,'712-45-1867', 6,'MC2222', 1, 100)
,(18,'172-32-1176', 4,'PS3333', 1, 100)
,(2,'213-46-8915', 2,'BU1032', 2, 40)
,(3,'238-95-7766', 9,'PC1035', 1, 100)
,(2,'213-46-8915', 10,'BU2075', 1, 100)
,(4,'998-72-3567', 11,'PS2091', 1, 50)
,(5,'899-46-2035', 11,'PS2091', 2, 50)
,(4,'998-72-3567', 12,'PS2106', 1, 100)
,(6,'722-51-5454', 13,'MC3021', 1, 75)
,(5,'899-46-2035', 13,'MC3021', 2, 25)
,(7,'807-91-6654', 14,'TC3218', 1, 100)
,(10,'274-80-9391', 16,'BU7832', 1, 100)
,(13,'427-17-2319', 1,'PC8888', 1, 50)
,(20,'846-92-7186', 1,'PC8888', 2, 50)
,(11,'756-30-7391', 17,'PS1372', 1, 75)
,(12,'724-80-9391', 17,'PS1372', 2, 25)
,(12,'724-80-9391', 5,'BU1111', 1, 60)
,(15,'267-41-2394', 5,'BU1111', 2, 40)
,(14,'672-71-3249', 7,'TC7777', 1, 40)
,(15,'267-41-2394', 7,'TC7777', 2, 30)
,(16,'472-27-2349', 7,'TC7777', 3, 30)
,(22,'648-92-1872', 8,'TC4203', 1, 100)
