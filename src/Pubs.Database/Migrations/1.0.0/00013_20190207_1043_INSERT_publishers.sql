-- <Migration ID="1cfad9b3-e84a-4a78-948f-82b2d19346bb" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Load data into pubs tables
**************************************************************************/
SET IDENTITY_INSERT dbo.publishers ON; 
INSERT INTO dbo.publishers(publisher_id,publisher_code,publisher_name,city,state,country)
VALUES (1, '0736', 'New Moon Books', 'Boston', 'MA', 'USA')
,(2,'0877', 'Binnet & Hardley', 'Washington', 'DC', 'USA')
,(3,'1389', 'Algodata Infosystems', 'Berkeley', 'CA', 'USA')
,(4,'9952', 'Scootney Books', 'New York', 'NY', 'USA')
,(5,'1622', 'Five Lakes Publishing', 'Chicago', 'IL', 'USA')
,(6,'1756', 'Ramona Publishers', 'Dallas', 'TX', 'USA')
,(7,'9901', 'GGG&G', 'Munchen', NULL, 'Germany')
,(8,'9999', 'Lucerne Publishing', 'Paris', NULL, 'France')
SET IDENTITY_INSERT dbo.publishers OFF;