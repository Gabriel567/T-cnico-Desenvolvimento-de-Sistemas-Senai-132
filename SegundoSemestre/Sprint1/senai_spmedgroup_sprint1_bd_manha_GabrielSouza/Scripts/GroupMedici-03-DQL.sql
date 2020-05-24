use GroupMedici;

-- Visualiza��o geral:
select * from Usuarios;
select * from Clinicas;
select * from Medicos;
select * from Consultas;
select * from SituacoesConsultas;
select * from TiposUsuarios;
select * from Enderecos;

-- Todas as consultas
select Descricao, DataAgendamento, Usuarios.Nome, Medicos.Nome, SituacaoConsulta, Clinicas.NomeFantasia
from SituacoesConsultas
inner join Consultas on SituacoesConsultas.ID_SituacaoConsulta = Consultas.ID_SituacaoConsulta
inner join Medicos on Consultas.ID_Medico = Medicos.ID_Medico
inner join Usuarios on Medicos.ID_TipoUsuario = Usuarios.ID_TipoUsuario
inner join Clinicas on Usuarios.ID_Endereco = Clinicas.ID_Endereco;

select Usuarios.Nome, Usuarios.RG, DataAgendamento, Descricao, SituacaoConsulta, Medicos.Nome, Clinicas.NomeFantasia
from Clinicas
inner join Usuarios on Clinicas.ID_Endereco = Usuarios.ID_Endereco
inner join Medicos on Medicos.ID_Endereco = Usuarios.ID_Endereco
inner join Consultas on Consultas.ID_Medico = Medicos.ID_Medico
inner join SituacoesConsultas on SituacoesConsultas.ID_SituacaoConsulta = Consultas.ID_SituacaoConsulta;

-- Consultas e m�dicos
select Medicos.Nome, RG, CRM, Especialidade, DataAgendamento, Descricao, SituacaoConsulta, Clinicas.NomeFantasia
from Medicos 
inner join Consultas on Medicos.ID_Medico = Consultas.ID_Medico
inner join SituacoesConsultas on SituacoesConsultas.ID_SituacaoConsulta = Consultas.ID_SituacaoConsulta
inner join Clinicas on Clinicas.ID_Clinica = Consultas.ID_Clinica;

-- M�dicos e especialidades
select Medicos.Nome, Especialidade
from Medicos;

-- M�dicos e cl�nicas
select Medicos.Nome, CRM, Especialidade, Clinicas.NomeFantasia, CNPJ
from Medicos
inner join Consultas on Medicos.ID_Medico = Consultas.ID_Medico
inner join Clinicas on Consultas.ID_Clinica = Clinicas.ID_Clinica;

-- Fun��o para retornar � quantidade de m�dicos de uma determinada especialidade
select count(Especialidade) as N�meroMedicos
from Medicos
where Especialidade = 'Cirurgi�o pl�stico';

-- Converter a data de nascimento dos usu�rios para mm/dd/yyyy
select Usuarios.Nome, convert(varchar, DataNascimento, 103) as DataNascimento from Usuarios;

-- Criou uma fun��o para que retorne � idade do usu�rio a partir de uma determinada stored procedure
select Usuarios.Nome, datediff(year, '', getdate()) as Idade from Usuarios where ID_Usuario = 1;
create procedure IdadeUsuario
@CampoBusca varchar(200)
as







































