using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudiosRepository
    {
        ///<summary>
        ///Cadastro de um novo estúdio
        ///</summary>
        ///<param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void CadastrarEstudio(EstudiosDomain novoEstudio);

        ///<summary>
        ///Lista todos os estúdios
        ///</summary>
        /// <returns>Uma lista de estúdios</returns>
        List<EstudiosDomain> ListarEstudios();
    }
}
