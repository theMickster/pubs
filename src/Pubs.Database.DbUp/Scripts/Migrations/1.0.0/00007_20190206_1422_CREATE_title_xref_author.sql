-- <Migration ID="7b1b2eee-922d-4694-a6f6-3dcb586bee27" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**               Formerly titleauthor
**************************************************************************/
CREATE TABLE dbo.titles_xref_authors
(
    title_xref_author_id INTEGER IDENTITY(1,1) NOT NULL
    ,title_id INTEGER NOT NULL
    ,title_code VARCHAR(25) NOT NULL
    ,author_id INTEGER NOT NULL
    ,author_code VARCHAR(25) NOT NULL
    ,author_order TINYINT NULL
    ,royaltyper INT NULL
)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.titles_xref_authors ADD CONSTRAINT PK_title_xref_author PRIMARY KEY CLUSTERED (title_xref_author_id) WITH (DATA_COMPRESSION = PAGE);
ALTER TABLE dbo.titles_xref_authors ADD CONSTRAINT UK_title_xref_author UNIQUE NONCLUSTERED (author_id, title_id) WITH (DATA_COMPRESSION = PAGE);