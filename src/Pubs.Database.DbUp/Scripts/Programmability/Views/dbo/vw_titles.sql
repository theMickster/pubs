-- <Migration ID="47eb0ac8-2a9b-4642-adb7-04ae437acaa5" />
GO
CREATE OR ALTER VIEW vw_titles
AS
SELECT  t.title
        ,xref.author_order
        ,a.last_name
        ,t.price
        ,t.year_to_date_sales
        ,t.publisher_id

FROM    dbo.authors a
        INNER JOIN dbo.titles_xref_authors xref ON xref.author_id = a.author_id
		INNER JOIN dbo.titles t ON t.title_id = xref.title_id
        


GO