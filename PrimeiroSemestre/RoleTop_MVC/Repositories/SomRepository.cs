using System.Collections.Generic;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class SomRepository
    {
        private const string PATH = "DataBase/Som.csv";

        public SomRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(string opcaoSom)
        {
            var lista = ObterTodos();

            double preco = 0.0;

            foreach(var item in lista)
            {
                if(item.Nome.Equals(opcaoSom))
                {
                    preco = item.Preco;

                    break;
                }
            }
            return preco;
        }

        public List<Som> ObterTodos()
        {
            List<Som> som = new List<Som>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                Som sound = new Som();

                string[] dados = linha.Split(";");

                sound.Nome = dados[0];

                sound.Preco = double.Parse(dados[1]);

                som.Add(sound);
            }
            return som;
        }
    }
}