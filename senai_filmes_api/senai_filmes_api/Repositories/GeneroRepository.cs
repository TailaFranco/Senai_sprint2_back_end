using senai_filmes_api.Domains;
using senai_filmes_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_api.Repositories
{
    public class GeneroRepository : IGenero
    {
        private string stringConexao = "Data Source=DESKTOP-4MFDOSC\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=1297";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdURL(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + novoGenero.nome + "')";

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    con.Open();
                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                                nome = rdr[1].ToString()
                        };
                        listaGeneros.Add(genero);
                    }
                }
            }
            return listaGeneros;
        }
    }
}
