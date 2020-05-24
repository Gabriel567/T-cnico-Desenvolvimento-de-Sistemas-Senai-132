using System;

namespace PrimeiroExc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estabeleça um valor para a base: ");
            double num = int.Parse(Console.ReadLine());

            Console.WriteLine("Estabeleça um valor para a altura: ");
            double numero = int.Parse(Console.ReadLine());

            double d = num*num + numero*numero;
            
            System.Console.WriteLine($"Perimetro: {num*2 + numero*2}");
            System.Console.WriteLine($"Área: {num*numero}");
            System.Console.WriteLine($"Diagonal: {Math.Sqrt(d)}");
        }
    }
}
