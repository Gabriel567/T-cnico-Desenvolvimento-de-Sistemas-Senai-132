using System.Collections.Generic;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories {
    public class ConvidadosRepository 
    {
        private const string PATH = "DataBase/Convidados.csv";

        public ConvidadosRepository () 
        {
            if (!File.Exists (PATH))
            {
                File.Create (PATH).Close ();
            }
        }

        public double ObterPrecoDe (uint numeroConvidados) 
        {
            var lista = ObterTodos();

            double preco = 0.0;

            foreach (var item in lista)
            {
                if (item.Valor.Equals (numeroConvidados))
                {
                    preco = item.Preco;

                    break;
                }
            }
            return preco;
        }

        public List<Convidados> ObterTodos()
        {
            List<Convidados> convidado = new List<Convidados>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                Convidados conv =  new Convidados();

                string[] dados = linha.Split(";");

                conv.Valor = int.Parse(dados[0]);

                conv.Preco = double.Parse(dados[1]);

                convidado.Add(conv);
            }
            return convidado;
        }
    }
}