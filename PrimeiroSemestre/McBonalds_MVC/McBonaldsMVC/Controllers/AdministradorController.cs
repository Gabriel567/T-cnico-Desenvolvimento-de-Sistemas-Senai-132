using System;
using McBonaldsMVC.Enums;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class Administrador : AbstractController 
    {
        PedidoRepository pedidoRepository = new PedidoRepository ();

        [HttpGet] //Atributo
        public IActionResult DashBoard () 
        {
            var pedidos = pedidoRepository.ObterTodos();

            DashboardViewModel dashboardViewModel = new DashboardViewModel ();

            foreach (var pedido in pedidos) 
            {
                switch (pedido.Status) 
                {
                    case (uint) StatusPedido.REPROVADO:

                        dashboardViewModel.PedidosReprovados++;

                    break;

                    case (uint) StatusPedido.APROVADO:

                        dashboardViewModel.PedidosAprovados++;

                    break;
                        
                    default:
                    
                        dashboardViewModel.PedidosPendentes++;

                        dashboardViewModel.Pedidos.Add (pedido);

                    break;
                }
            }
            dashboardViewModel.NomeView = "Dashboard";

            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
        }

        public IActionResult Dashboard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterTipoUsuarioNomeSession());

            if(tipoUsuarioSessao.Equals((uint)TiposUsuario.ADMINISTRADOR))
            {
                var pedidos = pedidoRepository.ObterTodos();

            DashboardViewModel dashboardViewModel = new DashboardViewModel ();

            foreach (var pedido in pedidos) 
            {
                switch (pedido.Status) 
                {
                    case (uint) StatusPedido.REPROVADO:

                        dashboardViewModel.PedidosReprovados++;

                    break;

                    case (uint) StatusPedido.APROVADO:

                        dashboardViewModel.PedidosAprovados++;

                    break;
                        
                    default:
                    
                        dashboardViewModel.PedidosPendentes++;

                        dashboardViewModel.Pedidos.Add (pedido);

                    break;
                }
            }
            }
            
            return View("Erro", new RespostaViewModel()
            {
                NomeView = "Dashboard",
                
                Mensagem = "Você não pode acessar essa parte do site"
            });

            
        }
    }
}