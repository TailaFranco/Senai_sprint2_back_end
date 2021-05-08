using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            // Busca o personagem pelo id
            Personagem personagemBuscado = ctx.Personagems.Find(id);
            if (personagemAtualizado.NomePersonagem != null)
            {
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }
            if (personagemAtualizado.CapacidadeMaximaDeMana != null)
            {
                personagemBuscado.CapacidadeMaximaDeMana = personagemAtualizado.CapacidadeMaximaDeMana;
            }
            if (personagemAtualizado.CapacidadeMaximaDeVida != null)
            {
                personagemBuscado.CapacidadeMaximaDeVida = personagemAtualizado.CapacidadeMaximaDeVida;
            }
            if (personagemAtualizado.DataAtualizacao != null)
            {
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza os dados do personagem buscado
            ctx.Personagems.Update(personagemBuscado);
            // Salva as informações
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            // Retorna o primeiro personagem para o id informado
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            //Adiciona uma novo personagem
            ctx.Personagems.Add(novoPersonagem);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca o personagem pelo id
            Personagem personagemBuscado = ctx.Personagems.Find(id);
            // Remove o personagem buscado
            ctx.Personagems.Remove(personagemBuscado);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            // retorna uma lista com todas as propriedades de Personagens
            return ctx.Personagems.ToList();
        }
    }
}
