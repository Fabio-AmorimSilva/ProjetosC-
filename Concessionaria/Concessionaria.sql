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
    [AgenciaID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    [NomeAgencia] TEXT NOT NULL UNIQUE,
    [GerenteAgencia] TEXT NOT NULL PRIMARY KEY,
    [CidadeAgencia] TEXT NOT NULL

);

-- Carro
DROP TABLE IF EXISTS [Gerente];
CREATE TABLE [Gerente]
(
    [GerenteID] INTEGER PRIMARY KEY NOT NULL AUTOINCREMENT,
    [AgenciaID] INTEGER NOT NULL,
    [Nome] TEXT NOT NULL,
    [Telefone] INTEGER NOT NULL,
    FOREIGN KEY (AgenciaID) REFERENCES Agencia(AgenciaID)

);

-- Vendedor
DROP TABLE IF EXISTS [Vendedor];
CREATE TABLE [Vendedor]
(
    [VendedorID] INTEGER PRIMARY KEY NOT NULL AUTOINCREMENT,
    [AgenciaID] INTEGER NOT NULL,
    [Nome] TEXT NOT NULL,
    [Telefone] INTEGER NOT NULL,
    [NumeroVendas] INTEGER NOT NULL,
    FOREIGN KEY(AgenciaID) REFERENCES Agencia(AgenciaID)
);

-- Carro
DROP TABLE IF EXISTS [Carro];
CREATE TABLE [Carro]
(
    [CarroID] INTEGER PRIMARY KEY NOT NULL AUTOINCREMENT,
    [AgenciaID] INTEGER NOT NULL,
    [Marca] TEXT NOT NULL,
    [Modelo] TEXT NOT NULL,
    [Ano] INTEGER NOT NULL,
    FOREIGN KEY(AgenciaID) REFERENCES Agencia(AgenciaID)
);