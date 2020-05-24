using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos jogos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {
        ///<summary>
        ///Cria um objeto _jogosRepository que irá receber todos os métodos definidos na interface
        ///</summary>
        private IJogosRepository _jogosRepository { get; set; }

        ///<summary>
        ///Instancia o objeto para que haja referencia entre ele e o repositório
        ///</summary>
        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        ///<returns>Retorna os dados que foram enviados para cadastro e retorna um statusCode 201 - Created</returns>
        ///dominio/api/Jogos
        /// <response code="201">Returns Created</response>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.CadastrarJogo(novoJogo);
            return Created("https://localhost:5000/api/Jogos", novoJogo);
        }

        ///<summary>
        ///Lista os jogos
        ///</summary>
        ///<returns>Retorna os dados que foram enviados para cadastro e retorna um statusCode 200 - OK</returns>
        ///dominio/api/Jogos
        /// <response code="200">Returns OK</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.ListarJogos());
        }
    }
}
