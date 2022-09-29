USE [purchases]
GO

TRUNCATE TABLE enumerate_type
TRUNCATE TABLE enumerate
GO

INSERT INTO enumerate_type
VALUES
('CURRENCY', '10')
GO

INSERT INTO enumerate
VALUES
('PEN','SOLES','10'),
('USD','DOLAR','10')
GO