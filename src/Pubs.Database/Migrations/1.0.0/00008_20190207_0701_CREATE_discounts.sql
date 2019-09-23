-- <Migration ID="ecb770cd-1561-4e52-9b27-957945373286" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.discounts
(
	discount_id INTEGER IDENTITY(1,1) NOT NULL
    ,discount_type VARCHAR(40) NOT NULL
    ,store_id INTEGER NOT NULL
    ,store_code VARCHAR(10) NOT NULL
    ,low_qty SMALLINT NULL
    ,high_qty SMALLINT NULL
    ,discount DECIMAL(4,2) NOT NULL
)
WITH(DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.discounts ADD CONSTRAINT PK_discounts PRIMARY KEY CLUSTERED (discount_id) WITH (DATA_COMPRESSION=PAGE);
