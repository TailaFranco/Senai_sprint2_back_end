using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoRepository
    {
        List<Tipo> Listar();
        Tipo BuscarPorId(int id);
        void Cadastrar(Tipo novoTipo);
        void Atualizar(int id, Tipo tipoAtualizado);
        void Deletar(int id);

        /// <summary>
        /// Lista todas as habilidades com seus respectivos tipos
        /// </summary>
        /// <returns></returns>
        List<Tipo> ListarHabilidade();
    }
}
