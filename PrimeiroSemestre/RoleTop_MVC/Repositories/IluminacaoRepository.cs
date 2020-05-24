using System.Collections.Generic;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class IluminacaoRepository
    {
        private const string PATH = "DataBase/Iluminacao.csv";

        public IluminacaoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(string opcaoIluminacao)
        {
            var lista = ObterTodos();

            double preco = 0.0;

            foreach(var item in lista)
            {
                if(item.Nome.Equals(opcaoIluminacao))
                {
                    preco = item.Preco;

                    break;
                }
            }
            return preco;
        }

        public List<Iluminacao> ObterTodos()
        {
            List<Iluminacao> iluminacao = new List<Iluminacao>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                Iluminacao ilumi = new Iluminacao();

                string[] dados = linha.Split(";");

                ilumi.Nome = dados[0];

                ilumi.Preco = double.Parse(dados[1]);

                iluminacao.Add(ilumi);
            }
            return iluminacao;
        }
    }
}