using senai_filmes_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_api.Interfaces
{
    interface IFilme
    {
        List<FilmeDomain> ListarTodos();
        FilmeDomain BuscarPorId(int id);

        void Cadastrar(FilmeDomain novoFilme);

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdURL(int id, FilmeDomain filme);
        void Deletar(int id);
    }
}
