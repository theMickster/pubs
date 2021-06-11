-- <Migration ID="394b57ba-7a11-4788-afee-1b1f1afbd224" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**               Formerly roysched
**************************************************************************/
CREATE TABLE dbo.royalty
(
    royalty_id INTEGER IDENTITY(1, 1) NOT NULL
    ,title_id INTEGER NOT NULL
    ,title_code VARCHAR(25) NOT NULL
    ,lorange INT NULL
    ,hirange INT NULL
    ,royalty INT NULL
)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.royalty ADD CONSTRAINT PK_royalty PRIMARY KEY CLUSTERED (royalty_id)
