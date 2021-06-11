-- <Migration ID="f0bed0bc-e661-4b32-8cf6-b7e0b541c8b1" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.authors
(
    author_id INTEGER IDENTITY(1, 1) NOT NULL
    ,author_code VARCHAR(25) NOT NULL
    ,last_name VARCHAR(50) NOT NULL
    ,first_name VARCHAR(50) NOT NULL
    ,phone_number VARCHAR(12) NOT NULL
    ,address VARCHAR(40) NULL
    ,city VARCHAR(20) NULL
    ,state VARCHAR(2) NULL
    ,zip_code VARCHAR(5) NULL
    ,contract BIT NOT NULL
)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.authors ADD CONSTRAINT PK_authors PRIMARY KEY CLUSTERED (author_id) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.authors ADD CONSTRAINT UK_authors_au_id UNIQUE NONCLUSTERED (author_code) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.authors ADD CONSTRAINT CK_authors_au_id CHECK (author_code LIKE '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]');
ALTER TABLE dbo.authors ADD CONSTRAINT CK_authors_zip CHECK (zip_code LIKE '[0-9][0-9][0-9][0-9][0-9]');
ALTER TABLE dbo.authors ADD CONSTRAINT DF_authors_phone DEFAULT ('UNKNOWN') FOR phone_number;

