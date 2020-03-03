using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Domains
{
    
    public class EstudioDomains
    {
        public int Id_Estudio { get; set; }


        [Required(ErrorMessage = "O nome do estudio é obrigatório")]
        public string NomeEstudio { get; set; }





        
    }
}
