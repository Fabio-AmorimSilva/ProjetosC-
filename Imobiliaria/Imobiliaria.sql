--
-- File generated with SQLiteStudio v3.3.3 on qua jul 28 17:14:19 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Agencia
CREATE TABLE Agencia (id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR (40) NOT NULL UNIQUE, cidade VARCHAR (40) UNIQUE NOT NULL, idCorretores INTEGER UNIQUE NOT NULL, idImoveis INTEGER UNIQUE NOT NULL);
INSERT INTO Agencia (id, nome, cidade, idCorretores, idImoveis) VALUES (1, 'Imoveis Jandira', 'Jandira', '1,2,3', '1,2,3');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
