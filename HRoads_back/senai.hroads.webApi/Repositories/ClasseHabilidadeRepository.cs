using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, ClasseHabilidade classeHabilidadeatualizada)
        {
            ClasseHabilidade classeHabilidadeBuscada = ctx.ClasseHabilidades.Find(id);
            if (classeHabilidadeatualizada.IdClasse != null)
            {
                classeHabilidadeBuscada.IdClasse = classeHabilidadeatualizada.IdClasse;
            }
            if (classeHabilidadeatualizada.IdClasse != null)
            {
                classeHabilidadeBuscada.IdClasse = classeHabilidadeatualizada.IdClasse;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza a classe e habilidade buscada
            ctx.ClasseHabilidades.Update(classeHabilidadeBuscada);
            // Salva as informações
            ctx.SaveChanges();
        }

        public ClasseHabilidade BuscarPorId(int id)
        {
            // Retorna a primeira classe habilidade para o id informado
            return ctx.ClasseHabilidades.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            //Adiciona uma nova classe e habilidade
            ctx.ClasseHabilidades.Add(novaClasseHabilidade);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca a classe habilidade pelo id
            ClasseHabilidade classeHabilidadeBuscada = ctx.ClasseHabilidades.Find(id);
            // Remove a classe buscada
            ctx.ClasseHabilidades.Remove(classeHabilidadeBuscada);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> Listar()
        {
            // retorna uma lista com todas as propriedades de classes e habilidades
            return ctx.ClasseHabilidades.ToList();
        }
    }
}
