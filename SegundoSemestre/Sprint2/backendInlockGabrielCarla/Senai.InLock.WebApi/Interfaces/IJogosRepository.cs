using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogosRepository
    {
        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void CadastrarJogo(JogosDomain novoJogo);

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogosDomain> ListarJogos();
    }
}
