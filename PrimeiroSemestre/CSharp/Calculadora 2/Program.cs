using System;

namespace calcex {
    class Program {
        static void Main (string[] args) {

            double resultado = 0;

            Console.WriteLine ("==============");
            Console.WriteLine ("1 - SOMA");
            Console.WriteLine ("2 - SUBTRAÇÃO");
            Console.WriteLine ("3 - MULTIPLICAÇÃO");
            Console.WriteLine ("4 - DIVISÃO");
            Console.WriteLine ("5 - PORCENTAGEM");

            Console.WriteLine ("Informe un número:");
            int num1 = int.Parse (Console.ReadLine ());

            Console.WriteLine ("Informe outro número: ");
            int num2 = int.Parse (Console.ReadLine ());

            Console.WriteLine ("Informe a operação:");
            int oper = int.Parse (Console.ReadLine ());

            if (oper == 1) {
                Console.WriteLine ("Soma");
                resultado = num1 + num2;
            } else if (oper == 2) {
                Console.WriteLine ("Subtração");
                resultado = num1 - num2;
            } else if (oper == 3) {
                Console.WriteLine ("Multiplicação");
                resultado = num1 * num2;
            } else if (oper == 4) {
                Console.WriteLine ("Divisão");
                resultado = num1 / num2;
            } else if (oper == 5) {
                Console.WriteLine ("Porcentagem");
                resultado = num2 % num1;
            }

            Console.WriteLine ("Resultado = {0}", resultado);
        }
    }
}