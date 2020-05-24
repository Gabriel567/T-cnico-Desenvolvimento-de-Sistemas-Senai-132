using System;

namespace vetor1 {
    class Program {
        static void Main (string[] args) {
            int[] vetor = new int[6];
            int pares = 0;
            int impares = 0;

            for (int cont = 0; cont < 6; cont++) {
                Console.Write ("Olá usuário. Digite um número por favor");
                vetor[cont] = int.Parse (Console.ReadLine ());
            }

            foreach (int num in vetor) {
                if (num % 2 == 0) {
                    pares++;
                } else {
                    impares++;
                }
            }

            /*int num;
            for (int cont = 0; cont <=5; cont++) {
                num = vetor [cont];
                if (num%2 == 0) {
                    pares ++;
                } else {
                    impares++;
                }
            }*/

            Console.WriteLine ($"Você tem {pares} números pares e {impares} números impares");

        }
    }
}