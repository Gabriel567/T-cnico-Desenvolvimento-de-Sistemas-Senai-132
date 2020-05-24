create database PetClinica_Manha;
use PetClinica_Manha;

create table Donos
(
ID_Dono int primary key identity,
Nome varchar (200)
);
go

create table TiposPet
(
ID_TipoPet int primary key identity,
Tipo varchar(200)
);
go

create table Clinicas 
(
ID_Clinica int primary key identity,
RazaoSocial varchar(200),
Endereco varchar(200)
);
go

create table Racas
(
ID_Raca int primary key identity,
Raca varchar(200),
ID_TipoPet int foreign key references TiposPet (ID_TipoPet)
);
go

create table Veterinarios 
(
ID_Veterinario int primary key identity,
Nome varchar(200),
CRMV varchar(200),
ID_Clinica int foreign key references Clinicas (ID_Clinica)
);
go

create table Pets
(
ID_Pet int primary key identity,
Nome varchar(200),
Telefone varchar(200),
ID_Dono int foreign key references Donos (ID_Dono),
ID_Raca int foreign key references Racas (ID_Raca)
);
go

create table Atendimentos
(
ID_Atendimento int primary key identity,
DataConsulta date,
Descricao varchar(200),
ID_Pet int foreign key references Pets (ID_Pet),
ID_Veterinario int foreign key references Veterinarios (ID_Veterinario)
);
go

