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
        private string stringConexao = "Data Source=DESKTOP-4MFDOSC\\SQLEXPRESS; initial catalog=M_Peoples_T_Peoples; user Id=sa; pwd=1297;";

        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET nome = @nome, sobrenome = @sobrenome WHERE idFuncionario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionarioAtualizado.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionarioAtualizado.sobrenome);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Funcionarios WHERE idFuncionario =@Id";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };
                        return funcionarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios(nome,sobrenome) VALUES (@nome, @sobrenome)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;
                }
            }
        }
    }
}
