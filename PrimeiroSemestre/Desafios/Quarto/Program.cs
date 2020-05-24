using System;

namespace Quarto
{
    class Program
    {
        static void Main(string[] args)
        {
            double numero;

            Console.WriteLine("Escreva um número: ");
            numero = int.Parse(Console.ReadLine());

            if(numero % 2 == 0) {
                System.Console.WriteLine($"O número {numero} é par.");
            }else {
                System.Console.WriteLine($"O número {numero} é impar.");
            }
        }
    }
}
