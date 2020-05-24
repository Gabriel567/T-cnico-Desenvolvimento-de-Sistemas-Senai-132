using System;

namespace parouimpar
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            do{

              Console.WriteLine("Escolha um número");
              num = int.Parse(Console.ReadLine());
            
              if (num%2==0) {
                Console.WriteLine("O número é par");
              } else {
                Console.WriteLine("O número é impar");
              }

            } while(num != 0);
            // ! compara dois valores
        }
    }
}
