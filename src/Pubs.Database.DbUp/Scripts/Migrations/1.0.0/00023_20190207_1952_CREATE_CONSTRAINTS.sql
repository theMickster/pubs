-- <Migration ID="5d2bb38e-3bfb-4588-b63c-9aaa91b4ee0c" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.06
** CREATION:     Add indexes & constraints
**************************************************************************/
CREATE NONCLUSTERED INDEX IX_authors_names ON dbo.authors (last_name, first_name) WITH (DATA_COMPRESSION=PAGE);
CREATE NONCLUSTERED INDEX IX_titles_title ON dbo.titles (title) WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.titles ADD CONSTRAINT FK_titles_publisher_id FOREIGN KEY (publisher_id) REFERENCES dbo.publishers (publisher_id);
CREATE NONCLUSTERED INDEX IX_titles_publisher_id ON dbo.titles (publisher_id) WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.sales ADD CONSTRAINT FK_sales_stores FOREIGN KEY (store_id) REFERENCES dbo.stores (store_id);
CREATE NONCLUSTERED INDEX IX_sales_store_id ON dbo.sales (store_id) WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.sales ADD CONSTRAINT FK_sales_titles FOREIGN KEY (title_id) REFERENCES dbo.titles (title_id);
CREATE NONCLUSTERED INDEX IX_sales_title_id ON dbo.sales (title_id) WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.royalty ADD CONSTRAINT FK_royalty_titles FOREIGN KEY (title_id) REFERENCES dbo.titles (title_id);
CREATE NONCLUSTERED INDEX IX_royalty_title_id ON dbo.royalty (title_id) WITH (DATA_COMPRESSION = PAGE);

ALTER TABLE dbo.titles_xref_authors ADD CONSTRAINT FK_title_xref_author_titles FOREIGN KEY (title_id) REFERENCES dbo.titles (title_id)
CREATE NONCLUSTERED INDEX IX_titles_xref_authors_title_id ON dbo.titles_xref_authors (title_id) WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.titles_xref_authors ADD CONSTRAINT FK_title_xref_author_authors FOREIGN KEY (author_id) REFERENCES dbo.authors (author_id);
CREATE NONCLUSTERED INDEX IX_titles_xref_authors_author_id ON dbo.titles_xref_authors (author_id) WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.discounts ADD CONSTRAINT FK_discounts_stores FOREIGN KEY (store_id) REFERENCES dbo.stores (store_id)
CREATE NONCLUSTERED INDEX IX_discounts_store_id ON dbo.discounts (store_id) WITH (DATA_COMPRESSION=PAGE);

ALTER TABLE dbo.publisher_info ADD CONSTRAINT FK_publisher_info_publishers FOREIGN KEY (publisher_id) REFERENCES publishers (publisher_id) ;

ALTER TABLE dbo.employees ADD CONSTRAINT FK_employees_publishers FOREIGN KEY (publisher_id) REFERENCES dbo.publishers (publisher_id)
CREATE NONCLUSTERED INDEX IX_employee_publisher_id ON dbo.employees (publisher_id) WITH (DATA_COMPRESSION=PAGE);

UPDATE STATISTICS dbo.publishers;
UPDATE STATISTICS dbo.employees;
UPDATE STATISTICS dbo.jobs;
UPDATE STATISTICS dbo.publisher_info;
UPDATE STATISTICS dbo.titles;
UPDATE STATISTICS dbo.authors;
UPDATE STATISTICS dbo.titles_xref_authors;
UPDATE STATISTICS dbo.sales;
UPDATE STATISTICS dbo.royalty;
UPDATE STATISTICS dbo.stores;
UPDATE STATISTICS dbo.discounts;
