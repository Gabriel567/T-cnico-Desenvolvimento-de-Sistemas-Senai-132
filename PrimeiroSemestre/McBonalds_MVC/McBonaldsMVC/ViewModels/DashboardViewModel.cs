using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Pedido> Pedidos = new List<Pedido>();
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}

        public DashboardViewModel()
        {
            this.Pedidos = new List<Pedido>();
        }
    }
}