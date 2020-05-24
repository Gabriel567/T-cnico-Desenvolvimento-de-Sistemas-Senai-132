using System;

namespace DecimoExc
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Campo de pergunta

            Console.WriteLine("Insira um número: ");
            double numero = int.Parse(Console.ReadLine());

            #endregion

            #region Validação
            
            if(numero%3 == 0) {
                System.Console.WriteLine("Esse número é multíplo de 3.");
            }else {
                System.Console.WriteLine("Esse número não é multíplo de 3.");
            }

            #endregion
        }
    }
}
