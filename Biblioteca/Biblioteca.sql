-- Fabio Amorim da Silva @ 2021-04-17 [YYYY-MM-DD]
-- São Paulo, 2021
-- Brazil
-- DATABASE : Biblioteca 
-- ORIGIN   : SQLite 3 
-- 
-- 

-- Author
DROP TABLE IF EXISTS [Authors];
CREATE TABLE [Authors]
(
	[ID] INTEGER PRIMARY KEY AUTOINCREMENT,
	[Name] TEXT NOT NULL,
	[Books] TEXT NOT NULL,
	[COUNTRY] TEXT NOT NULL
	
);

-- Operações insert na tabela Author
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"Jonnathan Swift", "Viagens de Gulliver", "Inglaterra");
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"Daniel Defoe", "Robinson Crusoé", "Inglaterra");
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"Robert Louis Stevenson", "A Ilha do Tesouro", "Inglaterra");
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"David Foster Wallace", "Graça Infinita", "Inglaterra");
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"Flávio Gordon", "A Corrupção da Inteligência: Intelectuais e Poder no Brasil", "Brasil");
INSERT INTO Authors(ID, Name, Books, Country) VALUES(null,"Charles Dickes", "Um Conto de Duas Cidades", "Inglaterra");


-- Livro
DROP TABLE IF EXISTS [Books];
CREATE TABLE [Books]
(
       [ID] INTEGER PRIMARY KEY AUTOINCREMENT,
       [ISBN] INTEGER,
       [Title] TEXT NOT NULL,
       [Author] TEXT NOT NULL,
       [Genre] TEXT NOT NULL,
       [Year] INTEGER NOT NULL

);

-- Operações insert na tabela livros

INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 1, "Viagens de Gulliver", "Jonnathan Swift", "Aventura", 1726); 
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 2, "Robinson Crusoé", "Daniel Defoe", "Aventura", 1719);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 3, "A Ilha do Resouro", "Robert Louis Stevenson", "Aventura", 1883);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 4, "O Horror da Guerra: Uma Análise Provocativa Sobre Primeira Guerra", "Niall Ferguson", "História", 2018);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 5, "Graça Infinita", "David Foster Wallace", "Ficção", 1996);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 6, "A Corrupção da Inteligência: Intelectuais e Poder no Brasil", "Flávio Gordon", "Não Ficção", 2016);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 7, "Um Conto de Duas Cidades", "Charles Dickens", "Ficção", 1859);
INSERT INTO Books(ID, ISBN, Title, Author, Genre, Year) VALUES(null, 8, "David Cooperfield", "Charles Dickens", "Ficção", 1850);






