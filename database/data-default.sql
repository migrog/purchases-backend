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
('1','PEN','10'),
('2','USD','10')
GO