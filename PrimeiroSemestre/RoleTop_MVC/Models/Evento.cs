using System;
using RoleTop.Enums;

namespace RoleTop.Models
{
    public class Evento
    {
        public ulong ID {get;set;}

        public Cliente Cliente {get;set;}

        public double PrecoTotal {get;set;}

        public DateTime DataPedido {get;set;}

        public MesaCadeira MesaCadeira {get;set;}

        public Convidados Convidados {get;set;}

        public Comemoracao Comemoracao {get;set;}

        public Iluminacao Iluminacao {get;set;}

        public Som Som {get;set;}

        public uint Status {get;set;}

        public Evento()
        {
            this.ID = 0;

            this.Cliente = new Cliente();

            this.MesaCadeira = new MesaCadeira();

            this.Convidados = new Convidados();

            this.Comemoracao = new Comemoracao();

            this.Som = new Som();

            this.Iluminacao = new Iluminacao();

            this.Status = (uint)StatusEvento.PENDENTE;
        }

        public static implicit operator Evento(string v)
        {
            throw new NotImplementedException();
        }

    }
}