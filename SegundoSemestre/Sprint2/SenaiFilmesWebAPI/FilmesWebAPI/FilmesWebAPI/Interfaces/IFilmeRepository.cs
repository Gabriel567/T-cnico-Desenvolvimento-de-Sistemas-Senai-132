using FilmesWebAPI.Controllers;
using FilmesWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebAPI.Interfaces
{
    interface IFilmeRepository
    {
        //Cadastra um novo gênero
        //filme: objeto filme que será cadastrado e lhe será atribuido um gênero
        void Cadastrar(FilmeDomain filme);

        //Lista todos os filmes
        //Retorna uma lista de filmes
        //A lista é do tipo FilmeDomain, pois contém o nome do filme, seu ID e o ID do gênero a que pertence
        List<FilmeDomain> Listar();

        void Deletar(int ID);

        FilmeDomain BuscaPorID(int ID);

        void AtualizarIDURL(int ID, FilmeDomain filme);

        void AtualizarIDCorpo(FilmeDomain genero);
    }
}
