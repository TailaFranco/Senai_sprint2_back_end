using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int id, Usuario usuarioAtualizado);
        void Deletar(int id);
        Usuario BuscarPorEmailSenha(Usuario user);
    }
}
