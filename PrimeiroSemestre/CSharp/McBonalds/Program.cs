using System;

namespace McBonalds {
    class Program {
        static void Main (string[] args) {
            //Fazendo link com a class Cliente

            Cliente cliente1 = new Cliente ("Gabriel", "98984-7085", "souzagabriel0006@gmail.com");
            string nome_do_cliente = cliente1.Nome;
            string telefone_do_cliente = cliente1.Telefone;
            string email_do_cliente = cliente1.Email;

            // Informações que irão aparecer na tela referente ao cliente1

            Console.WriteLine ($"O nome do cliente é {nome_do_cliente}");
            Console.WriteLine ($"O telefone do cliente é {telefone_do_cliente}");
            Console.WriteLine ($"O email do cliente é {email_do_cliente}");

            //Console.WriteLine ("Nome: " + cliente1.Nome);
        }
    }
}