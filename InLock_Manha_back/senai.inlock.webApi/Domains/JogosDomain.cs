using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogosDomain
    {
        public int idJogo { get; set; }
        public int idEstudio { get; set; }
        [Required(ErrorMessage = "O campo nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string descricao { get; set; }

        [Required(ErrorMessage ="O campo data de lançamento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public decimal valor { get; set; }
    }
}
