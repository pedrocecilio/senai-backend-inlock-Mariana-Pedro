using Microsoft.AspNetCore.Mvc;
using Senai.inlock.WebApi.Domains;
using Senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Repositories
{

   
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DEV601\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user Id=sa; pwd=sa@132";
       // private string stringConexao = "Data Source=LAPTOP-HB597BA2\\SQLEXPRESS; initial catalog=Inlock_Game_Manha; integrated security=true;";
        //atualizar ok
        public void Atualizar(int id, EstudioDomains EstudioAtualizado)
        {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE Estudio SET NomeEstudio = @NomeEstudio WHERE Id_Estudio = @ID";
                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NomeEstudio", EstudioAtualizado.NomeEstudio);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            
        }
        //Buscar por id ok
        public EstudioDomains BuscarPorId(int id)
        {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectById = "SELECT Id_Estudio, NomeEstudio FROM Estudio WHERE Id_Estudio = @ID";
                    con.Open();
                    SqlDataReader rdr;
                    using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            EstudioDomains estudio = new EstudioDomains
                            {
                                Id_Estudio = Convert.ToInt32(rdr["Id_Estudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            };
                            return estudio;
                        }
                        return null;
                    }
                }
        }
        //cadastrar ok
        public void Cadastrar(EstudioDomains NovoEstudio)
        {
            
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryInsert = "INSERT INTO Estudio(NomeEstudio) VALUES (@NomeEstudio)";
                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@NomeEstudio", NovoEstudio.NomeEstudio);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            
        }

        //deletar ok
        public void Deletar(int id)
        {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM Estudio WHERE Id_Estudio = @ID";
                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }  
        }

        //listar ok
        public List<EstudioDomains> listar()
        {
                List<EstudioDomains> estudios = new List<EstudioDomains>();
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT * FROM Estudio";
                    con.Open();
                    SqlDataReader rdr;
                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            EstudioDomains estudio = new EstudioDomains
                            {
                                Id_Estudio = Convert.ToInt32(rdr["Id_Estudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()    
                            };
                            estudios.Add(estudio);
                        }
                    }
                }
                return estudios;    
        }

       


    }
}
