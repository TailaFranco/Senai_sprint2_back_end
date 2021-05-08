using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClasseHabilidade> Listar();
        ClasseHabilidade BuscarPorId(int id);
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);
        void Atualizar(int id, ClasseHabilidade classeHabilidadeatualizada);
        void Deletar(int id);
    }
}
