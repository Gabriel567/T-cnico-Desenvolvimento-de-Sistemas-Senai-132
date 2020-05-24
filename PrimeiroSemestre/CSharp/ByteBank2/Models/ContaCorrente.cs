using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank2.Models
{
    #region Inicialização de classe + herança de ContaBancaria para ContaEspecial
    public class ContaCorrente : ContaBancaria //A partir do momento em que ContaCorrente herda os métodos de ContaBancaria, os métodos passam a ser da ContaCorrente
    #endregion
    {
        public ContaCorrente(int Agencia, int NumeroConta, string Titular): base(Agencia, NumeroConta, Titular) {
            Saldo = 0.0; //F10 = no modo debug, tem a função de executar sem mostrar os detalhes; F11 tem a função de executar mostrando todos os detalhes
        }

        public override Saque(double valor) {
            if (valor >= 0) {
                if (valor <= this.Saldo) {
                    this.Saldo -= valor;
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }
    }
}