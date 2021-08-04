--
-- File generated with SQLiteStudio v3.3.3 on ter ago 3 16:44:08 2021
--
-- Text encoding used: UTF-8
--

-- Table: Agencia
DROP TABLE IF EXISTS Agencias;
CREATE TABLE Agencias (id INTEGER UNIQUE NOT NULL PRIMARY KEY, nome VARCHAR (40) NOT NULL UNIQUE, cidade VARCHAR (40) UNIQUE NOT NULL, idCorretores INTEGER UNIQUE NOT NULL, idImoveis INTEGER UNIQUE NOT NULL);
INSERT INTO Agencias (id, nome, cidade, idCorretores, idImoveis) VALUES (1, 'Imoveis Jandira', 'Jandira', '1,2,3', '1,2,3');
INSERT INTO Agencias (id, nome, cidade, idCorretores, idImoveis) VALUES (2, 'Imoveis Barueri', 'Barueri', '4,5,6', '4,5,6');
INSERT INTO Agencias (id, nome, cidade, idCorretores, idImoveis) VALUES (3, 'Imoveis Carapicuiba', 'Carapicuiba', '7,8,9', '7,8,9');
INSERT INTO Agencias (id, nome, cidade, idCorretores, idImoveis) VALUES (4, 'Imoveis Osasco', 'Osasco', '10,11,12', '10,11,12');

-- Table: Corretor
DROP TABLE IF EXISTS Corretores;
CREATE TABLE Corretores (id INTEGER PRIMARY KEY NOT NULL UNIQUE, idAgencia INTEGER NOT NULL UNIQUE, nome VARCHAR NOT NULL, idade INTEGER NOT NULL, vendas INTEGER NOT NULL);
INSERT INTO Corretores (id, idAgencia, nome, idade, vendas) VALUES (1, 1, 'Fabio', 26, 10);
INSERT INTO Corretores (id, idAgencia, nome, idade, vendas) VALUES (2, 2, 'Joao', 30, 20);
INSERT INTO Corretores (id, idAgencia, nome, idade, vendas) VALUES (3, 3, 'Maria', 31, 30);
INSERT INTO Corretores (id, idAgencia, nome, idade, vendas) VALUES (4, 4, 'Joana', 20, 5);

-- Table: Dono
DROP TABLE IF EXISTS Donos;
CREATE TABLE Donos (id INTEGER PRIMARY KEY UNIQUE NOT NULL, nome VARCHAR UNIQUE NOT NULL, idade INTEGER NOT NULL, imovel VARCHAR NOT NULL);
INSERT INTO Donos (id, nome, idade, imovel) VALUES (1, 'Mariana', 20, 'Jandira');
INSERT INTO Donos (id, nome, idade, imovel) VALUES (2, 'Paulo', 21, 'Barueri');
INSERT INTO Donos (id, nome, idade, imovel) VALUES (3, 'Juliana', 25, 'Carapicuiba');
INSERT INTO Donos (id, nome, idade, imovel) VALUES (4, 'Lucas', 30, 'Osasco');

-- Table: Imovel
DROP TABLE IF EXISTS Imoveis;
CREATE TABLE Imoveis (id INTEGER PRIMARY KEY NOT NULL UNIQUE, idDono INTEGER UNIQUE NOT NULL, idAgencia INTEGER UNIQUE NOT NULL, endereco VARCHAR UNIQUE NOT NULL, preco DOUBLE UNIQUE NOT NULL);
INSERT INTO Imoveis (id, idDono, idAgencia, endereco, preco) VALUES (1, 1, 1, 'Jandira', 100.0);
INSERT INTO Imoveis (id, idDono, idAgencia, endereco, preco) VALUES (2, 2, 2, 'Barueri', 200.0);
INSERT INTO Imoveis (id, idDono, idAgencia, endereco, preco) VALUES (3, 3, 3, 'Carapicuiba', 80.0);
INSERT INTO Imoveis (id, idDono, idAgencia, endereco, preco) VALUES (4, 4, 4, 'Osasco', 250.0);

