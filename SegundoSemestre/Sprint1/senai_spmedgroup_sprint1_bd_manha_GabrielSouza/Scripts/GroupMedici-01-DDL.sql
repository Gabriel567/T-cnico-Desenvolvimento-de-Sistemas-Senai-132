create database GroupMedici;
go

use GroupMedici;
go

create table Enderecos
(
	ID_Endereco int primary key identity,
	Rua varchar(200) not null,
	Numero int unique not null,
	Cidade varchar(200) not null
);
go

create table SituacoesConsultas
(
	ID_SituacaoConsulta int primary key identity,
	SituacaoConsulta varchar(200) not null 
);
go

create table TiposUsuarios
(
	ID_TipoUsuario int primary key identity,
	TipoUsuario varchar(200) not null
);
go

create table Clinicas
(
	ID_Clinica int primary key identity,
	NomeFantasia varchar(200) not null,
	RazaoSocial varchar(200) unique not null,
	CNPJ varchar(18) unique not null,
	HorarioFuncionamento varchar(200) not null,
	ID_Endereco int foreign key references Enderecos(ID_Endereco)
);
go

create table Usuarios
(
	ID_Usuario int primary key identity,
	Nome varchar(200) not null,
	Email varchar(200) not null,
	RG varchar(12) unique not null,
	CPF varchar(14) unique not null,
	DataNascimento datetime2 not null,
	Genero varchar(200) not null,
	Senha varchar(200) not null,
	ID_TipoUsuario int foreign key references TiposUsuarios(ID_TipoUsuario),
	ID_Endereco int foreign key references Enderecos(ID_Endereco)
);
go

create table Medicos
(
	ID_Medico int primary key identity,
	Nome varchar(200) not null,
	Email varchar(200) unique not null,
	RG varchar(12) unique not null,
	CRM varchar(6) unique not null,
	CPF varchar(14) unique not null,
	Especialidade varchar(200) not null,
	Genero varchar(20) not null,
	Senha varchar(200) not null,
	ID_TipoUsuario int foreign key references TiposUsuarios(ID_TipoUsuario),
	ID_Endereco int foreign key references Enderecos(ID_Endereco)
);
go

create table Consultas
(
	ID_Consulta int primary key identity,
	Descricao varchar(200),
	DataAgendamento datetime2,
	ID_Usuario int foreign key references Usuarios(ID_Usuario),
	ID_Medico int foreign key references Medicos(ID_Medico),
	ID_SituacaoConsulta int foreign key references SituacoesConsultas(ID_SituacaoConsulta),
	ID_Clinica int foreign key references Clinicas(ID_Clinica)
);
go

use master;
go

drop database GroupMedici;
go