using System;
using System.IO;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "DataBase/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] {PrepararRegistroCSV(cliente)};

            File.AppendAllLines(PATH, linha);

            return true;
        }

        public Cliente ObterPor(string usuario)
        {
            var linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                if(ExtrairValorDoCampo("nome", linha).Equals(usuario))
                {
                    Cliente c = new Cliente();

                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", linha));

                    c.Nome = ExtrairValorDoCampo("nome", linha);

                    c.DataNascimento = DateTime.Parse(ExtrairValorDoCampo("nascimento", linha));

                    c.Email = ExtrairValorDoCampo("email", linha);

                    c.Senha = ExtrairValorDoCampo("senha", linha);

                    c.RepitaSenha = ExtrairValorDoCampo("repitaSenha", linha);

                    return c;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
                return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};nascimento={cliente.DataNascimento};email={cliente.Email};senha={cliente.Senha};repitaSenha={cliente.RepitaSenha}";
        }
    }
}