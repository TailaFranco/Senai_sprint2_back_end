CREATE DATABASE M_Peoples_T_Peoples;
GO

USE M_Peoples_T_Peoples;
GO

CREATE TABLE Funcionarios
(
	idFuncionario	INT PRIMARY KEY IDENTITY
	,nome			VARCHAR(100)
	,sobrenome		VARCHAR(100)
);
GO