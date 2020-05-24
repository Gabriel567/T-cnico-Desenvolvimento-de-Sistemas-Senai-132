create database M_Peoples;

use M_Peoples;

-- Criar o banco de dados M_Peoples;
-- Criar a tabela de Funcionarios contendo nome e sobrenome.

create table Funcionarios
(
	ID_Funcionario int primary key identity,
	Nome varchar(200) not null,
	Sobrenome varchar(200) not null,
	DataNascimento datetime2 not null
);