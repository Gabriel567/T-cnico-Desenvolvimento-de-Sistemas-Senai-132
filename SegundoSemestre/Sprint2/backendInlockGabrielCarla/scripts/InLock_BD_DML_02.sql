use InLock_Games_Manha;

insert into Usuarios(Email, Senha, ID_TipoUsuario)
values
(
	'admin@admin.com', 'admin', 1
),

(
	'cliente@cliente.com', 'cliente', 2
);
GO

insert into Estudios(NomeEstudio)
values
(
	'Blizzard'
),

(
	'Rockstar Studios'
),

(
	'Square Enix'
);
GO

insert into Jogos(NomeJogo, Descricao, DataLancamento, Valor, ID_Estudio)
values
(
	'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '2012-05-15 12:00:00', '99', 1 
),

(
	'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '2018-11-26 13:00:00', '120', 2
);

insert into TiposUsuarios(Titulo)
values
(
	'Administrador'
),

(
	'Cliente'
);
