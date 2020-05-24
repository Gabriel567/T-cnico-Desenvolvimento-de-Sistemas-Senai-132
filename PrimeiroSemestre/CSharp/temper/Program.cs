using System;

namespace temper
{
    class Program
    {
        static void Main(string[] args)
        {
            //12 posições (espaços)
            double [] vetor = new double [12];
            double maior = 0;
            double menor = 0;

            //11 indices (0,1,2,3,4,5,6,7,8,9,10,11)
            // irá repetir 11 vezes (<12 = 11, 10, 9, 8... 0)
            for (int i = 0; i <12; i++) {
                //i é o conteúdo dentro dos espaços do vetor, por isso pergunta-se "...mês 0, 1, 2, 3, 4, 5... 11
                Console.WriteLine($"Digite a temperatura do mês {i}: ");
                 //i = meio de acesso aos itens dentro do vetor, por isso ele ficou dentro dos colchetes []
                vetor[i] = double.Parse(Console.ReadLine());
            }

            maior = vetor [0];
            menor = vetor [0];

            //mágica do foreach que cria uma variável sem um valor especificado
            //foreach (para cada) analisa cada posição do vetor e passa para a próxima de acordo com a instrução do for (i++ == i = i + 1)
            foreach (double temp in vetor) {
                if (temp > maior) {
                    maior = temp;
                } else if (temp < menor) {
                    menor = temp;
                }
            }

            Console.WriteLine($"A maior temperatura é {maior}");
            Console.WriteLine($"A menor temperatura é {menor}");
        }
    }
}
