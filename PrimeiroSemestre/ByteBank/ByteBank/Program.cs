using System.Net.WebSockets;
using System;
namespace ByteBank {
    class Program {
        static void Main (string[] args) {
            System.Console.WriteLine ("=============================");
            System.Console.WriteLine ("         CADASTRE-SE"         );
            System.Console.WriteLine ("=============================");

            System.Console.Write ("Nome Completo: ");
            string nome = Console.ReadLine ();

            System.Console.Write ("CPF: ");
            string cpf = Console.ReadLine ();

            System.Console.Write ("E-mail: ");
            string email = Console.ReadLine ();

            Cliente cliente1 = new Cliente (nome, cpf, email);

            bool senhaOk = false;

            do {
                System.Console.WriteLine ("Digite a Senha");
                string senha = Console.ReadLine ();
                senhaOk = cliente1.TrocaSenha (senha);

                if (!senhaOk) {
                    System.Console.WriteLine ("Senha Não Atende Aos Requisitos");
                } else {
                    System.Console.WriteLine ("Senha Trocada Com Sucesso");
                }

            } while (!senhaOk);

            System.Console.WriteLine ("=============================");
            System.Console.WriteLine ("       ABRA SUA CONTA"        );
            System.Console.WriteLine ("=============================");

            System.Console.WriteLine ();

            System.Console.Write ("Número da Agência: ");
            int agencia = int.Parse (Console.ReadLine ());

            System.Console.WriteLine ();

            System.Console.Write ("Número da Conta: ");
            int conta = int.Parse (Console.ReadLine ());

            System.Console.WriteLine ();

            bool saldoOk = false;
            double saldo;

            do {
                System.Console.WriteLine ("Saldo");
                saldo = double.Parse (Console.ReadLine ());

                if (saldo > 0) {
                    saldoOk = true;
                } else {
                    System.Console.WriteLine ("O Seu Saldo Não Pode ser diferente de R$ 0,00");
                }
            } while (!saldoOk);

            ContaCorrenteclass contaCorrente = new ContaCorrenteclass (agencia, conta, cliente1);
            contaCorrente.Saque(saldo); //TA ERRADO
            contaCorrente.Deposito(saldo);
            contaCorrente.Agencia = 123;

            System.Console.WriteLine("ByteBank - Deposito");
            Cliente usuario = contaCorrente.Titular;
            System.Console.WriteLine($"Bem-vindo - {usuario.nome}");
            System.Console.WriteLine($"Conta: {contaCorrente.Agencia}    Conta: {contaCorrente.Numero}");
            System.Console.WriteLine($"Saldo: {contaCorrente.saldo}");
            System.Console.WriteLine("Digite o valor do depósito");
            double valor = double.Parse (Console.ReadLine());
            contaCorrente.Deposito (valor);
            System.Console.WriteLine();

            System.Console.WriteLine("ByteBank - Saque");
            System.Console.WriteLine("Qual o valor do saque?");
            if (contaCorrente.Saque (valor)) {
                System.Console.WriteLine("Saque realizado com sucesso");
            } else {
                System.Console.WriteLine("Não foi possível realizar a operação");
            }

            System.Console.WriteLine();

            System.Console.WriteLine("ByteBank - Transferência");
            System.Console.WriteLine("Digite o valor da Transferência: ");
            valor = double.Parse (Console.ReadLine());
            Cliente cliente2 = new Cliente ("Gabriel", "123.456.678-90", "qweasd@asd.com");
            ContaCorrenteclass contaCorrente2 = new ContaCorrenteclass (123, 123, cliente2);
            if (contaCorrente.Transferencia (contaCorrente2, valor)) {
                System.Console.WriteLine("Transferência efetuada com sucesso");
            } else {
                System.Console.WriteLine("Operação não pode ser realizada");
            }
        }
    }
}