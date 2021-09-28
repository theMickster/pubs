-- <Migration ID="a6ca7d67-85fc-4797-b5e8-a6a586aa3a00" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.publisher_info
(
    publisher_id INTEGER NOT NULL
	,publisher_code VARCHAR(25) NOT NULL
    ,logo IMAGE NULL
    ,publisher_info VARCHAR(MAX) NULL
)
WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.publisher_info ADD CONSTRAINT PK_publisher_info PRIMARY KEY CLUSTERED (publisher_id) WITH (DATA_COMPRESSION=PAGE);