using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipo { get; set; }
        [Required(ErrorMessage = "O campo nome habilidade é obrigatório")]
        public string NomeHabilidade { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
