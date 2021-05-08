using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = ctx.Jogos.Find(id);
            if (jogoAtualizado.NomeJogo != null)
            {
                jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza o jogo buscado
            ctx.Jogos.Update(jogoBuscado);
            // Salva as informações
            ctx.SaveChanges();
        }

        public Jogo BuscarPorId(int id)
        {
            // Retorna o primeiro jogo para o id informado
            return ctx.Jogos.FirstOrDefault(j => j.IdJogo == id);
        }

        public void Cadastrar(Jogo novoJogo)
        {
            //Adiciona um novo Jogo
            ctx.Jogos.Add(novoJogo);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca o jogo do id informado
            Jogo jogoBuscado = ctx.Jogos.Find(id);
            // Remove o jogo buscado
            ctx.Jogos.Remove(jogoBuscado);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            // retorna uma lista com todas as propriedades de jogos
            return ctx.Jogos.ToList();
        }
    }
}
