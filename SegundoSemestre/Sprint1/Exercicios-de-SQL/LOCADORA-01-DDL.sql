create database Locadora_Manha;
use Locadora_Manha;
go

create table Marcas
(
ID_Marca int primary key identity,
Nome varchar (200)
);
go

create table Empresas
(
ID_Empresa int primary key identity,
Nome varchar (200)
);
go

create table Modelos
(
ID_Modelo int primary key identity,
Nome varchar (200),
ID_Marca int foreign key references Marcas (ID_Marca)
);
go

create table Clientes
(
ID_Cliente int primary key identity,
Nome varchar (200),
CPF varchar (200)
);
go

create table Veiculos
(
ID_Veiculo int primary key identity,
Placa varchar (200),
ID_Modelo int foreign key references Modelos (ID_Modelo),
ID_Empresa int foreign key references Empresas (ID_Empresa)
);
go

create table Alugueis
(
ID_Aluguel int primary key identity,
DataInicio date,
DataFim date,
ID_Cliente int foreign key references Clientes (ID_Cliente),
ID_Veiculo int foreign key references Veiculos (ID_Veiculo)
);
go