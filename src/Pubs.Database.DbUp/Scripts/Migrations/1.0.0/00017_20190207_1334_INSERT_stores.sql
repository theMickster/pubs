-- <Migration ID="49cd45cc-dbb9-438a-9858-61326a8af4af" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Load data into pubs tables
**************************************************************************/

SET IDENTITY_INSERT dbo.stores ON; 
insert dbo.stores(store_id,store_code,store_name,store_address,city,state,zip_code)
values(1, '7066','Barnum''s','567 Pasadena Ave.','Tustin','CA','92789')
,(2,'7067','News & Brews','577 First St.','Los Gatos','CA','96745')
,(3,'7131','Doc-U-Mat: Quality Laundry and Books','24-A Avogadro Way','Remulade','WA','98014')
,(4,'8042','Bookbeat','679 Carson St.','Portland','OR','89076')
,(5,'6380','Eric the Read Books','788 Catamaugus Ave.','Seattle','WA','98056')
,(6,'7896','Fricative Bookshop','89 Madison St.','Fremont','CA','90019')
SET IDENTITY_INSERT dbo.stores OFF; 