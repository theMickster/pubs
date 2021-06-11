-- <Migration ID="b3094573-e461-4134-963a-1e0c0f14b72a" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.publishers
(
    publisher_id INTEGER IDENTITY(1, 1) NOT NULL
    ,publisher_code VARCHAR(25) NOT NULL
    ,publisher_name VARCHAR(40) NULL
    ,city VARCHAR(20) NULL
    ,state VARCHAR(2) NULL
    ,country VARCHAR(30) NULL
	,zip_code VARCHAR(10) NULL
)
WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.publishers ADD CONSTRAINT PK_publishers PRIMARY KEY CLUSTERED (publisher_id) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.publishers ADD CONSTRAINT UK_pub_id UNIQUE NONCLUSTERED (publisher_code) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.publishers ADD CONSTRAINT CK_pub_id CHECK (publisher_code IN ('1389', '0736', '0877', '1622', '1756') OR publisher_code LIKE '99[0-9][0-9]');
ALTER TABLE dbo.publishers ADD CONSTRAINT DF_publishers_country DEFAULT ('USA') FOR country;
