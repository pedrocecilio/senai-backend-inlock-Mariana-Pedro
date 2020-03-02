CREATE DATABASE Inlock_Games_Manha

USE Inlock_Games_Manha

CREATE TABLE Estudio(
Id_Estudio INT PRIMARY KEY IDENTITY,
NomeEstudio VARCHAR(255) NOT NULL
);
go

CREATE TABLE Jogos(
Id_Jogos INT PRIMARY KEY IDENTITY,
NomeJogo VARCHAR (255) NOT NULL,
Descricao VARCHAR (255) NOT NULL,
DataLancamento datetime2 not null,
Preco VARCHAR (255) NOT NULL,
Id_Estudio INT FOREIGN KEY REFERENCES Estudio(Id_Estudio)
);
go


CREATE TABLE TipoUsuario(
Id_TipoUsuario INT PRIMARY KEY IDENTITY,
TituloTipoUsuario VARCHAR (255) NOT NULL
);
go

CREATE TABLE Usuario(
Id_Usuario INT PRIMARY KEY IDENTITY,
Email VARCHAR (255) NOT NULL ,
Senha VARCHAR (255) NOT NULL,
Id_TipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (Id_TipoUsuario)
);
go
 SELECT * FROM TipoUsuario;
  SELECT * FROM Usuario;
   SELECT * FROM Jogos;
    SELECT * FROM Estudio;






 drop database Inlock_Games_Manha;