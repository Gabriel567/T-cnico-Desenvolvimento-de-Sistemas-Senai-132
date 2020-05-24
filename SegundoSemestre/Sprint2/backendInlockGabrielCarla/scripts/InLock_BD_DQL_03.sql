use InLock_Games_Manha;

-- Listar todos os usu�rios
select Email, Senha, TiposUsuarios.Titulo from Usuarios inner join TiposUsuarios on Usuarios.ID_TipoUsuario = TiposUsuarios.ID_TipoUsuario;

-- Listar todos os est�dios
select NomeEstudio from Estudios;

-- Listar todos os jogos
select NomeJogo, Descricao, DataLancamento, Valor from Jogos;

-- Listar todos os jogos e seus respectivos est�dios
select Jogos.NomeJogo, Estudios.NomeEstudio from Jogos inner join Estudios on Estudios.ID_Estudio = Jogos.ID_Estudio; 

-- Buscar e trazer na lista todos os est�dios, mesmo que eles n�o contenham nenhum jogo de refer�ncia
select Jogos.NomeJogo, Estudios.NomeEstudio from Jogos right join Estudios on Estudios.ID_Estudio = Jogos.ID_Estudio; 

-- Buscar um usu�rio por email e senha
select Email, Senha from Usuarios where Email = '' and Senha = '';

-- Buscar um jogo por IdJogo
select NomeJogo from Jogos where ID_Jogo = 1;

select NomeEstudio from Estudios where ID_Estudio = 1;