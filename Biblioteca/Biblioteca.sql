-- Fabio Amorim da Silva @ 2021-04-17 [YYYY-MM-DD]
-- São Paulo, 2021
-- Brazil
-- DATABASE : Biblioteca 
-- ORIGIN   : SQLite 3 
-- 
-- 


-- Livro
DROP TABLE IF EXISTS [Books];
CREATE TABLE [Books]
(      [ISBN] INTEGER PRIMARY KEY,
       [Title] TEXT NOT NULL,
       [Author] TEXT NOT NULL,
       [Genre] TEXT NOT NULL,
       [Year] INTEGER NOT NULL,
       FOREIGN KEY(Author) REFERENCES Author(Name)
);

-- Operações insert na tabela livros

INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788520937969, "Viagens de Gulliver", "Jonnathan Swift", "Aventura", 1726);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788520937945, "Robinson Crusoé", "Daniel Defoe", "Aventura", 1719);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788520934340, "A Ilha do Resouro", "Robert Louis Stevenson", "Aventura", 1883);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788542213737, "O Horror da Guerra: Uma Análise Provocativa Sobre Primeira Guerra", "Niall Ferguson", "História", 2018);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788535925043, "Graça Infinita", "David Foster Wallace", "Ficção", 1996);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(978850111824, "A Corrupção da Inteligência: Intelectuais e Poder no Brasil", "Flávio Gordon", "Não Ficção", 2016);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9786550970383, "Um Conto de Duas Cidades", "Charles Dickens", "Ficção", 1859);
INSERT INTO Books(ISBN, Title, Author, Genre, Year) VALUES(9788582850671, "David Cooperfield", "Charles Dickens", "Ficção", 1850);


-- Author
DROP TABLE IF EXISTS [Author];
CREATE TABLE [Author]
(
	[Name] TEXT NOT NULL PRIMARY KEY,
	[Books] TEXT NOT NULL,
	[COUNTRY] TEXT NOT NULL
	
);

-- Operações insert na tabela Author
INSERT INTO Author(Name, Books, Country) VALUES("Jonnathan Swift", "Viagens de Gulliver", "Inglaterra");
INSERT INTO Author(Name, Books, Country) VALUES("Daniel Defoe", "Robinson Crusoé", "Inglaterra");
INSERT INTO Author(Name, Books, Country) VALUES("Robert Louis Stevenson", "A Ilha do Tesouro", "Inglaterra");
INSERT INTO Author(Name, Books, Country) VALUES("David Foster Wallace", "Graça Infinita", "Inglaterra");
INSERT INTO Author(Name, Books, Country) VALUES("Flávio Gordon", "A Corrupção da Inteligência: Intelectuais e Poder no Brasil", "Brasil");
INSERT INTO Author(Name, Books, Country) VALUES("Charles Dickes", "Um Conto de Duas Cidades", "Inglaterra");




