using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank2.Models
{
    public abstract class ContaBancaria
    {
        public string Titular;
        public string Agencia;
        public string NumeroConta;
        public double Saldo;

        public ContaBancaria(int Agencia, int NumeroConta, string Titular) {
            this.Agencia = Agencia;
            this.NumeroConta = NumeroConta;
            this.Titular = Titular;
            this.Saldo = 0.0; //0.0 foi usado, pois o tipo de dado é double
        }

        public abstract bool Saque(double valor); //Com o uso do "abstract", nesse caso, eu posso determinar diferentes comportamentos para o Saque em diferentes métodos (ContaCorrente, ContaEspecial)

        public bool Deposito(double valor) {
            if(valor >= 0) {
                this.Saldo += valor;
                return true;
            }
            return false;
        }

        public bool Transferencia (ContaBancaria destino, double valor) {
            if(this.Saque(valor)) {
                destino.Deposito(valor);
                return true;
            }else {
                return false;
            }
            
        } //Foi colocado um return para que seja possível compilar (em todos os 3)
    }
}