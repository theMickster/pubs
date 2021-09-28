-- <Migration ID="cbfe8b56-a14a-4d70-b36c-22d425e4036b" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Create Pub tables.
**************************************************************************/
CREATE TABLE dbo.employees
(
    employee_id INTEGER IDENTITY(1,1) NOT NULL
	,employee_code VARCHAR(25) NOT NULL
    ,first_name VARCHAR(50) NOT NULL
    ,middle_name VARCHAR(50) NOT NULL
    ,last_name VARCHAR(30) NOT NULL
    ,job_id INTEGER NOT NULL 
    ,job_lvl TINYINT NOT NULL    
	,publisher_id INTEGER NOT NULL
    ,publisher_code VARCHAR(25) NOT NULL
	,hire_date DATETIME NOT NULL
)
WITH (DATA_COMPRESSION=PAGE)

ALTER TABLE dbo.employees ADD CONSTRAINT PK_employees PRIMARY KEY NONCLUSTERED (employee_id);
ALTER TABLE dbo.employees
ADD CONSTRAINT CK_employees_employee_code CHECK (employee_code LIKE '[A-Z][A-Z][A-Z][1-9][0-9][0-9][0-9][0-9][FM]'
                                                 OR employee_code LIKE '[A-Z]-[A-Z][1-9][0-9][0-9][0-9][0-9][FM]'
                                                );
ALTER TABLE dbo.employees ADD CONSTRAINT DF_employees_job_id DEFAULT (1) FOR job_id;
ALTER TABLE dbo.employees ADD CONSTRAINT DF_employees_job_lvl DEFAULT (1) FOR job_lvl;
ALTER TABLE dbo.employees ADD CONSTRAINT DF_employees_hire_date DEFAULT (GETDATE()) FOR hire_date;
ALTER TABLE dbo.employees ADD CONSTRAINT FK_employees_jobs FOREIGN KEY (job_id) REFERENCES dbo.jobs (job_id)
ALTER TABLE dbo.employees ADD CONSTRAINT DF_employees_publisher_code DEFAULT ('9952') FOR publisher_code
