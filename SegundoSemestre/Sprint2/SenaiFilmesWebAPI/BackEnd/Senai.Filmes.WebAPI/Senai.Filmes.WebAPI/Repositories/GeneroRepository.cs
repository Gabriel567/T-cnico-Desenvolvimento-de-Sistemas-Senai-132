using Senai.Filmes.WebAPI.Domains;
using Senai.Filmes.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        //Definindo servidor, o banco de dados, usuario e senha
        private string Conexao = "Data Source = DEV15\\SQLEXPRESS; Initial catalog = Filmes_Manha; User ID = sa; Password = sa@132;";

        public void Deletar(int ID)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryDelete = "delete from Generos where ID_Genero = @ID";

                using(SqlCommand comando = new SqlCommand(queryDelete, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", ID);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(GeneroDomain genero)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                //string queryInsert = "insert into Generos values ('" + genero.Genero + "')";

                string queryInsert = "insert into Generos values (@Genero)";

                using (SqlCommand comando = new SqlCommand(queryInsert, conexao))
                {
                    comando.Parameters.AddWithValue("@Genero", genero.Genero);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        //Método de criação de lista para receber os dados da tabela de Generos
        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> Generos = new List<GeneroDomain>();

            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string query = "select ID_Genero, Genero from Generos";

                conexao.Open();

                //Objeto para leitura dos dados
                SqlDataReader reader;

                //Defini um comando, criando uma instancia informando a query e a conexao
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    //Vai receber tudo o que esta no comando e fará a leitura
                    reader = comando.ExecuteReader();

                    //Enquanto houver dados na tabela...
                    while (reader.Read())
                    {
                        GeneroDomain Genero = new GeneroDomain
                        {
                            ID_Genero = Convert.ToInt32(reader[0]),
                            Genero = reader["Genero"].ToString()
                        };

                        Generos.Add(Genero);
                    }
                }
            }
                return Generos;
            //Fim do método de Listar
        }

        public void AtualizarIDCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIDURL(int ID, GeneroDomain genero)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryAtualizar = "upade Generos set Genero = @Genero where ID_Genero = @ID";

                using (SqlCommand comando = new SqlCommand(queryAtualizar, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", ID);
                    comando.Parameters.AddWithValue("@Genero", genero.Genero);
                }
            }
            //throw new NotImplementedException();
        }
    }
}
