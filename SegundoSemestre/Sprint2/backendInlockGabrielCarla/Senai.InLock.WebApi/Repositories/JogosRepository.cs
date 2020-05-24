using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string Conexao = "Data Source=LAPTOP-7C6K4DAQ\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true;";
        //private string Conexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        public void CadastrarJogo(JogosDomain novoJogo)
        {
            using(SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryCadastro = "insert into Jogos(NomeJogo, Descricao, DataLancamento, Valor, ID_Estudio) values (@NomeJogo, @Descricao, @DataLancamento, @Valor, @ID_Estudio)";

                using(SqlCommand comandoCadastro = new SqlCommand(queryCadastro, conexao))
                {
                    comandoCadastro.Parameters.AddWithValue("NomeJogo", novoJogo.NomeJogo);
                    comandoCadastro.Parameters.AddWithValue("Descricao", novoJogo.Descricao);
                    comandoCadastro.Parameters.AddWithValue("DataLancamento", novoJogo.DataLancamento);
                    comandoCadastro.Parameters.AddWithValue("Valor", novoJogo.Valor);
                    comandoCadastro.Parameters.AddWithValue("ID_Estudio", novoJogo.ID_Estudio);

                    conexao.Open();

                    comandoCadastro.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarJogos()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryListar = "select Jogos.ID_Jogo, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.ID_Estudio, Estudios.NomeEstudio from Jogos inner join Estudios on Estudios.ID_Estudio = Jogos.ID_Estudio";

                conexao.Open();

                SqlDataReader leitorListar;

                using(SqlCommand comandoListar = new SqlCommand(queryListar, conexao))
                {
                    leitorListar = comandoListar.ExecuteReader();

                    while(leitorListar.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {   
                            ID_Jogo = Convert.ToInt32(leitorListar["ID_Jogo"]),
                            NomeJogo = Convert.ToString(leitorListar["NomeJogo"]),
                            Descricao = Convert.ToString(leitorListar["Descricao"]),
                            DataLancamento = Convert.ToDateTime(leitorListar["DataLancamento"]),
                            Valor = Convert.ToDecimal(leitorListar["Valor"]),
                            ID_Estudio = Convert.ToInt32(leitorListar["ID_Estudio"]),
                            NomeEstudio = Convert.ToString(leitorListar["NomeEstudio"])

                        };
                        jogos.Add(jogo);
                    }
                    return jogos;
                }
            }
        }
    }
}
