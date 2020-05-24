using System;

namespace DecimoOitavoExc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva um número: ");
            int numero = int.Parse(Console.ReadLine());

            for(numero = 0; numero > numero; numero++) {
                System.Console.WriteLine(numero + " ");
            }
        }
    }
}
