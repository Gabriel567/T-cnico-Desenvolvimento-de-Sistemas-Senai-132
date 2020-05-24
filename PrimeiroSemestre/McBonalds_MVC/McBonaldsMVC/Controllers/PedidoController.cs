using System;
using System.Reflection.PortableExecutable;
using McBonaldsMVC.Enums;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class
    PedidoController : AbstractController 
    {
        PedidoRepository pedidoRepository = new PedidoRepository ();

        HamburguerRepository hamburguerRepository = new HamburguerRepository ();

        ShakeRepository shakeRepository = new ShakeRepository ();

        ClienteRepository clienteRepository = new ClienteRepository ();

        public IActionResult Index () { //! ================
            var hamburgueres = hamburguerRepository.ObterTodos ();

            var shakes = shakeRepository.ObterTodos ();

            //! ================

            PedidoViewModel pedido = new PedidoViewModel ();

            pedido.Hamburgueres = hamburgueres;

            pedido.Shakes = shakes;

            var usuarioLogado = ObterUsuarioSession ();

            var nomeUsuarioLogado = ObterUsuarioNomeSession ();

            //! Aparição do nome do usuário

            if (!string.IsNullOrEmpty (nomeUsuarioLogado)) {

                pedido.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor (usuarioLogado);

            if (clienteLogado != null) 
            {
                pedido.Cliente = clienteLogado;
            }

            pedido.NomeView = "Pedido";

            pedido.UsuarioEmail = ObterUsuarioSession ();

            return View (pedido);
        }

        public IActionResult Registrar (IFormCollection form) 
        {
            Pedido pedido = new Pedido ();

            Shake shake = new Shake ();

            //TODO: Formas de escrever e chamar a variavel

            //!1ª Forma 

            var nomeShake = form["shake"];

            shake.Nome = nomeShake;

            shake.Preco = shakeRepository.ObterPrecoDo (form["shake"]);

            //!===============

            pedido.Shake = shake;

            //!2ª Forma

            Hamburguer hamburguer = new Hamburguer (form["hamburguer"], hamburguerRepository.ObterPrecoDe (form["hamburguer"]));

            //!===============

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente () 
            {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = pedido.Hamburguer.Preco + pedido.Shake.Preco;

            if (pedidoRepository.Inserir (pedido)) 
            {
                return View ("Sucesso", new RespostaViewModel () 
                {
                    Mensagem = "Aguarde a aprovação dos nossos administradores."
                });
            } else 
            {
                return View ("Erro", new RespostaViewModel () {
                    Mensagem = "Houve um erro ao processar seu pedido. Tente novamente.",

                        NomeView = "Erro",

                        UsuarioEmail = ObterUsuarioSession (),

                        UsuarioNome = ObterUsuarioNomeSession ()
                });
            }

        }

        public IActionResult Aprovar (ulong id) 
        {
            Pedido pedido = pedidoRepository.ObterPor (id);

            pedido.Status = (uint)StatusPedido.APROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View ("Erro", new RespostaViewModel() 
                {
                    Mensagem = "Houve um erro ao aprovar seu pedido. Tente novamente.",

                        NomeView = "Dashboard",

                        UsuarioEmail = ObterUsuarioSession (),

                        UsuarioNome = ObterUsuarioNomeSession ()
                });
            }
        }

        public IActionResult Reprovar (ulong id) 
        {
            Pedido pedido = pedidoRepository.ObterPor (id);

            pedido.Status = (uint)StatusPedido.REPROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View ("Erro", new RespostaViewModel() 
                {
                    Mensagem = "Houve um erro ao reprovar seu pedido. Tente novamente.",

                        NomeView = "Dashboard",

                        UsuarioEmail = ObterUsuarioSession (),

                        UsuarioNome = ObterUsuarioNomeSession ()
                });
            }
        }
    }
}