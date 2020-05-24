using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Leão : Animais, ICaverna
    {
        public bool AgrupaCavernosos() {
            System.Console.WriteLine("Deve ir para a caverna.");
            return true;
        }
    }
}