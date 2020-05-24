using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string Conexao = "Data Source=LAPTOP-7C6K4DAQ\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true;";
        //private string Conexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public void CadastrarEstudio(EstudiosDomain novoEstudio)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryCadastro = "insert into Estudios (NomeEstudio) values (@NomeEstudio)";

                conexao.Open();

                using (SqlCommand comandoCadastro = new SqlCommand(queryCadastro, conexao))
                {
                    comandoCadastro.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);

                    comandoCadastro.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> ListarEstudios()
        {
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryListar = "select NomeEstudio from Estudios;";

                conexao.Open();

                SqlDataReader leitorListar;

                using (SqlCommand comandoListar = new SqlCommand(queryListar, conexao))
                {
                    leitorListar = comandoListar.ExecuteReader();

                    while (leitorListar.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            NomeEstudio = Convert.ToString(leitorListar["NomeEstudio"])
                        };
                        estudios.Add(estudio);
                    }
                    return estudios;
                }
            }
        }
    }
}
