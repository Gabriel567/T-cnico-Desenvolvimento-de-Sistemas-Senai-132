using Senai.Filmes.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Interfaces
{
    interface IGeneroRepository
    {
        //Retorno
        //Esse método lista todos os gêneros
        List<GeneroDomain> Listar();

        //Retorno nomeMetodo(parametro)
        //Esse método cadastra um novo gênero
        //Um objeto genero será cadastrado
        void Cadastrar(GeneroDomain genero);

        void Deletar(int ID);

        void AtualizarIDCorpo(GeneroDomain genero);

        void AtualizarIDURL(int ID, GeneroDomain genero);
    }
}
