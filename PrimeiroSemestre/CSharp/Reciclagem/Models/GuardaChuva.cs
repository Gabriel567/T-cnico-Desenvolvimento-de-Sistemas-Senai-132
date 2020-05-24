using System;
using Reciclagem.Interfaces;

namespace Reciclagem.Models
{
    public class GuardaChuva : ProdutosReciclaveis, IMetal
    {
        public bool FeitoDeMetal() {
            System.Console.WriteLine("É um material metálico.");
            return true;
        }
    }
}