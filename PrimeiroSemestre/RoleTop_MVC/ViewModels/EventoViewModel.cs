using System.Runtime.CompilerServices;
using System.Collections.Generic;
using RoleTop.Models;

namespace RoleTop.ViewModels
{ 
    public class EventoViewModel : BaseViewModel
    {
        public List<Comemoracao> Comemoracao {get;set;}

        public List<Convidados> Convidados {get;set;}

        public List<MesaCadeira> MesaCadeiras {get;set;}

        public List<Som> Som {get;set;}

        public List<Iluminacao> Iluminacao {get;set;}

        public string NomeUsuario {get;set;}

        public Cliente Cliente {get;set;}

        public EventoViewModel()
        {
            this.Comemoracao = new List<Comemoracao>();
            this.Convidados = new List<Convidados>();
            this.MesaCadeiras = new List<MesaCadeira>();
            this. Som = new List<Som>();
            this.Iluminacao = new List<Iluminacao>();
            this.NomeUsuario = "Elemento";
            this.Cliente = new Cliente();
        }
    }
}