using System;
using ZooLogico.Interfaces;

namespace ZooLogico.Models
{
    public class Leão : Animais, IGaiola, IAquario, ICasaArvore, ICaverna, IPasto, IPiscina, IPiscinaGelada
    {
        public bool AgrupaAereos() {
            System.Console.WriteLine("Deve ir para a gaiola.");
            return true;
        }

        public bool AgrupaMarinhos() {
            System.Console.WriteLine("Deve ir para o aquário.");
            return true;
        }

        public bool AgrupaSimios() {
            System.Console.WriteLine("Deve ir para a casa na árvore.");
            return true;
        }

        public bool AgrupaCavernosos() {
            System.Console.WriteLine("Deve ir para a caverna.");
            return true;
        }

        public bool AgrupaDoce() {
            System.Console.WriteLine("Deve ir para a psicina.");
            return true;
        }

        public bool AgrupaGelidos() {
            System.Console.WriteLine("Deve ir para a piscina gelada.");
            return true;
        }

        public bool AgrupaHerbivoros() {
            System.Console.WriteLine("Deve ir para o pasto.");
            return true;
        }
    }
}