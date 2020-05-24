using System;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.Enums;

namespace McBonaldsMVC.Controllers
{
    public class ClienteController : AbstractController
    {   
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PedidoRepository pedidoRepository = new PedidoRepository();
        
        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Login",

                UsuarioEmail = ObterUsuarioSession(),

                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["action"] = "Login";

            try
            {
                System.Console.WriteLine("======================");

                System.Console.WriteLine(form["email"]);

                System.Console.WriteLine(form["senha"]);

                System.Console.WriteLine("======================");

                var usuario = form["email"];

                var senha = form["senha"];
                
                var cliente = clienteRepository.ObterPor(usuario);

                if(cliente != null)
                {
                    //Se o email digitado for igual ao do usuario ee a senha for igual a senha do usario

                    if(cliente.Senha.Equals(senha))
                    {
                        switch(cliente.TipoUsuario)
                        {
                            case (uint)TiposUsuario.CLIENTE:

                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);

                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());

                            return RedirectToAction("Historico", "Cliente");

                            default:

                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);

                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());

                            return RedirectToAction("Dashboard", "Administrador");
                        }

                            //Deixa visivel para todas os controllers que herdam de controller

                            //!Session: guarda valores em strings que ficam disponivel para todos 

                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);

                            //! joga o B.O par outro método

                            //TODO Passa a ação para outro método

                            return RedirectToAction("Historico", "Cliente");
                    }
                    else
                    {
                        return View("Erro", new RespostaViewModel($"Senha não encotrada"));
                    }
                }
                else
                {
                                        // outro método de criação classe 
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado"));
                }

            } catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);

                return View("Erro");
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();

            var pedidos = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel()
            {
                    Pedidos = pedidos,

                    NomeView = "Historico",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioEmail = ObterUsuarioSession()
            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);

            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}