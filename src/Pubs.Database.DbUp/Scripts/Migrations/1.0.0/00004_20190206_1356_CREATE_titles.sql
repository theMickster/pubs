-- <Migration ID="e1b5a94b-e565-4af5-964b-23c3e92a1bdd" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.titles
(
    title_id INTEGER IDENTITY(1, 1) NOT NULL
    ,title_code VARCHAR(25) NOT NULL 
    ,title VARCHAR(80) NOT NULL
    ,title_type CHAR(12) NOT NULL
    ,publisher_id INTEGER NULL
    ,publisher_code CHAR(4) NULL
    ,price MONEY NULL
    ,advance MONEY NULL
    ,royalty INT NULL
    ,year_to_date_sales INT NULL
    ,notes VARCHAR(200) NULL
    ,published_date DATETIME NOT NULL 
)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.titles ADD CONSTRAINT PK_titles PRIMARY KEY CLUSTERED (title_id) WITH (DATA_COMPRESSION=PAGE);
ALTER TABLE dbo.titles ADD CONSTRAINT UK_titles UNIQUE NONCLUSTERED (title_code) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.titles ADD CONSTRAINT DF_titles_title_type DEFAULT ('UNDECIDED') FOR title_type;
ALTER TABLE dbo.titles ADD CONSTRAINT DF_titles_published_date DEFAULT (GETDATE()) FOR published_date;
