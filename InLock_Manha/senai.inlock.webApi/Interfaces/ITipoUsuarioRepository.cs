using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();

        TipoUsuarioDomain BuscarPorId(int id);
        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);
        void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
