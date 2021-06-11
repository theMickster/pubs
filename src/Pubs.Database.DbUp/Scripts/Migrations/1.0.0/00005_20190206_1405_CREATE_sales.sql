-- <Migration ID="eb407fc6-32c7-459e-808f-bd25b6295c2a" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.sales
(
    sale_id INTEGER IDENTITY(1,1) NOT NULL
	,store_id INTEGER NOT NULL
    ,store_code VARCHAR(4) NOT NULL
    ,ord_num VARCHAR(20) NOT NULL
    ,ord_date DATETIME NOT NULL
    ,qty SMALLINT NOT NULL
    ,payterms VARCHAR(15) NOT NULL
    ,title_id INTEGER NOT NULL
	,title_code VARCHAR(25) NOT NULL

) 
WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.sales ADD CONSTRAINT PK_sales PRIMARY KEY CLUSTERED (sale_id) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.sales ADD CONSTRAINT UK_sales UNIQUE NONCLUSTERED (store_id, ord_num, title_id) WITH (DATA_COMPRESSION = PAGE);


