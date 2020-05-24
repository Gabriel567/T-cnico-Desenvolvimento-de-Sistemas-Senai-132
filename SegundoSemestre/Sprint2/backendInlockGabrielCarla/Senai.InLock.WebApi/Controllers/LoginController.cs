using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos usuários
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public LoginController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        ///<summary>
        ///Valida o usuario
        ///</summary>
        ///<param name="login">Objeto login que contem o email e a senha do usuario</param>
        ///<returns>Retorna um token com as informações do usuarios</returns>
        
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            UsuariosDomain usuarioBuscado = _usuariosRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if(usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.ID_Usuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.ID_TipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuario-chave-autenticação"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //Um dos métodos de criptografia

            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi", //emissor do token
                audience: "InLock.WebApi", //destinaario do token
                claims: claims, //claims criadas
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds// assinaturas, credenciais do token
                );

            return Ok(new
                {
                token = new JwtSecurityTokenHandler().WriteToken(token)
                });
        }
    }
}
