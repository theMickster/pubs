-- <Migration ID="f312aa36-80e9-42b0-b900-d68c17199761" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Load data into pubs tables
**************************************************************************/
SET IDENTITY_INSERT dbo.jobs  ON; 
INSERT dbo.jobs (job_id,job_desc,min_lvl,max_lvl)
VALUES (1, 'New Hire - Job not specified', 10, 10)
,(2, 'Chief Executive Officer', 200, 250)
,(3, 'Business Operations Manager', 175, 225)
,(4, 'Chief Financial Officier', 175, 250)
,(5, 'Publisher', 150, 250)
,(6, 'Managing Editor', 140, 225)
,(7, 'Marketing Manager', 120, 200)
,(8, 'Public Relations Manager', 100, 175)
,(9, 'Acquisitions Manager', 75, 175)
,(10, 'Productions Manager', 75, 165)
,(11, 'Operations Manager', 75, 150)
,(12,'Editor', 25, 100)
,(13, 'Sales Representative', 25, 100)
,(14, 'Designer', 25, 100)
SET IDENTITY_INSERT dbo.jobs  OFF