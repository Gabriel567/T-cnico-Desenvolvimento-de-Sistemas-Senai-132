using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string Conexao = "Data Source = LAPTOP-7C6K4DAQ\\SQLEXPRESS; initial catalog = M_Peoples; user ID = sa; pwd = sa@132";

        public void Cadastro(FuncionarioDomain Funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryCadastro = "insert into Funcionarios (Nome, Sobrenome) values (@Nome, @Sobrenome)";

                SqlCommand comandoCadastro = new SqlCommand(queryCadastro, conexao);

                comandoCadastro.Parameters.AddWithValue("@Nome", Funcionario.Nome);
                comandoCadastro.Parameters.AddWithValue("@Sobrenome", Funcionario.Sobrenome);

                conexao.Open();

                comandoCadastro.ExecuteNonQuery();

                /*1 - Criei uma string de Conexao que vai me possibilitar me conectar ao banco de dados
                   2 - Criei a função de cadastrar um funcionário, passando como parametros: nome e sobrenome
                   3 - Usei a conexao do SQL para criar uma conexao que me conecte a Conexao
                   4 - Criei uma queryCadastro que leva o comando de insert do SQL Server
                   5 - Criei um comando em SQL que executara a queryCadastro e se conectara a conexao que por sua vez se conectara a Conexao
                   6 - Na hora do cadastro, irá ser inserido o Nome e o Sobrenome
                   7 - Abri a conexao com o banco de dados
                   8 - Executei o comando.*/
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using(SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryListar = "select ID_Funcionario, Nome, Sobrenome, DataNascimento from Funcionarios";

                conexao.Open();

                SqlDataReader leitorListar;

                using(SqlCommand comandoListar = new SqlCommand(queryListar, conexao))
                {
                    leitorListar = comandoListar.ExecuteReader();

                    while(leitorListar.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            ID_Funcionario = Convert.ToInt32(leitorListar[0]),
                            Nome = leitorListar["Nome"].ToString(),
                            Sobrenome = leitorListar["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(leitorListar[3])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public void Deletar(int ID)
        {
            using(SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryDeletar = "delete from Funcionarios where ID_Funcionario = @ID";

                using(SqlCommand comandoDeletar = new SqlCommand(queryDeletar, conexao))
                {
                    comandoDeletar.Parameters.AddWithValue("@ID", ID);
                    //comandoDeletar.Parameters.AddWithValue(queryDeletar, conexao);

                    conexao.Open();

                    comandoDeletar.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscaPorID(int ID)
        {
            using(SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryBuscaPorID = "select ID_Funcionario, Nome, Sobrenome, DataNascimento from Funcionarios where ID_Funcionario = @ID";

                conexao.Open();

                SqlDataReader leitorBuscaPorID;

                using(SqlCommand comandoBuscaPorID = new SqlCommand(queryBuscaPorID, conexao))
                {
                    comandoBuscaPorID.Parameters.AddWithValue("@ID", ID);

                    leitorBuscaPorID = comandoBuscaPorID.ExecuteReader();

                    if(leitorBuscaPorID.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            ID_Funcionario = Convert.ToInt32(leitorBuscaPorID[0]),
                            Nome = leitorBuscaPorID["Nome"].ToString(),
                            Sobrenome = leitorBuscaPorID["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(leitorBuscaPorID[3])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public FuncionarioDomain BuscaPorNome(string Nome)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryBuscaPorNome = "select ID_Funcionario, Nome, Sobrenome, DataNascimento from Funcionarios where Nome = @Nome";

                conexao.Open();

                SqlDataReader leitorBuscaPorNome;

                using (SqlCommand comandoBuscaPorNome = new SqlCommand(queryBuscaPorNome, conexao))
                {
                    comandoBuscaPorNome.Parameters.AddWithValue("@Nome", Nome);

                    leitorBuscaPorNome = comandoBuscaPorNome.ExecuteReader();

                    if(leitorBuscaPorNome.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            ID_Funcionario = Convert.ToInt32(leitorBuscaPorNome[0]),
                            Nome = leitorBuscaPorNome["Nome"].ToString(),
                            Sobrenome = leitorBuscaPorNome["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(leitorBuscaPorNome[3])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public void AtualizarIDURL(int ID, FuncionarioDomain funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryAtualizarIDURL = "update Funcionarios set Nome = @Nome where ID_Funcionario = @ID";

                using (SqlCommand comandoAtualizarIDURL = new SqlCommand(queryAtualizarIDURL, conexao))
                {
                    comandoAtualizarIDURL.Parameters.AddWithValue("@ID", ID);
                    comandoAtualizarIDURL.Parameters.AddWithValue("@Nome", funcionario.Nome);

                    conexao.Open();

                    comandoAtualizarIDURL.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIDCorpo(FuncionarioDomain funcionario)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                // Declara a query que será executada
                string queryAtualizarIDCorpo = "update Funcionarios set Nome = @Nome  ID_Funcionario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryAtualizarIDCorpo, conexao))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", funcionario.ID_Funcionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                    // Abre a conexão com o banco de dados
                    conexao.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
