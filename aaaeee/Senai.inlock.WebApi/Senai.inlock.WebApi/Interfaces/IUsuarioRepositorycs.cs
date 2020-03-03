using Senai.inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Interfaces
{
    interface IUsuarioRepositorycs
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<UsuarioDomains> Listar();

        /// <summary>
        /// Busca um usuários através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna um usuário buscado</returns>
        UsuarioDomains BuscarPorId(int id);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(UsuarioDomains novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será alterado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado que será alterado</param>
        void Atualizar(int id, UsuarioDomains UsuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um usuário através do e-mail e da senha
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        UsuarioDomains BuscarPorEmailSenha(string email, string senha);
    

    }
}
