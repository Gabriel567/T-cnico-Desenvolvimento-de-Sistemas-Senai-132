using System;
using System.Collections.Generic;
using System.Text;
using ByteBank2.Models;

namespace ByteBank2
{
    class Program
    {
        static void Main(string[] args)
        {
            string cliente1 = "Gabriel";
            string cliente2 = "Baam";

            #region Teste Conta Corrente
            ContaCorrente contaCorrente = new ContaCorrente(1, 1, cliente1);
            ContaCorrente contaCorrente = new ContaCorrente(1, 2, cliente2);
            contaCorrente.Deposito(10);
            #endregion
        }
    }
}
