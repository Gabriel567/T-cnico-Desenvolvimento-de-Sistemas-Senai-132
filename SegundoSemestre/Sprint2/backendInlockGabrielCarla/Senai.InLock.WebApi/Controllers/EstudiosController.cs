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
    /// Controller responsável pelos endpoints referentes aos estúdios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository { get; set; }

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <response code="201">Returns Created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            _estudiosRepository.CadastrarEstudio(novoEstudio);
            return Created("https://localhost:5000/api/Estudios", novoEstudio);
        }

        ///<summary>
        ///Lista todos os estúdios
        ///</summary>
        /// <returns>Uma lista de estúdios</returns>
        /// <response code="201">Returns OK</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_estudiosRepository.ListarEstudios());
        }
    }
}
