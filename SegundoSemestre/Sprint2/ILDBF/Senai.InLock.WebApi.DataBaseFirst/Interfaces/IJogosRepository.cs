using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IJogosRepository
    {
        ///<summary>
        ///Lista todos os jogos
        ///</summary>
        ///<retuns>Uma lista de jogos</retuns>
        List<Jogos> Listar();

        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(Jogos novoJogo);

        ///<summary>
        ///Busca um jogo através de seu ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado</returns>
        Jogos BuscaPorID(int id);
    }
}
