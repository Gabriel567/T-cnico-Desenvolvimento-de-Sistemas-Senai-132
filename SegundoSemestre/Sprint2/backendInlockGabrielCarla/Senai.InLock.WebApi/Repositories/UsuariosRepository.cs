using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string Conexao = "Data Source=LAPTOP-7C6K4DAQ\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true;";
        //private string Conexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao))
            {
                string queryBusca = "select ID_Usuario, Email, Senha, ID_TipoUsuario from Usuarios where Email = @Email and Senha = @Senha";

                conexao.Open();

                SqlDataReader leitorBusca;

                using (SqlCommand comandoBuscar = new SqlCommand(queryBusca, conexao))
                {
                    comandoBuscar.Parameters.AddWithValue("Email", email);
                    comandoBuscar.Parameters.AddWithValue("Senha", senha);

                    leitorBusca = comandoBuscar.ExecuteReader();

                    UsuariosDomain usuario = new UsuariosDomain();

                    while(leitorBusca.Read())
                    {
                        usuario.ID_Usuario = Convert.ToInt32(leitorBusca["ID_Usuario"]);
                        usuario.Email = leitorBusca["Email"].ToString();
                        usuario.Senha = leitorBusca["Senha"].ToString();
                        usuario.ID_TipoUsuario = Convert.ToInt32(leitorBusca["ID_TipoUsuario"]);

                        return usuario;
                    }

                    return null;
                }
            }
        }
    }
}
