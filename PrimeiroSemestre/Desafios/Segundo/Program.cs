using System;

namespace Segundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva alguma temperatura em graus celsius: ");
            int num = int.Parse(Console.ReadLine());

            System.Console.WriteLine($"Temperatura em celsius: {num}C°");
            System.Console.WriteLine($"Temperatura em fahrenheit: {9 * num + 160 % 5}");
        }
    }
}
