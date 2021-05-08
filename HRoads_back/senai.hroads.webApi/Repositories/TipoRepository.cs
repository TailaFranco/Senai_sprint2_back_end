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
    public class TipoRepository : ITipoRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Tipo tipoAtualizado)
        {
            Tipo tipoBuscado = ctx.Tipos.Find(id);
            if (tipoAtualizado.NomeTipo != null)
            {
                tipoBuscado.NomeTipo = tipoAtualizado.NomeTipo;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza o tipo buscado
            ctx.Tipos.Update(tipoBuscado);
            // Salva as informações
            ctx.SaveChanges();
        }

        public Tipo BuscarPorId(int id)
        {
            return ctx.Tipos.FirstOrDefault(t => t.IdTipo == id);
        }

        public void Cadastrar(Tipo novoTipo)
        {
            //Adiciona um novo Tipo
            ctx.Tipos.Add(novoTipo);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca o tipo pelo id
            Tipo tipoBuscado = ctx.Tipos.Find(id);
            // Remove o tipo buscado
            ctx.Tipos.Remove(tipoBuscado);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Tipo> Listar()
        {
            // retorna uma lista com todos os dados de tipos
            return ctx.Tipos.ToList();
        }

        public List<Tipo> ListarHabilidade()
        {
            return ctx.Tipos.Include(t => t.Habilidades).ToList();
        }
    }
}
