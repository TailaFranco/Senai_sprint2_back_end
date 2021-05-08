using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo BuscarPorId(int id);
        void Cadastrar(Jogo novoJogo);
        void Atualizar(int id, Jogo jogoAtualizado);
        void Deletar(int id);
    }
}
