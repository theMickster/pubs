﻿-- <Migration ID="55dca4a2-09e5-40ef-886f-b733eb2d411c" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Load data into pubs tables
**************************************************************************/

SET IDENTITY_INSERT dbo.titles ON;

insert dbo.titles(title_id,title_code,title,title_type,publisher_id,publisher_code,price,advance,royalty,year_to_date_sales,notes,published_date)
values 
(1,'PC8888', 'Secrets of Silicon Valley', 'popular_comp', 3,'1389',$20.00, $8000.00, 10, 4095,'Muckraking reporting on the world''s largest computer hardware and software manufacturers.','06/12/94')
,(2,'BU1032', 'The Busy Executive''s Database Guide', 'business',3,'1389', $19.99, $5000.00, 10, 4095,'An overview of available database systems with emphasis on common business applications. Illustrated.','06/12/91')
,(3,'PS7777', 'Emotional Security: A New Algorithm', 'psychology',1,'0736', $7.99, $4000.00, 10, 3336,'Protecting yourself and your loved ones from undue emotional stress in the modern world. Use of computer and nutritional aids emphasized.','06/12/91')
,(4,'PS3333', 'Prolonged Data Deprivation: Four Case Studies','psychology',1,'0736', $19.99, $2000.00, 10, 4072,'What happens when the data runs dry?  Searching evaluations of information-shortage effects.','06/12/91')
,(5,'BU1111', 'Cooking with Computers: Surreptitious Balance Sheets','business', 3,'1389', $11.95, $5000.00, 10, 3876,'Helpful hints on how to use your electronic resources to the best advantage.','06/09/91')
,(6,'MC2222', 'Silicon Valley Gastronomic Treats', 'mod_cook', 2,'0877',$19.99, $0.00, 12, 2032,'Favorite recipes for quick, easy, and elegant meals.','06/09/91')
,(7,'TC7777', 'Sushi, Anyone?', 'trad_cook', 2,'0877', $14.99, $8000.00,10, 4095,'Detailed instructions on how to make authentic Japanese sushi in your spare time.','06/12/91')
,(8,'TC4203', 'Fifty Years in Buckingham Palace Kitchens', 'trad_cook',2,'0877', $11.95, $4000.00, 14, 15096,'More anecdotes from the Queen''s favorite cook describing life among English royalty. Recipes, techniques, tender vignettes.','06/12/91')
,(9,'PC1035', 'But Is It User Friendly?', 'popular_comp', 3,'1389',$22.95, $7000.00, 16, 8780,'A survey of software for the naive user, focusing on the ''friendliness'' of each.','06/30/91')
,(10,'BU2075', 'You Can Combat Computer Stress!', 'business',1,'0736',$2.99, $10125.00, 24, 18722,'The latest medical and psychological techniques for living with the electronic office. Easy-to-understand explanations.','06/30/91')
,(11,'PS2091', 'Is Anger the Enemy?', 'psychology',1,'0736', $10.95,$2275.00, 12, 2045,'Carefully researched study of the effects of strong emotions on the body. Metabolic charts included.','06/15/91')
,(12,'PS2106', 'Life Without Fear', 'psychology',1,'0736', $7.00, $6000.00,10, 111,'New exercise, meditation, and nutritional techniques that can reduce the shock of daily interactions. Popular audience. Sample menus included, exercise video available separately.','10/05/91')
,(13,'MC3021', 'The Gourmet Microwave', 'mod_cook', 2,'0877', $2.99,$15000.00, 24, 22246,'Traditional French gourmet recipes adapted for modern microwave cooking.','06/18/91')
,(14,'TC3218', 'Onions, Leeks, and Garlic: Cooking Secrets of the Mediterranean','trad_cook', 2,'0877', $20.95, $7000.00, 10, 375,'Profusely illustrated in color, this makes a wonderful gift book for a cuisine-oriented friend.','10/21/91')
,(15,'MC3026','The Psychology of Computer Cooking','trad_cook',2,'0877', $19.99, $7000.00, 10, 375, '', '05-15-1996')
,(16,'BU7832', 'Straight Talk About Computers', 'business',3,'1389',$19.99, $5000.00, 10, 4095,'Annotated analysis of what computers can do for you: a no-hype guide for the critical user.','06/22/91')
,(17,'PS1372', 'Computer Phobic AND Non-Phobic Individuals: Behavior Variations','psychology',2,'0877', $21.59, $7000.00, 10, 375,'A must for the specialist, this book examines the difference between those who hate and fear computers and those who don''t.','10/21/91')
,(18,'PC9999', 'Net Etiquette','popular_comp', 3,'1389', $15.95, $1000, 9, 120, 'A must-read for computer conferencing.', '07-20-1985')

SET IDENTITY_INSERT dbo.titles OFF;