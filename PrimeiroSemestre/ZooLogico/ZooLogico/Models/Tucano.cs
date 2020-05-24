using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Tucano : Animais, IGaiola
    {
        public bool AgrupaAereos() {
            System.Console.WriteLine("Deve ir para a gaiola.");
            return true;
        }
    }
}