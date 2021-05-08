using Microsoft.AspNetCore.Authorization;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Classe classeatualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(id);
            if(classeatualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeatualizada.NomeClasse;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT
            
            //Atualiza a classe buscada
            ctx.Classes.Update(classeBuscada);
            // Salva as informações
            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            // Retorna a primeira classe para o id informado
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {   //Adiciona uma nova classe
            ctx.Classes.Add(novaClasse);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca a classe pelo id
            Classe classeBuscada = ctx.Classes.Find(id);
            // Remove a classe buscada
            ctx.Classes.Remove(classeBuscada);
            //Salva as alterações
            ctx.SaveChanges();
        }
        
        public List<Classe> Listar()
        {
            // retorna uma lista com todas as propriedades de classes
             return ctx.Classes.ToList();
        }
    }
}
