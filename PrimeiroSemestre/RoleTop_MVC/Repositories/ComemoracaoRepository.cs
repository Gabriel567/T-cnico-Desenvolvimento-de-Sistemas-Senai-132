using System.Collections.Generic;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class ComemoracaoRepository
    {
        private const string PATH  = "DataBase/Comemoracao.csv";

        public ComemoracaoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(string nomeComemoracao)
        {
            var lista = ObterTodos();

            double preco = 0.0;

            foreach(var item in lista)
            {
                if(item.Nome.Equals(nomeComemoracao))
                {
                    preco = item.Preco;

                    break;
                }
            }
            return preco;
        }

        public List<Comemoracao> ObterTodos()
        {
            List<Comemoracao> comemoracoes = new List<Comemoracao>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                Comemoracao comemoracao = new Comemoracao();

                string[] dados = linha.Split(";");

                comemoracao.Nome = dados[0];

                comemoracao.Preco = double.Parse(dados[1]);

                comemoracoes.Add(comemoracao);
            }
            return comemoracoes;
        }
    }
}