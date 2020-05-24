use M_Peoples;

-- Selecionar todos os registros

select * from Funcionarios;

select ID_Funcionario, Nome, Sobrenome from Funcionarios where ID_Funcionario = 1;

select ID_Funcionario, Nome, Sobrenome from Funcionarios;

delete from Funcionarios where ID_Funcionario = 5;

update Funcionarios set Nome = 'Itachi' where ID_Funcionario = 6;

select Funcionarios.Nome, convert(varchar, DataNascimento, 103) as DataNascimento from Funcionarios;