-- <Migration ID="6e6418d9-5839-402c-b928-69b7993ac1c5" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2020.03.26
** CREATION:     Add tables for authentication & authorization
**************************************************************************/
DROP TABLE IF EXISTS dbo.application_user_roles;
DROP TABLE IF EXISTS dbo.application_users;
DROP TABLE IF EXISTS dbo.application_roles;
DROP TABLE IF EXISTS dbo.application_user_statuses;

CREATE TABLE dbo.application_roles
(
    application_role_id INTEGER IDENTITY(1,1) NOT NULL
    ,role_name VARCHAR(100) NOT NULL
)
WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.application_roles 
ADD CONSTRAINT PK_application_roles 
PRIMARY KEY NONCLUSTERED (application_role_id)
WITH (DATA_COMPRESSION = PAGE);

CREATE TABLE dbo.application_user_statuses
(
    application_user_status_id INTEGER IDENTITY(1,1) NOT NULL
    ,status_abbreviation VARCHAR(1) NOT NULL
    ,status_name VARCHAR(250) NOT NULL
)
WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.application_user_statuses 
ADD CONSTRAINT PK_application_user_statuses 
PRIMARY KEY NONCLUSTERED (application_user_status_id)
WITH (DATA_COMPRESSION = PAGE);

CREATE TABLE dbo.application_users
(
    application_user_id INTEGER IDENTITY(1,1) NOT NULL
	,application_user_status_id INTEGER NOT NULL
    ,username VARCHAR(50) NOT NULL
    ,user_principal_name VARCHAR(50) NOT NULL
    ,first_name VARCHAR(100) NOT NULL
    ,middle_name VARCHAR(100) NOT NULL
    ,last_name VARCHAR(100) NOT NULL
    ,email_address VARCHAR(100) NOT NULL
	,phone_number VARCHAR(25) NOT NULL    
    ,last_successful_login DATETIME NULL
)
WITH (DATA_COMPRESSION=PAGE)

ALTER TABLE dbo.application_users 
ADD CONSTRAINT PK_application_users 
PRIMARY KEY NONCLUSTERED (application_user_id)
WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.application_users 
ADD CONSTRAINT FK_application_users_application_user_statuses
FOREIGN KEY (application_user_status_id) REFERENCES dbo.application_user_statuses (application_user_status_id);

CREATE TABLE dbo.application_user_roles
(
	application_user_role_id INTEGER IDENTITY(1,1) NOT NULL
	,application_user_id INTEGER NOT NULL
	,application_role_id INTEGER NOT NULL
)

ALTER TABLE dbo.application_user_roles 
ADD CONSTRAINT PK_application_user_roles 
PRIMARY KEY NONCLUSTERED (application_user_role_id) WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.application_user_roles 
ADD CONSTRAINT FK_application_user_roles_application_users
FOREIGN KEY (application_user_id) REFERENCES dbo.application_users (application_user_id);

ALTER TABLE dbo.application_user_roles 
ADD CONSTRAINT FK_application_user_roles_application_roles
FOREIGN KEY (application_role_id) REFERENCES dbo.application_roles (application_role_id);

ALTER TABLE dbo.application_user_roles 
ADD CONSTRAINT uk_application_user_roles
UNIQUE NONCLUSTERED (application_user_id, application_role_id)
WITH (DATA_COMPRESSION = PAGE);