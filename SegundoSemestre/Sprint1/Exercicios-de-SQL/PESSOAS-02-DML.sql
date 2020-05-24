use Pessoas_Manha;

insert into Pessoas (Nome)
values ('Gabriel'),
	   ('Jin Woo');

insert into Telefones (Descricao, ID_Pessoa)
values ('11 98984-7085', 1),
	   ('11 91234-5678', 2);

insert into CNHs (Descricao, ID_Pessoa)
values ('12345678901', 1),
	   ('09876543210', 2);

insert into Emails (Descricao, ID_Pessoa)
values ('gabriel@gmail.com', 1),
	   ('jinWoo@gmail.com', 2);