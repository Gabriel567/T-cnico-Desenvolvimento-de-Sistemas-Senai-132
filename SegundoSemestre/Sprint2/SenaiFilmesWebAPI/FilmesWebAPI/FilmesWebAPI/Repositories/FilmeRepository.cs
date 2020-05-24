using FilmesWebAPI.Controllers;
using FilmesWebAPI.Domains;
using FilmesWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebAPI.Repositories
{
    //Repositório dos filmes, onde será determinado o que cada método irá fazer
    //Ele herda de IFilmeRepository, pois é lá que estão os métodos a serem chamados, aqui está a execução dos mesmos
    public class FilmeRepository : IFilmeRepository
    {
        //String de conexão com o banco de dados que irá receber os parâmentros
        //integrated security = true - Faz a autenticação com o usuário do sistema
        //user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        private string Conexao = "Data Source = DEV15\\SQLEXPRESS; initial catalog = Filmes_Manha; user ID = sa; pwd = sa@132";

        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                //O comando do banco de dados é tratado como query, nesse caso de inserçaõ, sendo assim, queryInsert (padrão camelCase)
                string queryInsert = "insert into Filmes (NomeFilme, ID_Genero) values (@NomeFilme, @ID_Genero)";

                //Executo o comando do SQL para que a query seja executada, se ligando a conexao, que por sua vez se conecta a Conexao propriamente dita com o banco de dados
                SqlCommand comandoInsert = new SqlCommand(queryInsert, conexao);

                //Passando os valores do que será inserido (parâmetros com valores atribuidos)
                //Já que um filme será inserido, passarei o nome e o ID_Genero correspondente
                comandoInsert.Parameters.AddWithValue("@NomeFilme", filme.NomeFilme);
                comandoInsert.Parameters.AddWithValue("@ID_Genero", filme.ID_Genero);

                //Abrindo a conexão com o banco de dados
                conexao.Open();

                //Executa o comando e nada mais
                comandoInsert.ExecuteNonQuery();
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string querySelect = "select NomeFilme, ID_Filme, ID_Genero from Filmes";

                conexao.Open();

                //Declaro um SqlDataReader para ler os dados da minha lista de filmes
                //Não há atribuiçaõ, pois SqlDataReader não é um tipo de variável
                SqlDataReader leitorFilmes;

                using (SqlCommand comandoSelect = new SqlCommand(querySelect, conexao))
                {
                    //Executo a query juntamente com o leitorFilmes, afinal, eu estou selecionando algo da minha tabela e quero ler
                    leitorFilmes = comandoSelect.ExecuteReader();

                    while (leitorFilmes.Read())
                    {
                        // Cria um objeto genero do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade ID_Filme o valor da primeira coluna da tabela do banco
                            ID_Filme = Convert.ToInt32(leitorFilmes[1]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeFilme = leitorFilmes["NomeFilme"].ToString(),

                            ID_Genero = Convert.ToInt32(leitorFilmes[2]),
                        };

                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public void Deletar(int ID)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryDeletar = "delete from Filmes where ID_Filme = @ID";

                using (SqlCommand comandoDeletar = new SqlCommand(queryDeletar, conexao))
                {
                    comandoDeletar.Parameters.AddWithValue("ID", ID);

                    conexao.Open();

                    comandoDeletar.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscaPorID(int ID)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string querySelectByID = "select ID_Filme.NomeFilme from Filmes where ID_Filme = @ID";

                conexao.Open();

                SqlDataReader leitorID;

                using (SqlCommand comandoID = new SqlCommand(querySelectByID, conexao))
                {
                    comandoID.Parameters.AddWithValue("@ID", ID);

                    leitorID = comandoID.ExecuteReader();

                    if(leitorID.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            ID_Filme = Convert.ToInt32(leitorID["ID_Filme"]),

                            NomeFilme = leitorID[ "NomeFilme"].ToString()
                        };

                        return filme;
                    }
                    return null;
                }
            }
        }

        public void AtualizarIDURL(int ID, FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                // Declara a query que será executada
                string queryUpdate = "update Filmes set NomeFilme = @NomeFilme where ID_FIlme = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, conexao))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Nome", filme.NomeFilme);

                    // Abre a conexão com o banco de dados
                    conexao.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIDCorpo(FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                // Declara a query que será executada
                string queryUpdate = "update Filmes set Nome = @NomeFilme  ID_Filme = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, conexao))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", filme.ID_Filme);
                    cmd.Parameters.AddWithValue("@NomeFilme", filme.NomeFilme);

                    // Abre a conexão com o banco de dados
                    conexao.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
