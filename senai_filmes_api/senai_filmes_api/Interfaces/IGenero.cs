using senai_filmes_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_api.Interfaces
{
    interface IGenero
    {
        List<GeneroDomain> ListarTodos();
        GeneroDomain BuscarPorId(int id);

        void Cadastrar(GeneroDomain novoGenero);

        void AtualizarIdCorpo(GeneroDomain genero);

        void AtualizarIdURL(int id, GeneroDomain genero);
        void Deletar(int id);

    }
}
