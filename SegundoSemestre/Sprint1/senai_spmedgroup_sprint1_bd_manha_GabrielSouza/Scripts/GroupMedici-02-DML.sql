use GroupMedici;

insert into SituacoesConsultas (SituacaoConsulta)
values ('Agendada'),
	   ('Realizada'),
	   ('Cancelada');

insert into TiposUsuarios (TipoUsuario)
values ('Administrador'),
	   ('Médico'),
	   ('Paciente');

insert into Enderecos (Rua, Numero, Cidade)
values ('Rua Pirapora do Bom Jesus', '1700', 'SP'),
       ('Rua Cavo Tagoo', '77', 'SP'),
	   ('Rua Cavo Cagoo', '78', 'SP'),
	   ('Rua Limpydissey', '45', 'SP'),
	   ('Rua Oziz', '2144', 'SP'),
	   ('Rua Demagogo', '890', 'SP'),
	   ('Rua Crupazo', '9032', 'SP'),
	   ('Rua Tavarez', '3829', 'SP'),
	   ('Rua Adrissty', '345', 'SP'),
	   ('Rua Yug', '888', 'SP'),
	   ('Rua Olimpykos', '9898', 'SP'),
	   ('Rua Arise', '606', 'SP'),
	   ('Rua Freedom', '989', 'SP'),
	   ('Rua Death', '333', 'SP'),
	   ('Rua Parasy', '907', 'SP'),
	   ('Rua Cany', '234', 'SP');

insert into Clinicas (NomeFantasia, RazaoSocial, CNPJ, HorarioFuncionamento, ID_Endereco)
values ('GroupMed', 'Group Medici Ltda', '12.345.678/9012-34', '24h', 1);

insert into Usuarios (Nome, Email, RG, CPF, DataNascimento, Genero, Senha, ID_TipoUsuario, ID_Endereco)
values ('Gabriel de Souza', 'gabriel@gmail.com', '58.468.891-1', '123.456.789-86', '2000-01-01 20:30:00.00', 'Masculino', '123456', 1, 2),
       ('Thais Cristina', 'thais@gmail.com', '41.421.567-5', '654.246.764-53', '2001-01-01 20:30:00.00', 'Feminino', '1234567', 1, 3),
	   ('Sophia Martins', 'sophia@gmail.com', '52.159.765-4', '456.218.643-68', '2002-01-01 20:30:00.00', 'Feminino', '12345678', 1, 4),
	   ('Augusto Matos', 'augusto@gmail.com', '43.135.665-7', '876.653.134-67', '2003-01-01 20:30:00.00', 'Masculino', '123456789', 3, 5),
	   ('Luis Lima', 'luis@gmail.com', '23.456.731-5', '652.212.468-99', '2004-01-01 20:30:00.00', 'Masculino', '1234567890', 3, 6),
	   ('Guilherme Parrot', 'guilherme@gmail.com', '76.542.157-8', '457.431.346-11', '2005-01-01 20:30:00.00', 'Masculino', '098765', 3, 7),
	   ('Leonardo da Vinci', 'leonardo@gmail.com', '12.345.736-9', '987.542.241-65', '2006-01-01 20:30:00.00', 'Masculino', '09876543', 3, 8),
	   ('Rapahel Vicenzi', 'rapahel@gmail.com', '76.456.410-2', '678.421.456-90','2007-01-01 20:30:00.00', 'Masculino', '5464836', 3, 9),
	   ('Splinter Yakaza', 'splinter@gmail.com', '98.763.135-2', '679.246.123-66', '2008-01-01 20:30:00.00', 'Masculino', '543974', 3, 10),
	   ('Altair', 'altair@gmail.com', '55.655.087-3', '981.358.242-30', '2009-01-01 20:30:00.00', 'Masculino', '54739264', 3, 11);

insert into Medicos (Nome, Email, RG, CRM, CPF, Especialidade, Genero, Senha, ID_TipoUsuario, ID_Endereco)
values ('Jin Woo', 'jinWoo@gmail.com', '64.849.542-8', '12.345', '764.282.578-88', 'Cirurgião plástico', 'Masculino', 'qazwsx', 2, 12),
       ('Levi Rivaille', 'levi@gmail.com', '12.743.097-9', '54.432', '654.783.124-67', 'Cirurgião geral', 'Masculino', 'edcrfv', 2, 13),
	   ('Uchiha Itachi', 'itachi@gmail.com', '44.327.524-2', '76.890', '312.357.997-76', 'Ortopedista', 'Masculino', 'tgbyhn', 2, 14),
	   ('Shinichi', 'shinichi@gmail.com', '67.532.137-5', '13.462', '431.309.886-34', 'Dermatologista', 'Masculino', 'yhnujm', 2, 15),
	   ('Kaneki', 'kaneki@gmail.com', '57.531.445-7', '84.285', '875.214.682-43', 'Hematologia', 'Masculino', 'ikmnju', 2, 16);

insert into Consultas (Descricao, DataAgendamento, ID_Usuario, ID_Medico, ID_SituacaoConsulta, ID_Clinica)
values ('Rinoplastia, diminuição do nariz', '2020-02-01 08:00:00', 4, 1, 1, 1),
       ('Retirada da hérnia umbilical', '2020-02-02 09:00:00', 4, 2, 2, 1),
	   ('Tratamento de fratura no punho', '2020-02-03 10:00:00', 5, 3, 3, 1),
       ('Retirada de corpo estranho subcutâneo', '2020-02-04 11:00:00', 5, 4, 1, 1),
	   ('Mielograma', '2020-02-05 12:00:00', 6, 5, 2, 1),
       ('Otoplastia, diminuição da orelha', '2020-02-06 13:00:00', 6, 1, 3, 1),
	   ('Retirada da hérnia', '2020-02-07 14:00:00', 7, 2, 1, 1),
	   ('Tratamento de luxação nas falanges', '2020-02-08 15:00:00', 7, 3, 2, 1),
       ('Exérese de tumor', '2020-02-09 16:00:00', 8, 4, 3, 1),
	   ('Hemograma', '2020-02-10 17:00:00', 8, 5, 1, 1),
       ('Ninfoplastia, diminuição dos grandes lábios', '2020-02-11 18:00:00', 9, 1, 1, 1),
	   ('Retirada de cálculos biliares', '2020-02-12 19:00:00', 9, 2, 2, 1),
       ('Cirurgia para tratar gigantismo na mão direita', '2020-02-13 20:00:00', 10, 3, 2, 1),
	   ('Biópsia de pele', '2020-02-14 21:00:00', 10, 4, 2, 1);

select * from TiposUsuarios;
select * from Usuarios;
select * from Medicos;
select * from Consultas;
select * from SituacoesConsultas;
select * from Enderecos;
select * from Clinicas;