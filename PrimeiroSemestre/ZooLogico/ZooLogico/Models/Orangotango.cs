using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Orangotango : Animais, ICasaArvore
    {
        public bool AgrupaSimios() {
            System.Console.WriteLine("Deve ir para a casa da árvore.");
            return true;
        }
    }
}