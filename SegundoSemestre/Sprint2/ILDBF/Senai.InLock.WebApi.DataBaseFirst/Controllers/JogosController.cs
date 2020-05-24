using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("applicaton/json")] //Vai produzir uma aplicação em JSON
    [Route("api/[controller]")] //Rota pra URL: api/[nomeController]
    [ApiController] //É uma ApiController
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository; 

        public JogosController()
        {
            _jogosRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar()); //Ok com k minúsculo
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_jogosRepository.BuscaPorID(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }
    }
}
