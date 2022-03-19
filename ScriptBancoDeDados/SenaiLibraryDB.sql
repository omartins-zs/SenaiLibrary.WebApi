GO

CREATE DATABASE SenaiLibraryDB

GO

USE SenaiLibraryDB

GO

CREATE TABLE Jogos (
    Id INT PRIMARY KEY IDENTITY,
    TituloDoJogo VARCHAR(150) NOT NULL,
    LojaDisponivel VARCHAR(150) NOT NULL,
    Disponivel BIT
)

GO

INSERT INTO Jogos (TituloDoJogo, LojaDisponivel, Disponivel) 
VALUES ('Fortnite', 'Epic Games', 0)

GO

INSERT INTO Jogos (TituloDoJogo, LojaDisponivel, Disponivel) 
VALUES ('Counter Strike', 'Steam', 1)

GO

-- UPDATE Livros SET Titulo = 'Titulo A1' Where Id = 1;

 -- DELETE FROM Livros WHERE Id = 1;

SELECT Id, TituloDoJogo , LojaDisponivel, Disponivel FROM Jogos

GO

CREATE TABLE Jogadores (
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL
)
GO

INSERT INTO Jogadores VALUES ('fallen@sp.br', '1234')

GO

INSERT INTO Jogadores VALUES ('linFNX@sp.br', '1234')

GO

SELECT * FROM Jogadores

GO

SELECT * FROM Jogos


GO

SELECT * FROM Jogadores WHERE email = 'fallen@sp.br' AND senha = '1234'
