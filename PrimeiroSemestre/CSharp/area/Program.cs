using System;

namespace area
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            string quadrado;
            string triangulo;
            string circulo;
            string trapezio;
            string retangulo;
            string losango;

            Console.WriteLine("Qual é a figura a ser calculada a área?");
            Console.ReadLine();

            switch (opcao) {
                case quadrado:
                int num;
                Console.WriteLine("Qual a medida do lado?");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine($"{num}*{num} = A={num}*{num}");
                break;

                case triangulo:
                float h = 0;
                float b = 0;
                Console.WriteLine ("Qual a medida da base?");
                b = float.Parse(Console.ReadLine());
                Console.WriteLine ("Qual a medida da altura?");
                h = float.Parse(Console.ReadLine());
                Console.WriteLine($"({b}*{h})%2 = A=({b}*{h})%2");
                break;

                case circulo:
                float pi = 3.14;
                float r = 0;
                float elv = 2;
                Console.WriteLine("Qual a medida do raio?");
                Math.Pow(r, elv);
                r = float.Parse(Console.ReadLine());
                pi = float.Parse(Console.ReadLine());
                Console.WriteLine($"{pi}*{r^2} = A={pi}*{r^2}");
                break;

                case trapezio:
                float B = 0;
                float s = 0;
            }
        }
    }
}
