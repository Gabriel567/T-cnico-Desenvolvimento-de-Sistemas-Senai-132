using System;

namespace DecimoPrimeiro {
    class Program {
        static void Main (string[] args) {
            string[] Nomes = new string[3];
            for (int i = 0; i < Nomes.Length; i++) {
                System.Console.WriteLine($"Digite o {i+1}°nome: ");
                Nomes[i] = Console.ReadLine();
            }

            StringComparer order = StringComparer.OrdinalIgnoreCase;
            Array.Sort(Nomes, order);
            System.Console.WriteLine("Em ordem alfabética: ");
            for (int i = 0; i < Nomes.Length; i++);
            System.Console.WriteLine(Nomes[i]);
        }

    }
}