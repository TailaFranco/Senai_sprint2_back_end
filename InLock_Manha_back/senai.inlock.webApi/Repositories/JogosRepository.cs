using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4MFDOSC\\SQLEXPRESS; Initial Catalog=InLock_Games_Manha; user=sa; pwd=1297";
        public void Atualizar(int id, JogosDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET valor = @valor WHERE idJogo = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Jogos WHERE idJogo =@Id";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        JogosDomain jogoBuscado = new JogosDomain
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"])
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos (idEstudio, nomeJogo, descricao, dataLancamento, valor) VALUES (@idEstudio, @nomeJogo, @descricao, @dataLancamento,@valor)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarTodos()
        {

            List<JogosDomain> jogos = new List<JogosDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Jogos";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"])
                        };
                        jogos.Add(jogo);
                    }
                    return jogos;
                }
            }
        }
    }
}
