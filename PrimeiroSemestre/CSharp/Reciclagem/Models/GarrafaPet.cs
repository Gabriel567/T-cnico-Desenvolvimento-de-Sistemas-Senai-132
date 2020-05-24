using System;
using Reciclagem.Interfaces;

namespace Reciclagem.Models
{
    public class GarrafaPet : ProdutosReciclaveis, IPlastico
    {
        public bool FeitoDePlastico() {
            System.Console.WriteLine("É um material feito de plástico.");
            return true;
        }
    }
}