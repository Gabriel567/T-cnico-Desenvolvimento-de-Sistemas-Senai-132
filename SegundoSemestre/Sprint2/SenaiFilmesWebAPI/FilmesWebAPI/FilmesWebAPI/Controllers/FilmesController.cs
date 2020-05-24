using FilmesWebAPI.Domains;
using FilmesWebAPI.Interfaces;
using FilmesWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebAPI.Controllers
{

    //Aqui ficarão os Https e os métodos, para que no momento que o navegador faça uma requisição, o controller
    //com base no Http e na requisição saiba direcionar para o método adequado

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class FilmesController : ControllerBase
    {
        //Criando um objeto que vai receber todos os métodos definidos na Interface
        private IFilmeRepository _filmeRepository { get; set; }

        //Instancia o objeto _filmeRepository para que exista uma referência aos métodos no repositório
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpPost]
        //Cadastra um novo filme, recebendo seu nome e um ID_Genero correspondente
        //novoFilme: objeto recebido na requisição (método)
        //Retorna um status code 201 (Criação)
        //dominio/api/Filmes
        public IActionResult Post(FilmeDomain novoFilme)
        {
            //Chama o método Cadastrar
            //Eu poderia retornar o método Cadastrar, mas iria mostrar para o usuário o nome do filme e o ID do gênero
            _filmeRepository.Cadastrar(novoFilme);
            //Retorna o status code 201
            //Aqui retorna uma mensagem de sucesso por conta do filme cadastrado
            return StatusCode(201);
        }

        [HttpGet]
        //Lista todos os filmes
        //Retorna uma lista de filmes
        //dominio/api/Filmes
        public IEnumerable<FilmeDomain> Get()
        {
            //Chama o método listar
            return _filmeRepository.Listar();
        }

        [HttpDelete("{ID}")]
        //Deleta um filme
        //O Http recebeu o ID, pois para apagarmos um filme, será necessário informar um ID, do contrário, todos os filmes serão apagdos
        public IActionResult Deletar(int ID)
        {
            //Faz a chamada do método Deletar
            _filmeRepository.Deletar(ID);

            //Retorna uma mensagem de filme deletado
            return Ok("Filme deletado com sucesso.");
        }

        [HttpGet("{ID}")]
        //Busca um filme colocando seu ID diretamente na URL
        public IActionResult BuscaPorID(int ID)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscaPorID(ID);

            //Verifica se o gênero foi encontrado
            if(filmeBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado");
            }
            return Ok(filmeBuscado);
        }

        [HttpPut("{ID}")]
        public IActionResult AtualizarIDURL(int ID, FilmeDomain filmeAtualizado)
        {
            // Cria um objeto filmeBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscaPorID(ID);

            // Verifica se nenhum gênero foi encontrado
            if (filmeBuscado == null)
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
                _filmeRepository.AtualizarIDURL(ID, filmeAtualizado);

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
        public IActionResult PutIDCorpo(FilmeDomain filmeAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscaPorID(filmeAtualizado.ID_Filme);

            // Verifica se algum gênero foi encontrado
            if (filmeBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _filmeRepository.AtualizarIDCorpo(filmeAtualizado);

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
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                );
        }
    }
}
