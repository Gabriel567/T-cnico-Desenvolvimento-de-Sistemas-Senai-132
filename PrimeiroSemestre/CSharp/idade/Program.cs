using System;

namespace idade
{
    class Program
    {
        static void Main(string[] args)
        {

            int anoatual = 2019;
            int anonasc = 0;
            int idade;

            Console.WriteLine ("Em que ano você nasceu?");
            anonasc = int.Parse(Console.ReadLine ());
            idade = anoatual - anonasc;

            Console.WriteLine ("Sua idade é de " + idade  +  "anos");

            if (idade <=2) {
                Console.WriteLine("Voce é Recem nascido");
            }else if ((idade >=3) && (idade <=11)) {
                Console.Write("Voce é uma criança");
            }else if ((idade >=12) && (idade <=19)) {
                Console.WriteLine("Voce é um adolescente");
            }else if ((idade >20) && (idade <=65)) {
                Console.Write("Voce é um adulto");
            }else if (idade >65) {
                Console.WriteLine("Voce é um idoso");
            }

        }
    }
}
