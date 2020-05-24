using System.Collections.Generic;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class MesaCadeiraRepository
    {
        private const string PATH = "DataBase/MesaCadeira.csv";

        public MesaCadeiraRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(uint numeroMesaCadeira)
        {
            var lista = ObterTodos();

            double preco = 0.0;

            foreach(var item in lista)
            {
                if(item.Valor.Equals(numeroMesaCadeira))
                {
                    preco = item.Preco;

                    break;
                }
            }
            return preco;
        }

        public List<MesaCadeira> ObterTodos()
        {
            List<MesaCadeira> mesasCadeiras = new List<MesaCadeira>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                MesaCadeira mc = new MesaCadeira();

                string[] dados = linha.Split(";");

                mc.Valor = int.Parse(dados[0]);

                mc.Preco = double.Parse(dados[1]);

                mesasCadeiras.Add(mc);
            }
            return mesasCadeiras;
        }
    }
}