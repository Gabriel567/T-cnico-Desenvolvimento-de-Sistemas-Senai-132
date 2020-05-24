create database InLock_Games_Manha;

use InLock_Games_Manha;

create table Estudios
(
	ID_Estudio int primary key identity,
	NomeEstudio varchar(200) not null
);
GO

create table Jogos
(
	ID_Jogo int primary key identity,
	NomeJogo varchar(200) not null,
	Descricao varchar(200) not null,
	DataLancamento datetime2 not null,
	Valor decimal not null,
	ID_Estudio int foreign key references Estudios(ID_Estudio)
);
GO

create table TiposUsuarios
(
	ID_TipoUsuario int primary key identity,
	Titulo varchar(200) not null
);
GO

create table Usuarios
(
	ID_Usuario int primary key identity,
	Email varchar(200),
	Senha varchar(200),
	ID_TipoUsuario int foreign key references TiposUsuarios(ID_TipoUsuario)
);
GO

use master;

drop database InLock_Games_Manha;