using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(int id);
        void Cadastrar(TiposUsuario novoTipoUsuario);
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
