--2.	Criar as tabelas no banco de dados;
CREATE DATABASE Hroads;

 USE Hroads;
 CREATE TABLE Jogo
 (
	idJogo INT PRIMARY KEY IDENTITY
	,NomeJogo VARCHAR(100) NOT NULL
 );

 CREATE TABLE Classe
 (
	idClasse INT PRIMARY KEY IDENTITY
	,NomeClasse VARCHAR(100) NOT NULL
 );

 CREATE TABLE Tipo
 (
	idTipo INT PRIMARY KEY IDENTITY
	,NomeTipo VARCHAR(100) NOT NULL
 );

 CREATE TABLE Habilidade
 (
	idHabilidade INT PRIMARY KEY IDENTITY
	,idTipo INT FOREIGN KEY REFERENCES Tipo(idTipo)
	,NomeHabilidade VARCHAR(100) NOT NULL
 );
EXEC sp_rename 'Habilidade.NomeHbilidade', 'NomeHabilidade', 'COLUMN';


 CREATE TABLE ClasseHabilidade
 (
	idClasse INT FOREIGN KEY REFERENCES Classe(idClasse)
	,idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade)
 );

 CREATE TABLE Personagem 
 (
	idPersonagem INT PRIMARY KEY IDENTITY
	,idJogo INT FOREIGN KEY REFERENCES Jogo(idJogo)
	,idClasse INT FOREIGN KEY REFERENCES Classe(idClasse)
	,NomePersonagem VARCHAR(100) NOT NULL
	,CapacidadeMaximaDeVida INT NOT NULL 
	,CapacidadeMaximaDeMana INT NOT NULL
	,DataAtualizacao DATE NOT NULL
	,DataCriacao DATE NOT NULL
 );


 CREATE TABLE TiposUsuarios
 (
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,nomeTipo		VARCHAR(200) NOT NULL
 );

 CREATE TABLE Usuarios
 (
	idUsuario	INT PRIMARY KEY IDENTITY
	,idTipoUsuario	INT FOREIGN KEY REFERENCES TiposUsuarios(idTipoUsuario)
	,email			VARCHAR(200) NOT NULL UNIQUE
	,senha			VARCHAR(200) NOT NULL
 );
