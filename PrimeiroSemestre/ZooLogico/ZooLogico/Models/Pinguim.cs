using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Pinguim : Animais, IPiscinaGelada
    {
        public bool AgrupaGelidos() {
            System.Console.WriteLine("Deve ir para a piscina gelada.");
            return true;
        }
    }
}