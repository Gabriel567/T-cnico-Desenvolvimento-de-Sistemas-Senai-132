use PetClinica_Manha;
go

insert into TiposPet (Tipo)
values ('Cachorro'),
       ('Gato');
go

insert into Donos (Nome)
values ('Gabriel'),
       ('Jin Woo');
go

insert into Racas (Raca, ID_TipoPet)
values ('Labrador', 1),
       ('Siames', 2);
go

insert into Clinicas (RazaoSocial, Endereco)
values ('Pet Care', 'Alameda Barao, 345'),
       ('Clinica Safe', 'Pirapora do Bom Jesus');
go

insert into Veterinarios (Nome, CRMV, ID_Clinica)
values ('Levi', '123', 1),
       ('Alucard', '455', 2);
go

insert into Pets (Nome, Telefone, ID_Dono, ID_Raca)
values ('Apollo', '11 94578-6382', 1, 1),
       ('Kathryna', '11 95372-691', 2, 2);
go

insert into Atendimentos (DataConsulta, Descricao, ID_Pet, ID_Veterinario)
values ('2020-02-10', 'Tudo em ordem', 1, 1),
       ('2020-02-20', 'Doença grave detectada', 2, 2);
go