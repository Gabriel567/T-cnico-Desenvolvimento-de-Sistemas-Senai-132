--Comando de criação do banco de dados (create database)
--DDL: Linguagem de definição de dados, Inicio
create database RoteiroLivros;

--Comando para usar o banco criado (use)
use RoteiroLivros;

--Criar primeiramente as tabelas com menos chaves estrangeiras

create table Generos(
	IDGenero int primary key identity,
	Nome varchar(200) not null
	);

	create table Autores(
	IDAutor int primary key identity,
	Nome varchar(200) not null
	);

	--Chaves estrangeiras são adicionadas por último
	--Chaves estrangeiras são atributos, mas oriundos de outra tabela
	--Referencia a tabela e seu ID
	--Não usar identity na chave estrangeira, pois a meta é repetir números
	--NÃO ESQUECER DE USAR A VÍRGULA QUANDO HOUVER QUEBRA DE LINHA
	create table Livros(
	IDLivro int primary key identity,
	Nome varchar(200),
	IDGenero int foreign key references Generos(IDGenero),
	IDAutor int foreign key references Autores(IDAutor)
	);

	--DQL: Comando de consulta
	--USAR ; NOS SELECT
	select * from Generos;
	select * from Autores;
	select * from Livros

	use master;

	drop database RoteiroLivros;

	--DDL: Linguagem de definição de dados, Fim

	--DML: Linguagem de manipulação de dados, Inicio

	--Inserção de dados

	insert into Autores (Nome)
	values ('Stephen King'),
	       ('Monterio Lobato'),
		   ('Paulo Coelho'),
		   ('Augusto Cury'),
		   ('George R.R. Martin');

	insert into Generos (Nome)
	values ('Horror'),
	       ('Suspense'),
		   ('Romance'),
		   ('Ficção científica'),
		   ('Fábula');

	insert into Livros (Nome, IDGenero, IDAutor)
	values ('Doutor Sono', 1, 1),
	       ('O Presidente Negro' , 2, 2),
		   ('O Alquimista', 3, 3),
		   ('O Vendedor de Sonhos', 4, 4),
		   ('A Dança dos Dragões', 5, 5);

	--Alteração de dados

	update Generos
	set Nome = 'Crônica'
	where IDGenero = 4;