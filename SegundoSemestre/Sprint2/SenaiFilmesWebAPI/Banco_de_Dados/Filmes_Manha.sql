create database Filmes_Manha;

use Filmes_Manha;

create table Generos
(
	ID_Genero int primary key identity,
	Genero varchar(200)  not null
);

create table Filmes
(
	ID_Filme int primary key identity,
	NomeFilme varchar(200),
	ID_Genero int foreign key references Generos (ID_Genero)
);

use master;

drop database Filmes_Manha;

insert into Generos (Genero)
values ('Ação e aventura'),
	   ('Terror'),
	   ('Romance');

insert into Filmes (NomeFilme, ID_Genero)
values ('Busca Explosiva', 1),
	   ('Invocação do Mal', 2),
	   ('Comer, Rezar e Amar', 3);

select Filmes.NomeFilme as Filme, Generos.Genero 
from Filmes
inner join Generos on Filmes.ID_Genero = Generos.ID_Genero;

delete from Filmes where ID_Filme = 2;