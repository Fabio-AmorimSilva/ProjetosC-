--
-- File generated with SQLiteStudio v3.3.3 on sáb jul 31 18:06:32 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Agencia
CREATE TABLE Agencia (id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR (40) NOT NULL UNIQUE, cidade VARCHAR (40) UNIQUE NOT NULL, idCorretores INTEGER UNIQUE NOT NULL, idImoveis INTEGER UNIQUE NOT NULL);
INSERT INTO Agencia (id, nome, cidade, idCorretores, idImoveis) VALUES (1, 'Imoveis Jandira', 'Jandira', '1,2,3', '1,2,3');

-- Table: Corretor
CREATE TABLE Corretor (id INTEGER PRIMARY KEY NOT NULL UNIQUE, idAgencia INTEGER NOT NULL UNIQUE, nome VARCHAR NOT NULL, idade INTEGER NOT NULL, vendas INTEGER NOT NULL);

-- Table: Dono
CREATE TABLE Dono (cpf INTEGER PRIMARY KEY UNIQUE NOT NULL, nome VARCHAR UNIQUE NOT NULL, idade INTEGER NOT NULL, imovel VARCHAR NOT NULL);

-- Table: Imovel
CREATE TABLE Imovel (id INTEGER PRIMARY KEY NOT NULL UNIQUE, idDono INTEGER UNIQUE NOT NULL, idAgencia INTEGER UNIQUE NOT NULL, endereco VARCHAR UNIQUE NOT NULL, preco DOUBLE UNIQUE NOT NULL);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
