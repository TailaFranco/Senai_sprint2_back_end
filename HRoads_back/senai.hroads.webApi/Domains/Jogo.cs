using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Jogo
    {
        public Jogo()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdJogo { get; set; }
        [Required(ErrorMessage = "O campo nome jogo é obrigatório")]
        public string NomeJogo { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
