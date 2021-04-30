-- Fabio Amorim da Silva @2021-04-29 [YYYY-MM-DD]
-- São Paulo, 2021
-- Brazil
-- Database : Concessionaria
-- Origin: Sqlite3
--
--

-- Agencia
DROP TABLE IF EXISTS [Agencia];
CREATE TABLE [Agencia]
(
    [AgenciaID] INTEGER NOT NULL PRIMARY KEY,
    [NomeAgencia] TEXT NOT NULL,
    [GerenteAgencia] TEXT NOT NULL,
    [CidadeAgencia] TEXT NOT NULL

);

INSERT INTO Agencia(AgenciaID, NomeAgencia, GerenteAgencia, CidadeAgencia) 
    VALUES(1, 'Auto Jandira', 'Pedro', 'Jandira');
INSERT INTO Agencia(AgenciaID, NomeAgencia, GerenteAgencia, CidadeAgencia) 
    VALUES(2, 'Auto Barueri', 'Marcos', 'Barueri');
INSERT INTO Agencia(AgenciaID, NomeAgencia, GerenteAgencia, CidadeAgencia) 
    VALUES(3, 'Auto Carapicuíba', 'Maria', 'Carapicuíba');
INSERT INTO Agencia(AgenciaID, NomeAgencia, GerenteAgencia, CidadeAgencia) 
    VALUES(4, 'Auto Itapevi', 'Joana', 'Itapevi');
INSERT INTO Agencia(AgenciaID, NomeAgencia, GerenteAgencia, CidadeAgencia) 
    VALUES(5, 'Auto Osasco', 'Daiana', 'Osasco');

-- Carro
DROP TABLE IF EXISTS [Gerente];
CREATE TABLE [Gerente]
(
    [GerenteID] INTEGER PRIMARY KEY NOT NULL,
    [AgenciaID] INTEGER NOT NULL,
    [Nome] TEXT NOT NULL,
    [Telefone] INTEGER NOT NULL,
    FOREIGN KEY (AgenciaID) REFERENCES Agencia(AgenciaID)

);

INSERT INTO Gerente(GerenteID, AgenciaID, Nome, Telefone)
    VALUES(1, 1, 'Pedro', 1111);
INSERT INTO Gerente(GerenteID, AgenciaID, Nome, Telefone)
    VALUES(2, 2, 'Marcos', 2222);
INSERT INTO Gerente(GerenteID, AgenciaID, Nome, Telefone)
    VALUES(3, 3, 'Maria', 3333);
INSERT INTO Gerente(GerenteID, AgenciaID, Nome, Telefone)
    VALUES(4, 4, 'Joana', 4444);
INSERT INTO Gerente(GerenteID, AgenciaID, Nome, Telefone)
    VALUES(5, 5, 'Daina', 5555);

-- Vendedor
DROP TABLE IF EXISTS [Vendedor];
CREATE TABLE [Vendedor]
(
    [VendedorID] INTEGER PRIMARY KEY NOT NULL,
    [AgenciaID] INTEGER NOT NULL,
    [Nome] TEXT NOT NULL,
    [Telefone] INTEGER NOT NULL,
    [NumeroVendas] INTEGER NOT NULL,
    FOREIGN KEY(AgenciaID) REFERENCES Agencia(AgenciaID)
);

INSERT INTO Vendedor(VendedorID, AgenciaID, Nome, Telefone, NumeroVendas)
    VALUES(1, 1, 'Mario', 6666, 0);
INSERT INTO Vendedor(VendedorID, AgenciaID, Nome, Telefone, NumeroVendas)
    VALUES(2, 2, 'Renan', 7777, 0);
INSERT INTO Vendedor(VendedorID, AgenciaID, Nome, Telefone, NumeroVendas)
    VALUES(3, 3, 'Fernanda', 8888, 0);
INSERT INTO Vendedor(VendedorID, AgenciaID, Nome, Telefone, NumeroVendas)
    VALUES(4, 4, 'Camilla', 9999, 0);
INSERT INTO Vendedor(VendedorID, AgenciaID, Nome, Telefone, NumeroVendas)
    VALUES(5, 5, 'Diogo', 1000, 0);

-- Carro
DROP TABLE IF EXISTS [Carro];
CREATE TABLE [Carro]
(
    [CarroID] INTEGER PRIMARY KEY NOT NULL,
    [AgenciaID] INTEGER NOT NULL,
    [Marca] TEXT NOT NULL,
    [Modelo] TEXT NOT NULL,
    [Ano] INTEGER NOT NULL,
    FOREIGN KEY(AgenciaID) REFERENCES Agencia(AgenciaID)
);

INSERT INTO Carro(CarroID, AgenciaID, Marca, Modelo, Ano)
    VALUES(1, 1, 'Fiat', 'Uno', 2000);
INSERT INTO Carro(CarroID, AgenciaID, Marca, Modelo, Ano)
    VALUES(2, 2, 'Chevrolet', 'Vectra', 2004);
INSERT INTO Carro(CarroID, AgenciaID, Marca, Modelo, Ano)
    VALUES(3, 3, 'Volkswagen', 'Gol', 2020);
INSERT INTO Carro(CarroID, AgenciaID, Marca, Modelo, Ano)
    VALUES(4, 4, 'Honda', 'Civic', 2021);
INSERT INTO Carro(CarroID, AgenciaID, Marca, Modelo, Ano)
    VALUES(5, 5, 'Audi', 'A5', 2018);

