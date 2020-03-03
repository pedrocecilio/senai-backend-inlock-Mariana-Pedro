using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Domains
{
    public class UsuarioDomains
    {
        public int Id_Usuario { get; set; }

        // Define que o e-mail é obrigatório
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a senha é obrigatório
        [Required(ErrorMessage = "Informe a senha do usuário")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos da senha
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo 6 e no máximo 30 caracteres")]
        public string Senha { get; set; }

        public int Id_TipoUsuario { get; set; }

        public TipoUsuarioDomains TipoUsuario { get; set; }
    }
}
