using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        [Required(ErrorMessage = "O campo nome classe é obrigatório")]
        public string NomeClasse { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
