using System;
using Microsoft.AspNetCore.Mvc;
using RoleTop.Repositories;
using RoleTop.ViewModels;
using Microsoft.AspNetCore.Http;
using RoleTop.Enums;

namespace RoleTop.Controllers
{
    public class ClienteController : AbstractController
    {
        
        private ClienteRepository clienteRepository = new ClienteRepository();

        private EventoRepository eventoRepository = new EventoRepository();

        [HttpGet]

        public IActionResult Login()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Login",

                UsuarioNome = ObterUsuarioNomeSession(),

                UsuarioSenha = ObterUsuarioSession()
            });
        }

        [HttpPost]

        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";

            try
            {
                System.Console.WriteLine("===================");

                System.Console.WriteLine(form["nome"]);

                System.Console.WriteLine(form["senha"]);

                System.Console.WriteLine("===================");

                var usuario = form["nome"];

                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                if(cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        switch(cliente.TipoUsuario)
                        {
                            case(uint)TiposUsuario.CLIENTE:

                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_SENHA, cliente.Nome);

                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());

                            return RedirectToAction("Historico", "Cliente");

                            default:

                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_SENHA, cliente.Nome);

                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());

                            return RedirectToAction("Dashboard", "Adm");
                        }
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, usuario);

                            HttpContext.Session.SetString(SESSION_CLIENTE_SENHA, cliente.Nome);

                            return RedirectToAction("Historico", "Cliente");
                    }
                    else
                    {
                        return View("Erro", new RespostaViewModel($"Senha não encontrada."));
                    }
                }
                else
                {
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado."));
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);

                return View("Erro");
            }
        }

        public IActionResult Historico()
        {
            var senhaCliente = ObterUsuarioSession();

            var eventos = eventoRepository.ObterTodosPorCliente(senhaCliente);

            return View(new HistoricoViewModel()
            {
                    Eventos = eventos,

                    NomeView = "Historico",

                    UsuarioNome = ObterUsuarioNomeSession(),

                    UsuarioSenha = ObterUsuarioSession()
            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);

            HttpContext.Session.Remove(SESSION_CLIENTE_SENHA);

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}