using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Tipo
    {
        public Tipo()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipo { get; set; }
        [Required(ErrorMessage = "O campo nome tipo habilidade é obrigatório")]
        public string NomeTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
