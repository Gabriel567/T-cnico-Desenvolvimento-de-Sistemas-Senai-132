using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        //Criando um objeto que vai receber todos os métodos definidos na Interface
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        //Instancia o objeto _filmeRepository para que exista uma referência aos métodos no repositório
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastro(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastro(novoFuncionario); //Em _funcionarioRepository estao todos os metodos, entao o chamei e junto com ele o metodo de Cadastro, e o que surgir do metodo Cadastro ira para novoFuncionario
            return StatusCode(201); //Criação
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpDelete("{ID}")]
        public IActionResult Deletar(int ID)
        {
            _funcionarioRepository.Deletar(ID);

            return NoContent();
        }

        [HttpGet("{ID}")]
        public IActionResult BuscaPorID(int ID)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorID(ID);

            if(funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionário encontrado.");
            }
            return Ok(funcionarioBuscado);
        }

        [Route("api/[controller]/buscar/{nome}")]
        [HttpGet("{Nome}")]
        public IActionResult BuscaPorNome(string Nome)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorNome(Nome);

            if(funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionário encontrado.");
            }
            return Ok(funcionarioBuscado);
        }
         
        [HttpPut("{ID}")]
        public IActionResult AtualizarIDURL(int ID, FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto filmeBuscado que irá receber o gênero buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorID(ID);

            // Verifica se nenhum gênero foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _funcionarioRepository.AtualizarIDURL(ID, funcionarioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult AtualizarIDCorpo(FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorID(funcionarioAtualizado.ID_Funcionario);

            if (funcionarioBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _funcionarioRepository.AtualizarIDCorpo(funcionarioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }
    }
}

