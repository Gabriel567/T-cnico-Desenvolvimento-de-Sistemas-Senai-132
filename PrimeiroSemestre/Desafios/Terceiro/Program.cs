using System;

namespace Terceiro
{
    class Program
    {
        static void Main(string[] args)
        {
            string header = "=======";

            System.Console.WriteLine(header);
            System.Console.WriteLine("VIAGEM");
            System.Console.WriteLine(header);
            System.Console.WriteLine();

            System.Console.WriteLine("Por quantas horas você viajou?");
            int tempo = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Qual foi a velocidade de viagem em Km/h?");
            int velocidade = int.Parse(Console.ReadLine());

            double distancia = tempo * velocidade;
            System.Console.WriteLine($"Distância: {distancia}Km");

            double litros = distancia / 12;
            System.Console.WriteLine($"Litros usados: {litros} litros");

            double media = distancia / tempo;
            System.Console.WriteLine($"Velocidade Média: {media}Km/h");
        }
    }
}
