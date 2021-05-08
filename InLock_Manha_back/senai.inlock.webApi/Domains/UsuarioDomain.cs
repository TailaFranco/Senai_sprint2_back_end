using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "A senha deve ter no mínimo 4 caracteres")]
        public string senha { get; set; }
    }
}
