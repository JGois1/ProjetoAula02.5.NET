﻿--CRIAÇÃO DA TABELA DE PRODUTOS
CREATE TABLE PRODUCT(
	ID			UNIQUEIDENTIFIER	PRIMARY KEY,
	NAME		VARCHAR(100)		NOT NULL,
	PRICE		DECIMAL(10,2)		NOT NULL,
	QUANTITY	INTEGER				NOT NULL);

--INSERINDO PRODUTOS NA TABELA
INSERT INTO PRODUCT(ID, NAME, PRICE, QUANTITY)
VALUES
	(NEWID(), 'Notebook', 6000.0, 10),
	(NEWID(), 'Teclado', 150.0, 20),
	(NEWID(), 'Mochila', 500.0, 25);

--CONSULTANDO OS PRODUTOS
SELECT ID, NAME, PRICE, QUANTITY
FROM PRODUCT
ORDER BY NAME;