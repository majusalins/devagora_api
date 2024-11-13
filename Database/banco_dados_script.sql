CREATE DATABASE `DevAgora`;
USE `DevAgora` ;

CREATE TABLE `Usuario` (
  `ID_Usuario` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `email` VARCHAR(45) NULL,
  `senha` VARCHAR(20) NULL,
  `data_cadastro` DATE NULL,
  `tipo_usuario` TINYINT NULL,
  PRIMARY KEY (`ID_Usuario`)
  );

CREATE TABLE `Perfil` (
  `ID_Perfil` INT NOT NULL,
  `bio` VARCHAR(100) NULL,
  `foto_perfil` BLOB NULL,
  `habilidades` VARCHAR(100) NULL,
  `experiencias` VARCHAR(100) NULL,
  `Usuário_ID_Usuario` INT NOT NULL,
  PRIMARY KEY (`ID_Perfil`),
  FOREIGN KEY (`Usuário_ID_Usuario`) REFERENCES `Usuário` (`ID_Usuario`)
    );

CREATE TABLE `Rascunho` (
  `ID_Rascunho` INT NOT NULL,
  `conteudo` TEXT(1000) NULL,
  `tipo_rascunho` TINYINT NULL,
  `data_criacao` DATE NULL,
  `data_edicao` DATE NULL,
  `Usuário_ID_Usuario` INT NOT NULL,
  PRIMARY KEY (`ID_Rascunho`),
  FOREIGN KEY (`Usuário_ID_Usuario`) REFERENCES `Usuário` (`ID_Usuario`)
  );

CREATE TABLE `Post` (
  `ID_Post` INT NOT NULL,
  `data_publicacao` DATE NULL,
  `tipo_post` TINYINT NULL,
  `Usuário_ID_Usuario` INT NOT NULL,
  PRIMARY KEY (`ID_Post`),
  FOREIGN KEY (`Usuário_ID_Usuario`) REFERENCES `Usuário` (`ID_Usuario`)
  );

CREATE TABLE `Pergunta` (
  `ID_Pergunta` INT NOT NULL,
  `titulo` VARCHAR(45) NULL,
  `conteudo` TEXT(1000) NULL,
  `Post_ID_Post` INT NOT NULL,
  PRIMARY KEY (`ID_Pergunta`),
  FOREIGN KEY (`Post_ID_Post`) REFERENCES `Post` (`ID_Post`)
);
    
CREATE TABLE `Resposta` (
  `ID_Resposta` INT NOT NULL,
  `titulo` VARCHAR(45) NULL,
  `conteudo` TEXT(1000) NULL,
  `Post_ID_Post` INT NOT NULL,
  `Pergunta_ID_Pergunta` INT NOT NULL,
  PRIMARY KEY (`ID_Resposta`),
  FOREIGN KEY (`Post_ID_Post`) REFERENCES `Post` (`ID_Post`),
  FOREIGN KEY (`Pergunta_ID_Pergunta`) REFERENCES `Pergunta` (`ID_Pergunta`)
);

CREATE TABLE `Tag` (
  `ID_Tag` INT NOT NULL,
  `nome` VARCHAR(35) NULL,
  PRIMARY KEY (`ID_Tag`)
  );

CREATE TABLE `Denúncia` (
  `ID_Denuncia` INT NOT NULL,
  `data_denuncia` DATE NULL,
  `motivo` TEXT(400) NULL,
  `Usuário_ID_Usuario` INT NOT NULL,
  `Post_ID_Post` INT NOT NULL,
  PRIMARY KEY (`ID_Denuncia`),
  FOREIGN KEY (`Usuário_ID_Usuario`) REFERENCES `Usuário` (`ID_Usuario`),
  FOREIGN KEY (`Post_ID_Post`) REFERENCES `Post` (`ID_Post`)
);
    
CREATE TABLE `pergunta_tag` (
  `Pergunta_ID_Pergunta` INT NOT NULL,
  `Tag_ID_Tag` INT NOT NULL,
  PRIMARY KEY (`Pergunta_ID_Pergunta`, `Tag_ID_Tag`),
  FOREIGN KEY (`Pergunta_ID_Pergunta`) REFERENCES `Pergunta` (`ID_Pergunta`),
  FOREIGN KEY (`Tag_ID_Tag`) REFERENCES `Tag` (`ID_Tag`)
);

CREATE TABLE `Favoritos` (
  `Usuário_ID_Usuario` INT NOT NULL,
  `Post_ID_Post` INT NOT NULL,
  PRIMARY KEY (`Usuário_ID_Usuario`, `Post_ID_Post`),
  FOREIGN KEY (`Usuário_ID_Usuario`) REFERENCES `Usuário` (`ID_Usuario`),
  FOREIGN KEY (`Post_ID_Post`) REFERENCES `Post` (`ID_Post`)
);