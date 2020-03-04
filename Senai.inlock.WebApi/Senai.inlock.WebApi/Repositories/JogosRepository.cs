using Senai.inlock.WebApi.Domains;
using Senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        private string connection = "Data Source = LAPTOP-HB597BA2\\SQLEXPRESS; initial catalog= Inlock_Games_Manha; integrated security=true;";
        // private string connection = "Data Source=DEV601\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user Id=sa; pwd=sa@132";

        //buscar por id
        public JogosDomains BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string querySelectById = "SELECT Id_Jogos, NomeJogo FROM Jogos WHERE Id_Jogos = @ID";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        JogosDomains jogos = new JogosDomains
                        {
                            Id_Jogos = Convert.ToInt32(rdr["Id_Jogos"]),
                            NomeJogo = rdr["NomeJogo"].ToString()
                        };
                        return jogos;
                    }
                    return null;
                }
            }

        }
        //cadastrar
        public void Cadastrar(JogosDomains NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Preco,Id_Estudio)" +
                                        " VALUES (@NomeJogo,@Descricao,@DataLancamento,@Preco,@Id_Estudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", NovoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Preco", NovoJogo.Preco);
                    cmd.Parameters.AddWithValue("@Id_Estudio", NovoJogo.Id_Estudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //deletar
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string queryDelete = "DELETE FROM Jogos WHERE Id_Jogos = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //listar
        public List<JogosDomains> listar()
        {
            List<JogosDomains> jogos = new List<JogosDomains>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                string querySelectAll = "select Id_Jogos, NomeJogo , Descricao ,DataLancamento, Preco, Estudio.NomeEstudio, Estudio.Id_Estudio from Jogos" +
                                       " inner join Estudio on Estudio.Id_Estudio = Jogos.Id_Estudio";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        JogosDomains jogo = new JogosDomains
                        {
                            Id_Jogos = Convert.ToInt32(rdr["Id_Jogos"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Preco = rdr["Preco"].ToString(),
                            Id_Estudio = Convert.ToInt32(rdr["Id_Estudio"]),
                            Estudio = new EstudioDomains
                            {
                                NomeEstudio = rdr["NomeEstudio"].ToString(),
                                Id_Estudio = Convert.ToInt32(rdr["Id_Estudio"])
                            }
                            
                           
                        };
                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }
    }
}
