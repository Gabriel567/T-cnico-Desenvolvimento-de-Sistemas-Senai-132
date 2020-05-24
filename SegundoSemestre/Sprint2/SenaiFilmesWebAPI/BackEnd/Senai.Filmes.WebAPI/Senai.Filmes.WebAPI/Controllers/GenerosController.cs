using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebAPI.Domains;
using Senai.Filmes.WebAPI.Interfaces;
using Senai.Filmes.WebAPI.Repositories;

namespace Senai.Filmes.WebAPI.Controllers
{

    //Tipo de resposta que o controlador vai dar
    [Produces("Application/json")]
    //Para acessar um controlador: endereco/api/Generos
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        //Instanciar o repositório
        private IGeneroRepository _GeneroRepository { get; set; }

        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        { 
            return _GeneroRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain generoRecebido)
        {
            _GeneroRepository.Cadastrar(generoRecebido);

            return StatusCode(201);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            _GeneroRepository.Deletar(ID);

            return NoContent();
        }

        [HttpPut("{ID}")]
        public IActionResult PutURL(int ID, GeneroDomain genero)
        {
            _GeneroRepository.AtualizarIDCorpo(ID, genero);
        }
    }
}