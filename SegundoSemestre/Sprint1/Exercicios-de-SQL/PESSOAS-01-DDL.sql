create table Pessoas_Manha;
use Pessoas_Manha;

create table Pessoas
(
ID_Pessoa int primary key identity,
Nome varchar (200)
);

create table Telefones
(
ID_Telefone int primary key identity,
Descricao varchar (200),
ID_Pessoa int foreign key references Pessoas (ID_Pessoa)
);

create table CNHs
(
ID_CNH int primary key identity,
Descricao varchar (200),
ID_Pessoa int foreign key references Pessoas (ID_Pessoa)
);

create table Emails
(
ID_Emails int primary key identity,
Descricao varchar (200),
ID_Pessoa int foreign key references Pessoas (ID_Pessoa)
);