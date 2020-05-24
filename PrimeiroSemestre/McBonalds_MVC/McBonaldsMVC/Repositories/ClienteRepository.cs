using System;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories 
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Cliente cliente) 
        {
            var linha = new string[] { PrepararRegistroCSV(cliente) };
            File.AppendAllLines(PATH, linha);

            return true;
        }

        //!verificação do login do cliente pelo email dele 

        public Cliente ObterPor(string email)
        {
            var linhas  =File.ReadAllLines(PATH);

            //!Extrair o valor das linhas 

            foreach(var linha in linhas)
            {
                if(ExtrairvalordoCampo("email",linha).Equals(email))
                {
                    Cliente c = new Cliente();

                    c.Nome = ExtrairvalordoCampo("nome",linha);

                    c.Email = ExtrairvalordoCampo("email",linha);

                    c.Senha = ExtrairvalordoCampo("senha",linha);

                    c.Endereco =ExtrairvalordoCampo("endereco",linha);

                    c.Telefone = ExtrairvalordoCampo("telefone",linha);

                    c.DataNascimento = DateTime.Parse(ExtrairvalordoCampo("data_nascimento",linha));
                    
                    c.TipoUsuario = uint.Parse(ExtrairvalordoCampo("tipo_usuario", linha));
                    
                    return c;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};endereco={cliente.Endereco};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento}";
        }

    }
}