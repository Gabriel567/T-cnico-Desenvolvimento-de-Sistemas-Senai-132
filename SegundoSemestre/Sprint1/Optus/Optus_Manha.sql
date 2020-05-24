create database Optus_Manha;

use Optus_Manha;

--Inicio DDL

create table Artistas_Manha(
	ID_Artista int primary key identity,
	Nome varchar (200)
	);

create table Estilos_Manha(
	ID_Estilo int primary key identity,
	Nome  varchar (200)
	);

create table TiposUsuario_Manha(
	ID_TipoUsuario int primary key identity,
	Nome varchar (200)
	);

create table Usuarios_Manha(
	ID_Usuario int primary key identity,
	Nome varchar (200),
	ID_TipoUsuario int foreign key references TiposUsuario_Manha (ID_TipoUsuario)
	);

create table Albuns_Manha(
	ID_Album int primary key identity,
	Nome varchar (200),
	DataLancamento date,
	Minutos int,
	Visualizacoes int,
	ID_Artista int foreign key references Artistas_Manha (ID_Artista),
	ID_Estilo int foreign key references Estilos_Manha (ID_Estilo)
	);

	select * from Artistas_Manha;
	select * from Estilos_Manha;
	select * from TiposUsuario_Manha;
	select * from Usuarios_Manha;
	select * from Albuns_Manha;

	use master;

	drop database Optus_Manha;

--Fim DDL

--Inicio DML

insert into Artistas_Manha (Nome)
values ('Billie Eilish'),
       ('Madonna'),
	   ('Seong Jin Woo'),
	   ('Ed Sheeran'),
	   ('John Lennon'),
	   ('Gabriel de Souza'),
	   ('Jason Mraz');

insert into Estilos_Manha (Nome)
values ('Dubsteps'),
       ('Industrial'),
	   ('Rock'),
	   ('Gótico'),
	   ('Electro house');

insert into TiposUsuario_Manha (Nome)
values ('Comum'),
       ('Artista'),
	   ('Comprador'),
	   ('Boss'),
       ('Administrador');

insert into Usuarios_Manha (Nome, ID_TipoUsuario)
values ('Gabriel de Souza', 5),
       ('Billie Eilish', 2),
	   ('Seong Jin Woo', 4),
	   ('Jason Mraz', 1),
	   ('John Lennon', 3),
	   ('Ed Sheeran', 2),
	   ('Madonna', 2);

insert into Albuns_Manha (Nome, DataLancamento, Minutos, Visualizacoes, ID_Artista, ID_Estilo) 
values ('Darkness', '1980-04-12', 500, 40000, 3, 4),
       ('Dont smile at me', '1990-05-17', 400, 340000, 1, 2),
	   ('Dark', '1995-06-14', 550, 300, 2, 5),
	   ('Light', '1981-08-17', 4210, 200, 4, 2),
	   ('Kayleyin', '1985-12-21', 557, 100, 5, 3),
	   ('Atalandia', '1977-02-24', 5355, 50, 6, 4),
	   ('Ness', '1979-08-06', 4567, 800, 7, 3);

--Fim DML

--Área de delete

delete from Albuns_Manha
where Nome='Ness';

--Área de alteração

update Artistas_Manha
set Nome = 'Rashid'
where ID_Artista = 2; 

update TiposUsuario_Manha
set Nome = 'Invasor'
where ID_TipoUsuario = 3;

update Albuns_Manha
set Visualizacoes = 111
where ID_Album = 5;
