using System;
using Reciclagem.Interfaces;

namespace Reciclagem.Models
{
    public class Papelao : ProdutosReciclaveis, IPapel
    {
        public bool FeitoDePapel() {
            System.Console.WriteLine("É um material feito de papel.");
            return true;
        }
    }
}