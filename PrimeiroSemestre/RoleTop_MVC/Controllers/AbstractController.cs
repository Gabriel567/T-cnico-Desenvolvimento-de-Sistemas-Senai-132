using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTop.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_NOME = "clienete_nome";

        protected const string SESSION_CLIENTE_SENHA = "cliente_senha";

        protected const string SESSION_TIPO_USUARIO = "cliente.TipoUsuario";

        protected string ObterUsuarioSession()
        {
            var senha = HttpContext.Session.GetString(SESSION_CLIENTE_SENHA);

            if(!string.IsNullOrEmpty(senha))
            {
                return senha;
            }
            else
            {
                return "";
            }
        }

        protected string ObterUsuarioNomeSession()
        {
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);

            if(!string.IsNullOrEmpty(nome))
            {
                return nome;
            }
            else
            {
                return "";
            }
        }

        protected string ObterTipoUsuarioNomeSession()
        {
            var TipoUsuario = HttpContext.Session.GetString(SESSION_TIPO_USUARIO);

            if(!string.IsNullOrEmpty(TipoUsuario))
            {
                return TipoUsuario;
            }
            else
            {
                return "" ;
            }
        }
    }
}