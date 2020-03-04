using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.inlock.WebApi.Domains
{
    public class JogosDomains
    {
        public int Id_Jogos { get; set; }


        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string NomeJogo { get; set; }
        [Required(ErrorMessage = "Informe a descrição do jogo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de lancamento do jogo")]
        [DataType(DataType.Date)] 
        public DateTime DataLancamento { get; set; }
        [Required(ErrorMessage = "Informe o preco do jogo")]
        public string Preco { get; set; }

        public int Id_Estudio { get; set; }

        public EstudioDomains Estudio { get; set; }





    }
}
