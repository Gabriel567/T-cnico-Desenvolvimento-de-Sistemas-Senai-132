--Inicio DDL

create database vivoOuMorto;

use vivoOuMorto;

create table Seres(
	ID_Ser int primary key identity,
	Nome varchar (200), 
	Morto bit not null
	);

	select * from Seres;

	use master;

	drop database vivoOuMorto;

--Fim DDL

--Inicio DML

insert into Seres
values ('John Lennon', 1),
	   ('Fredie Mercury', 1),
	   ('Charmander', 0),
	   ('L', 1),
	   ('Otsuksuky', 0),
	   ('Goten', 0),
	   ('Feitan', 0),
	   ('Izumi', 1);


