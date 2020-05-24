using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank2.Models {
    public class ContaEspecial : ContaBancaria {
        public double Limite;

        #region Construtor da ContaEspecial
        public ContaEspecial (int Agencia, int NumeroConta, string Titular) : base (Agencia, NumeroConta, Titular) {
            Limite = 0.0;
        }
        #endregion

        public override bool Saque (double valor) {
            if (valor >= 0) {
                if (valor <= base.Saldo + Limite) {
                    Saldo -= valor;
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        public bool setLimite(double valor) { //setLimite não tem um real significado, mas simboliza um método de acesso para o Limite
            if(valor >= 0) {
                Limite = valor;
                return true;
            }
            return false;
        }
    }
}