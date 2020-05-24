using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTop.Models;
using RoleTop.Repositories;
using RoleTop.ViewModels;

namespace RoleTop.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Cadastro",

                UsuarioSenha = ObterUsuarioSession(),

                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }

        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";

            try
            {
                Cliente cliente = new Cliente
                (
                    form["nome"],
                    DateTime.Parse(form["nascimento"]),
                    form["email"],
                    form["senha"],
                    form["repitaSenha"]
                );

                clienteRepository.Inserir(cliente);

                return RedirectToAction("Index", "Login");
            }
            catch(Exception e)
            {
                return View("Erro");
            }
        }
    }
}