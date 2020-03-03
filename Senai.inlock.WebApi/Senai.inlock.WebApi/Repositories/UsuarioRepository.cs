using Senai.inlock.WebApi.Domains;

 /*using Senai.inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepositorycs
     {

         /// <summary>
         /// String de conexão com o banco de dados que recebe os parâmetros
         /// </summary>
         //private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Peoples; integrated security=true;";
         private string connection = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";

         /// <summary>
         /// Atualiza um usuário existente
         /// </summary>
         /// <param name="id">ID do usuário que será atualizado</param>
         /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado que será alterado</param>
         public void Atualizar(int id, UsuarioDomains UsuarioAtualizado)
         {
             // Declara a conexão passando a string de conexão
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Declara a query que será executada
                 string queryUpdate = "UPDATE Usuarios " +
                                      "SET Email = @Email, Senha = @Senha, Id_TipoUsuario = @Id_TipoUsuario " +
                                      "WHERE Id_TipoUsuario = @ID";

                 // Declara o SqlCommand passando o comando a ser executado e a conexão
                 using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                 {
                     // Passa os valores dos parâmetros
                     cmd.Parameters.AddWithValue("@ID", id);
                     cmd.Parameters.AddWithValue("@Email", UsuarioAtualizado.Email);
                     cmd.Parameters.AddWithValue("@Senha", UsuarioAtualizado.Senha);
                     cmd.Parameters.AddWithValue("@Id_TipoUsuario", UsuarioAtualizado.Id_TipoUsuario);

                     // Abre a conexão com o banco de dados
                     con.Open();

                     // Executa o comando
                     cmd.ExecuteNonQuery();
                 }
             }
         }

         /// <summary>
         /// Valida o usuário
         /// </summary>
         /// <param name="email">E-mail do usuário</param>
         /// <param name="senha">Senha do usuário</param>
         /// <returns>Retorna um usuário validado</returns>
         public UsuarioDomains BuscarPorEmailSenha(string email, string senha)
         {
             // Define a conexão passando a string
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Define a query a ser executada no banco
                 string querySelect = "SELECT U.Id_Usuario, U.Email, U.Id_TipoUsuario, TU.Titulo FROM Usuarios U INNER JOIN TiposUsuario TU ON U.Id_TipoUsuario = TU.Id_TipoUsuario WHERE Email = @Email AND Senha = @Senha";

                 // Define o comando passando a query e a conexão
                 using (SqlCommand cmd = new SqlCommand(querySelect, con))
                 {
                     // Define o valor dos parâmetros
                     cmd.Parameters.AddWithValue("@Email", email);
                     cmd.Parameters.AddWithValue("@Senha", senha);

                     // Abre a conexão com o banco
                     con.Open();

                     // Executa o comando e armazena os dados no objeto rdr
                     SqlDataReader rdr = cmd.ExecuteReader();

                     // Caso o resultado da query possua registro
                     if (rdr.Read())
                     {
                         // Instancia um objeto usuario 
                         UsuarioDomains usuario = new UsuarioDomains
                         {
                             // Atribui às propriedades os valores das colunas da tabela do banco
                             Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"])
                             ,
                             Email = rdr["Email"].ToString()
                             ,
                             Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                             ,
                             TipoUsuario = new TipoUsuarioDomains
                             {
                                 Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                                 ,
                                 Titulo = rdr["Titulo"].ToString()
                             }
                         };

                         // Retorna o usuario buscado
                         return usuario;
                     }
                 }

                 // Caso não encontre um email e senha correspondente, retorna null
                 return null;
             }
         }

         /// <summary>
         /// Busca um usuário através do ID
         /// </summary>
         /// <param name="id">ID do usuário que será buscado</param>
         /// <returns>Retorna um usuário buscado</returns>
         public UsuarioDomains BuscarPorId(int id)
         {
             // Declara a conexão passando a string de conexão
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Declara a query que será executada
                 string querySelectById = "SELECT U.Id_Usuario, U.Email, U.Id_TipoUsuario, TU.Titulo FROM Usuarios U INNER JOIN TiposUsuario TU ON U.Id_TipoUsuario = TU.Id_TipoUsuario WHERE Id_Usuario = @ID";

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
                         // Instancia um objeto usuario 
                         UsuarioDomains usuario = new UsuarioDomains
                         {
                             // Atribui às propriedades os valores das colunas da tabela do banco
                             Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"])
                             ,
                             Email = rdr["Email"].ToString()
                             ,
                             Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                             ,
                             TipoUsuario = new TipoUsuarioDomains
                             {
                                 Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                                 ,
                                 Titulo = rdr["Titulo"].ToString()
                             }
                         };

                         // Retorna o usuario buscado
                         return usuario;
                     }

                     // Caso o resultado da query não possua registros, retorna null
                     return null;
                 }
             }
         }

         /// <summary>
         /// Cadastra um novo usuário
         /// </summary>
         /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
         public void Cadastrar(UsuarioDomains novoUsuario)
         {
             // Declara a SqlConnection passando a string de conexão
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Declara a query que será executada
                 string queryInsert = "INSERT INTO Usuarios(Email, Senha, Id_TipoUsuario) " +
                                      "VALUES (@Email, @Senha, @Id_TipoUsuario)";

                 // Declara o comando passando a query e a conexão
                 using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                 {
                     // Passa o valor do parâmetro
                     cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                     cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                     cmd.Parameters.AddWithValue("@Id_TipoUsuario", novoUsuario.Id_TipoUsuario);

                     // Abre a conexão com o banco de dados
                     con.Open();

                     // Executa o comando
                     cmd.ExecuteNonQuery();
                 }
             }
         }

         /// <summary>
         /// Deleta um usuário existente
         /// </summary>
         /// <param name="id">ID do usuário que será deletado</param>
         public void Deletar(int id)
         {
             // Declara a conexão passando a string de conexão
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Declara a query que será executada passando o valor como parâmetro
                 string queryDelete = "DELETE FROM Usuarios WHERE Id_Usuario = @ID";

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
         /// Lista todos os usuários
         /// </summary>
         /// <returns>Retorna uma lista de usuários</returns>
         public List<UsuarioDomains> Listar()
         {
             // Cria uma lista usuários onde serão armazenados os dados
             List<UsuarioDomains> usuarios = new List<UsuarioDomains>();

             // Declara a SqlConnection passando a string de conexão
             using (SqlConnection con = new SqlConnection(connection))
             {
                 // Declara a instrução a ser executada
                 string querySelectAll = "SELECT U.Id_Usuario, U.Email, U.Id_TipoUsuario, TU.Titulo FROM Usuarios U INNER JOIN TiposUsuario TU ON U.Id_TipoUsuario = TU.Id_TipoUsuario";

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
                         // Instancia um objeto usuario 
                         UsuarioDomains usuario = new UsuarioDomains
                         {
                             // Atribui às propriedades os valores das colunas da tabela do banco
                             Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"])
                             ,
                             Email = rdr["Email"].ToString()
                             ,
                             Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"]),
                             TipoUsuario = new TipoUsuarioDomains
                             {
                                 Id_TipoUsuario = Convert.ToInt32(rdr["Id_TipoUsuario"])
                                 ,
                                 Titulo = rdr["Titulo"].ToString()
                             }
                         };

                         // Adiciona o usuario criado à lista usuarios
                         usuarios.Add(usuario);
                     }
                 }
             }

             // Retorna a lista de usuários
             return usuarios;
         }

     }
}
*/
