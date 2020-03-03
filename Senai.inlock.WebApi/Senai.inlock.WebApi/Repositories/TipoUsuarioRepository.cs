using Senai.inlock.WebApi.Domains;
using Senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepositorycs
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string connection = "Data Source = DESKTOP-FG58JV4\\SQLEXPRESS; initial catalog= Inlock_Games_Manha; integrated security=true;";
        //private string connection = "Data Source = DEV21\\SQLEXPRESS; initial catalog= Inlock_Games_Manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualziado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado que será alterado</param>
        public void Atualizar(int id, TipoUsuarioDomains TipoUsuarioAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(connection))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE TipoUsuario SET TituloTipoUsuario = @TituloTipoUsuario WHERE Id_TipoUsuario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TituloTipoUsuario", TipoUsuarioAtualizado.TituloTipoUsuario);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário buscado</returns>
        public TipoUsuarioDomains BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(connection))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT Id_TipoUsuario, TituloTipoUsuario FROM TipoUsuario WHERE Id_TipoUsuario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto tipoUsuario 
                        TipoUsuarioDomains tipoUsuario = new TipoUsuarioDomains
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                            ,
                            TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString()
                        };

                        // Retorna o tipoUsuario buscado
                        return tipoUsuario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        public void Cadastrar(TipoUsuarioDomains novoTipoUsuario)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(connection))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO TipoUsuario(TituloTipoUsuario) VALUES (@TituloTipoUsuario)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@TituloTipoUsuario", novoTipoUsuario.TituloTipoUsuario);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(connection))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM TipoUsuario WHERE Id_TipoUsuario = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuário</returns>
        public List<TipoUsuarioDomains> Listar()
        {
            // Cria uma lista tipos de usuário onde serão armazenados os dados
            List<TipoUsuarioDomains> tiposUsuario = new List<TipoUsuarioDomains>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(connection))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT Id_TipoUsuario, TituloTipoUsuario FROM TipoUsuario";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto tipoUsuario 
                        TipoUsuarioDomains tipoUsuario = new TipoUsuarioDomains
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                            ,
                            TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString()
                        };

                        // Adiciona o tipoUsuario criado à lista tiposUsuario
                        tiposUsuario.Add(tipoUsuario);
                    }
                }
            }

            // Retorna a lista de tipos de usuário
            return tiposUsuario;
        }
    }
}
