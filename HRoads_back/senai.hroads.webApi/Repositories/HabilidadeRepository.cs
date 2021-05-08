using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);
            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza a habilidade buscada
            ctx.Habilidades.Update(habilidadeBuscada);
            // Salva as informações
            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            // Retorna a primeira habilidade para o id informado
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Adiciona uma nova habilidade
            ctx.Habilidades.Add(novaHabilidade);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca a classe pelo id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);
            // Remove a classe buscada
            ctx.Habilidades.Remove(habilidadeBuscada);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            // retorna uma lista com todas as propriedades de habilidade
            return ctx.Habilidades.ToList();
        }

        public List<Habilidade> ListarTipo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }
    }
}
