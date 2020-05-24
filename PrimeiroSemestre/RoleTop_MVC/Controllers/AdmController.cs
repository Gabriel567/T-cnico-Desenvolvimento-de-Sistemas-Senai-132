using Microsoft.AspNetCore.Mvc;
using RoleTop.Enums;
using RoleTop.Repositories;
using RoleTop.ViewModels;

namespace RoleTop.Controllers
{
    public class AdmController : AbstractController
    {
        EventoRepository eventoRepository = new EventoRepository();

        [HttpGet]
        
        public IActionResult DashBoard()
        {
            var eventos = eventoRepository.ObterTodos();

            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach(var evento in eventos)
            {
                switch(evento.Status)
                {
                    case (uint)StatusEvento.REPROVADO:

                    dashboardViewModel.EventosReprovados++;

                    break;

                    case (uint)StatusEvento.APROVADO:

                    dashboardViewModel.EventosAprovados++;

                    break;

                    default:

                    dashboardViewModel.EventosPendentes++;

                    dashboardViewModel.Eventos.Add(evento);

                    break;
                }
            }

            dashboardViewModel.NomeView = "Dashboard";

            dashboardViewModel.UsuarioSenha = ObterUsuarioSession();

            return View(dashboardViewModel);
        }

        public IActionResult Dashboard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterTipoUsuarioNomeSession());

            if(tipoUsuarioSessao.Equals((uint)TiposUsuario.ADMINISTRADOR))
            {
                var eventos = eventoRepository.ObterTodos();

                DashboardViewModel dashboardViewModel = new DashboardViewModel();

                foreach(var evento in eventos)
                {
                    switch(evento.Status)
                    {
                        case (uint)StatusEvento.REPROVADO:
                        
                        dashboardViewModel.EventosReprovados++;

                        break;

                        case (uint)StatusEvento.APROVADO:

                        dashboardViewModel.EventosAprovados++;

                        break;

                        default:

                        dashboardViewModel.EventosPendentes++;

                        dashboardViewModel.Eventos.Add(evento);

                        break;
                    }
                }
            }
            return View("Erro", new RespostaViewModel()
            {
                NomeView = "Dashboard",

                Mensagem = "Você não pode acessar essa parte do site."
            });
        }
    }
}