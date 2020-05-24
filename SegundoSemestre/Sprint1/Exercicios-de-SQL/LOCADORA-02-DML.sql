use Locadora_Manha;
go

insert into Marcas (Nome)
values ('Mercedes-Benz'),
       ('BMW'),
	   ('Volvo');
go

insert into Empresas (Nome)
values ('Unity'),
	   ('Finder'),
	   ('Sellder');
go

insert into Modelos(Nome, ID_Marca)
values ('CL4', 1),
	   ('Roadster', 2),
	   ('Velostery', 3);
go

insert into Clientes (Nome, CPF)
values ('Gabriel', '123.456.789-01'),
	   ('Jin Woo', '098.765.432-10'),
	   ('Levi', '135.791.357-80');
go

insert into Veiculos (Placa, ID_Empresa, ID_Modelo)
values ('HFK-4567', 1, 1),
	   ('VSK-6862', 2, 2),
	   ('BIW-6391', 3, 3);
go

insert into Alugueis (DataInicio, DataFim, ID_Cliente, ID_Veiculo)
values ('2020-02-01', '2020-02-10', 1, 1),
       ('2020-02-05', '2020-02-15', 2, 2),
	   ('2020-02-10', '2020-02-20', 3, 3);
go