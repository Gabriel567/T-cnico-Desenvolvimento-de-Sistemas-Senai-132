using System;
namespace exerc1
{
   class Program
   {
       static void Main(string[] args)
       {
           int num1 = 0;
           int num2 = 0;
           string oper;
           
           Console.WriteLine("Digite o 1º Valor");
           num1 = int.Parse(Console.ReadLine());
           Console.WriteLine("Digite o 2º Valor");
           num2 = int.Parse(Console.ReadLine());
           Console.WriteLine("Qual o operador desejado ?");
           oper = Console.ReadLine();
           
           
           Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
           Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
           Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
           Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
           Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
       }
   }
}