using System;

namespace Quinto
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "Dragão";
            string B = "rinoceronte";
        
            Console.WriteLine($"O {A} pertence ao Japão.");
            System.Console.WriteLine($"O {B} vive na África.");
            
            if(A=B) {
                A = int.Parse(Console.ReadLine());
                System.Console.WriteLine($"{A}");
            }else if (B=A){
                System.Console.WriteLine("{B}");
            }
        }
    }
}
