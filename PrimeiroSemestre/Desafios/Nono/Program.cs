using System.Collections.Generic;
using System;

namespace Nono {
    class Program {
        static void Main (string[] args) {
            var inventory = new Dictionary<string, double>() {
                ["Mercúrio"] = 0.37,
                ["Vênus"] = 0.88,
                ["Marte"] = 0.38,
                ["Júpiter"] = 2.64,
                ["Saturno"] = 1.15,
                ["Urano"] = 1.17
            };
            
            System.Console.WriteLine();
            System.Console.WriteLine($"|{"Gravidade Relativa ",-25}|{"Planeta ",10}|");
            foreach(var item in inventory) {
                System.Console.WriteLine($"|{item.Key,-25}|{item.Value,10}|");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Peso nos planetas: ");
            System.Console.WriteLine("Escreva seu peso em kg: ");
            double peso = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine($"Mercúrio: {(peso/10) * 0.37}kg");
            System.Console.WriteLine($"Vênus: {(peso/10) * 0.88}kg");
            System.Console.WriteLine($"Marte: {(peso/10) * 0.38}kg");
            System.Console.WriteLine($"Júpiter: {(peso/10) * 2.64}kg");
            System.Console.WriteLine($"Saturno: {(peso/10) * 1.15}kg");
            System.Console.WriteLine($"Urano: {(peso/10) * 1.17}kg");
        }
    }
}