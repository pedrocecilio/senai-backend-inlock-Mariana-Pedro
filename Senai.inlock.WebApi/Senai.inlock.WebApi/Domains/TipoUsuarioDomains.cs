using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Domains
{
    public class TipoUsuarioDomains
    {
        public int Id_TipoUsuario { get; set; }

        // Define que o título do tipo de usuário é obrigatório
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string Titulo { get; set; }

    }
}
