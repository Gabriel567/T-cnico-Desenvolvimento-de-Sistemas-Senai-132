create database Musica;

use Musica;

create table EstilosMusicais_Manha(
	IDEstiloMusical int primary key identity,
	Nome varchar(200)
	);

	create table Artistas_Manha(
	IDArtista int primary key identity,
	Nome varchar(200),
	IDEstiloMusical int foreign key references EstilosMusicais_Manha(IDEstiloMusical)
	);

	select * from EstilosMusicais_Manha;
	select * from Artistas_Manha;

	--Adicionar coluna (add)
	alter table Artistas_Manha
	add DataNascimento date;

	select * from Artistas_Manha;

	--Modificação de coluna (alter column)
	alter table Artistas_Manha
	alter column Nome char;

	select * from Artistas_Manha;

	--Apagar coluna (drop)
	alter table Artistas_Manha
	drop column Nome;

	select * from Artistas_Manha;