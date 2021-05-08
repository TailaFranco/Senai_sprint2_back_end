using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4MFDOSC\\SQLEXPRESS; Initial Catalog=InLock_Games_Manha; user=sa; pwd=1297";
        public void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE TipoUsuario SET titulo = @titulo WHERE idTipoUsuario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", tipoUsuarioAtualizado.titulo);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM TipoUsuario WHERE idTipoUsuario =@Id";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };
                        return tipoUsuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoUsuario(titulo) VALUES (@titulo)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", novoTipoUsuario.titulo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoUsuario WHERE idTipoUsuario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> tipo = new List<TipoUsuarioDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TipoUsuario";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };
                        tipo.Add(tipoUsuario);
                    }
                    return tipo;
                }
            }
        }
    }
}
