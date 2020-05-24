using System;

namespace MateODragao.Models
{
    public class Guerreiro
    {
        public string Nome {get;set;}
        public string Sobrenome {get;set;}
        public string CidadeNatal {get;set;}
        public DateTime DataNascimento {get;set;}
        public string FerramentaDeProtecao {get;set;}
        public string FerramentaDeAtaque {get;set;}
        public int Forca {get;set;}
        public int Destreza {get;set;}
        public int Inteligencia {get;set;}
        public int HP {get;set;}
    }
}