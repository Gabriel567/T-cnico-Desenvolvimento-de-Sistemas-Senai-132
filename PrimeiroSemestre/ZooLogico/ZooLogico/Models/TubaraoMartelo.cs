using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class TubaraoMartelo : Animais, IAquario
    {
        public bool AgrupaMarinhos() {
            System.Console.WriteLine("Deve ir para o aquário.");
            return true;
        }
    }
}