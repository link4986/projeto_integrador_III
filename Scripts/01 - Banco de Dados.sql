CREATE DATABASE Ouvidoria
USE Ouvidoria

CREATE TABLE Perfil(
	CodPerfil INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
)

CREATE TABLE Usuario(
	CodUsuario	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	Login VARCHAR(255) NOT NULL,
	Senha VARCHAR(255) NOT NULL,	
	CodPerfil INT NOT NULL,
	Ativo BIT NOT NULL DEFAULT 0
	CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (CodPerfil) REFERENCES Perfil (CodPerfil),
)


CREATE TABLE Prioridade(
	CodPrioridade INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
)

CREATE TABLE Status(
	CodStatus INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
)

CREATE TABLE Categoria(
	SiglaCategoria VARCHAR(1) PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255) NOT NULL
)

CREATE TABLE TipoReclamacao(
	CodTipoReclamacao INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
	FlagDenuncia BIT NOT NULL DEFAULT 0,
	FlagSugestao BIT NOT NULL DEFAULT 0,
	FlagReclamacao BIT NOT NULL DEFAULT 0
)


CREATE TABLE Reclamacao (
	CodReclamacao UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	SiglaCategoria VARCHAR(1),
	CodTipoReclamacao INT  NOT NULL,	
	Assunto VARCHAR(255) NOT NULL,
	Mensagem VARCHAR(4000) NOT NULL,
	FlagNotificado BIT NOT NULL DEFAULT 0,
	Contato VARCHAR(255),
	DataRegistro DATETIME NOT NULL,
	DataResposta DATETIME,
	CodUsuarioResposta INT,
	CodStatus INT NOT NULL DEFAULT 1,
	CodPrioridade INT NOT NULL DEFAULT 1,
	CodUsuario INT NOT NULL,
	CONSTRAINT FK_Reclamacao_Status FOREIGN KEY (CodStatus) REFERENCES Status (CodStatus),
	CONSTRAINT FK_Reclamacao_Prioridade FOREIGN KEY  (CodPrioridade) REFERENCES Prioridade (CodPrioridade),
	CONSTRAINT FK_Reclamacao_CodUsuario FOREIGN KEY  (CodUsuario) REFERENCES Usuario (CodUsuario),
	CONSTRAINT FK_Reclamacao_CodUsuarioResposta FOREIGN KEY  (CodUsuarioResposta) REFERENCES Usuario (CodUsuario),
	CONSTRAINT FK_Reclamacao_TipoReclamacao FOREIGN KEY  (CodTipoReclamacao) REFERENCES TipoReclamacao (CodTipoReclamacao),
	CONSTRAINT FK_Reclamacao_Categoria FOREIGN KEY  (SiglaCategoria) REFERENCES Categoria (SiglaCategoria),
)



CREATE TABLE ReclamacaoArquivo(
	CodReclamacaoArquivo UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CodReclamacao UNIQUEIDENTIFIER NOT NULL,
	NomeArquivo VARCHAR(255),
	Extensao VARCHAR(10),
	CONSTRAINT FK_ReclamacaoArquivo_Reclamacao FOREIGN KEY (CodReclamacao) REFERENCES Reclamacao (CodReclamacao),

)