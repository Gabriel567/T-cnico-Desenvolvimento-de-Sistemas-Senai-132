use Gufi_Manha;

select * from Eventos;
select * from Instituicoes;
select * from TiposEventos;
select * from Presencas;
select * from Usuarios;

-- APESAR DO SUBLINHADO VERMELHO OS COMANDOS FUNCIONAM

--Listar todos os usuários cadastrados
select * from Usuarios;

--Listar todas as instituições cadasradas
select * from Instituicoes;

--Listar todos os tipos de evento
select Tipo from TiposEventos;

--Listar todos os eventos 
select Evento_Nome, Tipo, DataEvento, case AcessoLivre when 0 then 'Privado' when 1 then 'Público' end as restricao, Descricao, Nome, CNPJ, Endereco from Instituicoes inner join Eventos on Instituicoes.ID_Instituicao = Eventos.ID_Instituicao inner join TiposEventos on TiposEventos.ID_TipoEvento = Eventos.ID_TipoEvento;

create trigger AlterarBool
on Eventos
for insert
as
begin

	declare
			@ID_Evento int,
			@Evento_Nome varchar(200),
			@AcessoLivre bit,
			@Descricao varchar(200),
			@DataEvento datetime2,
			@ID_TipoEvento int,
			@ID_Instituicao int;
	select
			@ID_Evento = ID_Evento,
			@Evento_Nome = Evento_Nome,
			@AcessoLivre = AcessoLivre,
			@Descricao = Descricao,
			@DataEvento = DataEvento,
			@ID_TipoEvento = ID_TipoEvento,
			@ID_Instituicao = ID_Instituicao
	from
			inserted into Eventos
			(
				AcessoLivre
			)
			values ()


end

--Listar apenas os eventos que são públicos
select Evento_Nome, Tipo, DataEvento, AcessoLivre = 'Púlico', Descricao, Nome, CNPJ, Endereco from Instituicoes inner join Eventos on Instituicoes.ID_Instituicao = Eventos.ID_Instituicao inner join TiposEventos on TiposEventos.ID_TipoEvento = Eventos.ID_TipoEvento where AcessoLivre = 1;

-- Listar todos os eventos que um determinado usuário participa
-- Apesar de estar com o sublinhado vermelho, o comando funciona
select Eventos.Evento_Nome, Descricao, DataEvento, Usuarios.Usuario_Nome, Email, Genero, DataCadastro from Eventos inner join Presencas on Eventos.ID_Evento = Presencas.ID_Evento inner join Usuarios on Usuarios.ID_Usuario = Presencas.ID_Usuario where Situacao = 'Confirmada';



