using System;

namespace adm
{
    class Program
    {
        static void Main(string[] args)
        {

            string login;
            string senha;

            Console.WriteLine("Login");
            login=Console.ReadLine();
            Console.WriteLine("Senha");
            senha=Console.ReadLine();

            if ("admin" != login) {
                Console.WriteLine("Você é um usuário comum do sistema");
            } else if (senha == "admin") {
                Console.WriteLine("Você é um administrador");
            } else if ("admin" != senha) {
                Console.WriteLine("Você é um usuário comum do sistema");
            }
        }
    }
}
