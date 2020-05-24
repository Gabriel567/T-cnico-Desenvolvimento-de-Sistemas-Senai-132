using System;
using System.Collections.Generic;
using System.Text;

namespace Oitavo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Programa que crea una pirámide de asteriscos");
            inicio:
            Console.WriteLine("Insira um número para ser a altura da piramide: ");
            try
            {
                int nivel = int.Parse(Console.ReadLine());
                if (nivel != 0)
                {

                    int a;
                    int espacios;
                    for (int i = nivel; i >= 1; i--)
                    {
                        StringBuilder final = new StringBuilder();

                        espacios = nivel - i;
                        a = i + (i - 1);
                        for (int i1 = 0; i1 < espacios; i1++)
                            final.Append(" ");

                        for (int i2 = 0; i2 < a; i2++)
                            final.Append("*");

                        Console.WriteLine(final.ToString());

                    }
                }
                else
                {
                    System.Console.Clear();
                    goto inicio;
                }

            }
            catch (Exception )
            {
                System.Console.Clear();
                Console.WriteLine("O programa só aceita números inteiros");
                goto inicio;
            }

            Console.WriteLine("" + "\n" + "Aperte una tecla para sair");
            Console.ReadLine();
        }
    }
}
