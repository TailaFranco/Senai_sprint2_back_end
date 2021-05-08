using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdJogo { get; set; }
        public int? IdClasse { get; set; }
        [Required(ErrorMessage = "O campo nome personagem é obrigatório")]
        public string NomePersonagem { get; set; }
        [Required(ErrorMessage = "O campo cap. max de vida é obrigatório")]
        public int CapacidadeMaximaDeVida { get; set; }
        [Required(ErrorMessage = "O campo cap. max de mana é obrigatório")]
        public int CapacidadeMaximaDeMana { get; set; }
        [Required(ErrorMessage = "O campo data atualização é obrigatório")]
        public DateTime DataAtualizacao { get; set; }
        [Required(ErrorMessage = "O campo data criação é obrigatório")]
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Jogo IdJogoNavigation { get; set; }
    }
}
