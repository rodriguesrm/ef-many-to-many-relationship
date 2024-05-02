CREATE DATABASE `mydbef_test`;

USE `mydbef_test`;

ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Pessoa` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `Nascimento` datetime(6) NOT NULL,
  CONSTRAINT `PK_Pessoa` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Tipo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  CONSTRAINT `PK_Tipo` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `PessoaTipo` (
  `PessoaId` int NOT NULL,
  `TipoId` int NOT NULL,
  CONSTRAINT `PK_PessoaTipo` PRIMARY KEY (`PessoaId`, `TipoId`),
  CONSTRAINT `FK_PessoaTipo_Pessoa_PessoaId` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PessoaTipo_Tipo_TipoId` FOREIGN KEY (`TipoId`) REFERENCES `Tipo` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;