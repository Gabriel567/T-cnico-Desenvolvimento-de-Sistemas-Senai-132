using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param="email">E-mail do usuário</param>
        ///<param="senha">Senha do usuário</param>
        UsuariosDomain BuscarPorEmailSenha(string email, string senha);
    }
}
