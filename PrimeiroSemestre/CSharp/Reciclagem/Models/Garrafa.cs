using System;
using Reciclagem.Interfaces;

namespace Reciclagem.Models
{
    public class Garrafa : ProdutosReciclaveis, IVidro
    {
        public bool FeitoDeVidro() {
            System.Console.WriteLine("É um material feito de vidro.");
            return true;
        }
    }
}