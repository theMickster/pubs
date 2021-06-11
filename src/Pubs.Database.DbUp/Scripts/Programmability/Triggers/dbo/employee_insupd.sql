-- <Migration ID="a7da7766-d21e-4ea2-9125-6a255d77ea1b" />
GO
CREATE OR ALTER TRIGGER dbo.employees_insupd
ON employees
FOR INSERT, UPDATE
AS
--Get the range of level for this job type from the jobs table.
DECLARE @min_lvl TINYINT
        ,@max_lvl TINYINT
        ,@emp_lvl TINYINT
        ,@job_id INTEGER;

SELECT  @min_lvl = min_lvl
        ,@max_lvl = max_lvl
        ,@emp_lvl = i.job_lvl
        ,@job_id = i.job_id

FROM    dbo.employees e
        INNER JOIN inserted i ON e.employee_id = i.employee_id
		INNER JOIN dbo.jobs j ON i.job_id = j.job_id;


IF (@job_id = 1)
   AND  (@emp_lvl <> 10)
BEGIN
    RAISERROR('Job id 1 expects the default level of 10.', 16, 1);
    ROLLBACK TRANSACTION;
END;
ELSE IF NOT (@emp_lvl
        BETWEEN @min_lvl AND @max_lvl
            )
BEGIN
    RAISERROR('The level for job_id:%d should be between %d and %d.', 16, 1, @job_id, @min_lvl, @max_lvl);
    ROLLBACK TRANSACTION;
END;

GO