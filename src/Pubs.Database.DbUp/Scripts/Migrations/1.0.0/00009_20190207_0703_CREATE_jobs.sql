-- <Migration ID="bce7836b-635b-496c-a11f-7f225f7e31d8" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.jobs
(
    job_id INTEGER IDENTITY(1,1) NOT NULL
    ,job_desc VARCHAR(50) NOT NULL 
    ,min_lvl TINYINT NOT NULL 
    ,max_lvl TINYINT NOT NULL 
)
WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.jobs ADD CONSTRAINT PK_jobs PRIMARY KEY CLUSTERED (job_id);
ALTER TABLE dbo.jobs ADD CONSTRAINT CK_jobs_min_lvl CHECK (min_lvl >= 10);
ALTER TABLE dbo.jobs ADD CONSTRAINT CK_jobs_max_lvl CHECK (max_lvl <= 250);
ALTER TABLE dbo.jobs ADD CONSTRAINT DF_jobs_job_desc DEFAULT ('New Position - title not formalized yet') FOR job_desc;
