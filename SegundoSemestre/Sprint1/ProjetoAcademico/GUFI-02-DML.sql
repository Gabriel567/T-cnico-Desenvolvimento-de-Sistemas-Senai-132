use Gufi_Manha;

insert into TiposUsuarios (Tipo)
values ('Administrador'),
	   ('Comum');

insert into TiposEventos (Tipo)
values ('C#'),
	   ('JS'),
	   ('SQL');

insert into Instituicoes (Nome, CNPJ, Endereco)
values ('Escola SENAI de informática', '12345678901234', 'Alameda de Lima, 535');

insert into Eventos (Nome, AcessoLivre, Descricao, DataEvento, ID_TipoEvento, ID_Instituicao)
values ('Introdução ao C#', 1, 'Conceitos sobre os pilares do C#', '2020-02-20 15:30:06.12345', 1, 1),
	   ('Ciclo de vida', 0, 'Como utilizar os ciclos de vida', '2020-02-25 14:00:0.0000', 2, 1),
	   ('Triggers', 1, 'Como utilizar os triggers', '2020-03-01 20:00:15.12345', 3, 1);

insert into Usuarios (Nome, Email, Senha, Genero, DataCadastro, ID_TipoUsuario)
values ('Gabriel', 'gabriel@gmail.com', '12345', 'Masculino', '2020-02-06 09:20:25.68257', 1),
       ('Jin Woo', 'jinWoo@gmail.com', '09876', 'Masculino', '2020-02-06 10:30:30.12345', 2),
	   ('Levi', 'levi@gmail.com', '01925', 'Masculino', '2020-02-06 11:00:45.6784', 2);

insert into Presencas (Situacao, ID_Usuario, ID_Evento)
values ('Confirmada', 2, 1),
	   ('Não confirmada', 2, 2),
	   ('Confirmada', 3, 3);

	  