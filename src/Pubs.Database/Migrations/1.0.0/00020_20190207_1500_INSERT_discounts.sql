-- <Migration ID="4627f71c-c0d9-4a81-bd87-de7706065ea0" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2019.02.07
** CREATION:     Load data into pubs tables
**************************************************************************/
INSERT dbo.discounts(discount_type,store_id,store_code,low_qty,high_qty,discount)
VALUES ('Initial Customer', 2, '7067', 0, 1000, 10.5)
,('Volume Discount', 1, '7066', 100, 1000, 6.7)
,('Customer Discount', 4, '8042', NULL, NULL, 5.0)
