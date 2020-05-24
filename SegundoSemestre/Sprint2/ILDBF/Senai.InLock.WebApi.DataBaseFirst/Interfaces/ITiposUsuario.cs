using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface ITiposUsuario
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca por ID um tipo de usuário
        /// </summary>
        /// <param name="id">id que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        TiposUsuario BuscaPorId(int id); //É do tipo TiposUsuario pois estamos buscando algo que já esta criado

        /// <summary>
        /// Faz o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        void Cadastro(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario
        /// </summary>
    }
}
