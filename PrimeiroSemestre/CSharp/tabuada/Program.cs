using System;

namespace Tabuada {

    class Program {

        static void Main(string[] args) {

            for(int e =1; e<=10; e++) {

                for(int d =1; d<=10; d++) {

                    Console.WriteLine(e + "x" + d + "=" + e * d);
                    // usar interpolção ($) para deixar a tabuada alinhada:
                    // ($"{e,-2} * {d,-2} = {e*d}")
                }
                Console.WriteLine();
            }
        }
    }
}