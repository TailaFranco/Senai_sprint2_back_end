using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> Listar();
        Classe BuscarPorId(int id);
        void Cadastrar(Classe novaClasse);
        void Atualizar(int id, Classe classeatualizada);
        void Deletar(int id);

    }
}
