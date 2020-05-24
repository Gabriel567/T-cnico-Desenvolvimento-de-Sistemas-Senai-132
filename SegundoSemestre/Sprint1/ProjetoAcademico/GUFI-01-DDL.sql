-- Criação do banco de dados de nome Gufi
create database Gufi_Manha;

-- Define o banco de dados que séra utilizado
use Gufi_Manha;

-- Criação das tabelas
create table TiposUsuarios
(
	ID_TipoUsuario int primary key identity,
	Tipo varchar(200) unique not null
);

create table TiposEventos
(
	ID_TipoEvento int primary key identity,
	Tipo varchar(200) not null
);

create table Instituicoes
(
	ID_Instituicao int primary key identity,
	Nome varchar(200) unique not null,
	CNPJ char(14) unique not null,
	Endereco varchar(200) unique not null
);

create table Eventos
(
	ID_Evento int primary key identity,
	Nome varchar(200),
	AcessoLivre bit default (1) not null,
	Descricao varchar(200),
	DataEvento datetime2,
	ID_TipoEvento int foreign key references TiposEventos (ID_TipoEvento),
	ID_Instituicao int foreign key references Instituicoes (ID_Instituicao)
);

create table Usuarios
(
	ID_Usuario int primary key identity,
	Nome varchar(200) not null,
	Email varchar(200) unique not null,
	Senha varchar(200) not null,
	Genero varchar(200),
	DataCadastro datetime2,
	ID_TipoUsuario int foreign key references TiposUsuarios (ID_TipoUsuario)
);

create table Presencas
(
	ID_Presenca int primary key identity,
	Situacao varchar(200) not null,
	ID_Usuario int foreign key references Usuarios (ID_Usuario),
	ID_Evento int foreign key references Eventos (ID_Evento)
);

exec sp_rename 'Usuarios.[Nome]', 'Usuario_Nome', 'column'
exec sp_rename 'Eventos.[Nome]', 'Evento_Nome', 'column'

use master;

drop database Gufi_Manha;