using System.Collections.Generic;
using RoleTop.Models;

namespace RoleTop.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Evento> Eventos = new List<Evento>();

        public uint EventosAprovados {get;set;}

        public uint EventosReprovados {get;set;}

        public uint EventosPendentes {get;set;}

        public DashboardViewModel()
        {
            this.Eventos = new List<Evento>();
        }
    }
}