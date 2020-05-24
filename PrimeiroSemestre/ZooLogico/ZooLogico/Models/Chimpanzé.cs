using System.Net.Http.Headers;
using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Chimpanzé : Animais, ICasaArvore
    {
        public bool AgrupaSimios() {
            System.Console.WriteLine("Deve ir para a casa na árvore.");
            return true;
        }
    }
}