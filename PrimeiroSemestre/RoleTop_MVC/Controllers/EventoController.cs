using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTop.Enums;
using RoleTop.Models;
using RoleTop.Repositories;
using RoleTop.ViewModels;

namespace RoleTop.Controllers
{
    public class EventoController : AbstractController
    {
        EventoRepository eventoRepository = new EventoRepository();

        ClienteRepository clienteRepository = new ClienteRepository();

        ComemoracaoRepository comemoracaoRepository = new ComemoracaoRepository();

        ConvidadosRepository convidadosRepository = new ConvidadosRepository();

        MesaCadeiraRepository mesaCadeiraRepository = new MesaCadeiraRepository();

        SomRepository somRepository = new SomRepository();

        IluminacaoRepository iluminacaoRepository = new IluminacaoRepository();

        public IActionResult Index()
        {
            var comemoracao = comemoracaoRepository.ObterTodos();

            var convidados = convidadosRepository.ObterTodos();

            var mesaCadeira = mesaCadeiraRepository.ObterTodos();

            var som = somRepository.ObterTodos();

            var iluminacao = iluminacaoRepository.ObterTodos();

            EventoViewModel evento = new EventoViewModel();

            evento.Comemoracao = comemoracao;

            evento.Convidados = convidados;

            evento.MesaCadeiras = mesaCadeira;

            evento.Som = som;

            evento.Iluminacao = iluminacao;

            var nomeUsuarioLogado = ObterUsuarioNomeSession();

            var senhaUsuarioLogado = ObterUsuarioSession();

            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                evento.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogaddo = clienteRepository.ObterPor(nomeUsuarioLogado);

            if(clienteLogaddo != null)
            {
                evento.Cliente = clienteLogaddo;
            }

            evento.NomeView = "Evento";

            evento.UsuarioSenha = ObterUsuarioSession();

            return View(evento);
        }

        public IActionResult Registrar(IFormCollection form)
        {
            Evento evento = new Evento()
            {
                
            };

            Comemoracao comemoracao = new Comemoracao()
            {

            };

            Convidados convidados = new Convidados()
            {

            };

            MesaCadeira mesaCadeira = new MesaCadeira()
            {

            };

            Som som = new Som()
            {

            };

            Iluminacao iluminacao = new Iluminacao()
            {
                
            };

            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],

                Email = form["email"]
            };

            evento.Cliente = cliente;

            evento.Comemoracao = comemoracao;

            evento.Convidados = convidados;

            evento.MesaCadeira = mesaCadeira;

            evento.Som = som;

            evento.Iluminacao = iluminacao;

            evento.DataPedido = DateTime.Now;

            evento.PrecoTotal = evento.Comemoracao.Preco + evento.Convidados.Preco + evento.MesaCadeira.Preco + evento.Som.Preco + evento.Iluminacao.Preco;

            if(eventoRepository.Inserir(evento))
            {
                return View("Sucesso", new RespostaViewModel()
                {
                    Mensagem = "Aguarde a aprovação de nosso administrador",

                    NomeView = "Sucesso",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioSenha = ObterUsuarioSession()
                });
            }
            else
            {
                return View("Erro", new RespostaViewModel()
                {
                    Mensagem = "Houve um erro ao processar seu evento. Tente novamente.",

                    NomeView = "Erro",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioSenha = ObterUsuarioSession()
                });
            }
        }

        public IActionResult Aprovar(ulong ID)
        {
            Evento evento = eventoRepository.ObterPor(ID);

            evento.Status = (uint)StatusEvento.APROVADO;

            if(eventoRepository.Atualizar(evento))
            {
                return RedirectToAction("Dashboard", "Adm");
            }
            else
            {
                return View("Erro", new RespostaViewModel()
                {
                    Mensagem = "Houve um erro ao processar seu pedido. Tente novamente.",

                    NomeView = "Dashboard",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioSenha = ObterUsuarioSession()
                });
            }
        }

        public IActionResult Reprovar (ulong ID)
        {
            Evento evento = eventoRepository.ObterPor(ID);

            evento.Status = (uint)StatusEvento.REPROVADO;

            if(eventoRepository.Atualizar(evento))
            {
                return RedirectToAction("Dashboard", "Adm");
            }
            else
            {
                return View("Erro", new RespostaViewModel()
                {
                    Mensagem = "Houve um erro ao processar seu evento. Tente novamente.",

                    NomeView = "Dashboard",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioSenha = ObterUsuarioSession()
                });
            }
        }
    }
}