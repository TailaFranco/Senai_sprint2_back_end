using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();
        Habilidade BuscarPorId(int id);
        void Cadastrar(Habilidade novaHabilidade);
        void Atualizar(int id, Habilidade habilidadeAtualizada);
        void Deletar(int id);

        /// <summary>
        /// Lista todas as habilidades com seus respectivos tipos
        /// </summary>
        /// <returns></returns>
        List<Habilidade> ListarTipo();

    }
}
