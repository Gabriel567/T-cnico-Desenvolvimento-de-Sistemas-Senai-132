using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Tartaruga : Animais, IPiscina
    {
        public bool AgrupaDoce() {
            System.Console.WriteLine("Deve ir para a psicina.");
            return true;
        }
    }
}