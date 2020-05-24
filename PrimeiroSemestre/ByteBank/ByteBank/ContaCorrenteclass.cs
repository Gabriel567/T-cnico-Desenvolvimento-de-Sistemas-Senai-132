using System;

namespace ByteBank {
    public class ContaCorrenteclass {

        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        private double Saldo;

        public double saldo 
        {
            get {return Saldo;}
        }

        public ContaCorrenteclass (int Agencia, int Numero, Cliente Titular) {

            this.Agencia = Agencia;
            this.Numero = Numero;
            this.Titular = Titular;
            this.Saldo = 0.0;
        }

        public double Deposito (double valor) {
            bool depositoOk = false;
            double deposito;

            do {
                System.Console.WriteLine ("Depósito");
                deposito = double.Parse (Console.ReadLine ());

                if (deposito > 0) {
                    depositoOk = true;
                } else {
                    System.Console.WriteLine ("O seu depósito não pode ser menor que R$ 0,00");
                }
            } while (!depositoOk);
            //Saldo atualizado pelo this.
            this.Saldo += valor;
            return this.Saldo;
        }

        //Para retornar um valor atualizado basta colocar <tipo de variavel> *valor*
        public bool Saque (double valor) {
            bool saqueOk = false;
            double saque;
            
            do {
                System.Console.WriteLine ("Saque");
                saque = double.Parse (Console.ReadLine ());

                if (saque > 0) {
                    saqueOk = true;
                } else {
                    System.Console.WriteLine ("O seu saque não pode ser menor que R$ 0,00");
                }
            } while (!saqueOk);

            if (valor <= this.Saldo) {
                //Peguei o Saldo, retirei dele com base no valor e devolvi ao Saldo
                this.Saldo -= valor;
                return true;
            } else {
                return false;
            }
        }

        public bool Transferencia (ContaCorrenteclass destino, double valor) {
            if (this.Saque (valor)) {
                destino.Deposito (valor);
                return true;
            } else {
                return false;
            }
        }
    }
}