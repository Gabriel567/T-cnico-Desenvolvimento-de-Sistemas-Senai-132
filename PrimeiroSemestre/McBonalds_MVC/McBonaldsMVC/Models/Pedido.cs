using System;
using McBonaldsMVC.Enums;

namespace McBonaldsMVC.Models
{
    public class Pedido
    {
        public ulong ID {get;set;} //ulong guarda números inteiros positivos grandes, tipo 1.000.000.000
        public Cliente Cliente {get;set;}
        public Hamburguer Hamburguer {get;set;}
        public Shake Shake {get;set;}
        public DateTime DataDoPedido {get;set;}
        public double PrecoTotal {get;set;}
        public uint Status {get;set;}


        public Pedido(){
            this.Cliente = new Cliente();
            this.Hamburguer = new Hamburguer();
            this.Shake = new Shake();
            this.ID = 0;
            this.Status = (uint)StatusPedido.PENDENTE;
        }

        public static implicit operator Pedido(string v)
        {
            throw new NotImplementedException();
        }
    }

    
}