-- <Migration ID="a8a60fe4-1df2-4dcd-be62-d7fc474293e0" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.stores
(
    store_id INTEGER IDENTITY(1, 1) NOT NULL
    ,store_code VARCHAR(5) NOT NULL
    ,store_name VARCHAR(40) NULL
    ,store_address VARCHAR(40) NULL
    ,city VARCHAR(20) NULL
    ,state VARCHAR(2) NULL
    ,zip_code VARCHAR(10) NULL
)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.stores ADD CONSTRAINT PK_stores PRIMARY KEY CLUSTERED (store_id) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.stores ADD CONSTRAINT UK_stores UNIQUE NONCLUSTERED (store_code) WITH (DATA_COMPRESSION = PAGE);
