using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "O campo nome tipo usuario é obrigatório")]
        public string NomeTipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
