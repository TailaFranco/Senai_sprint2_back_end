using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto (ctx) que funciona como minha stringConexao
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);
            if (tipoUsuarioAtualizado.NomeTipo != null)
            {
                tiposUsuarioBuscado.NomeTipo = tipoUsuarioAtualizado.NomeTipo;
            }
            // se tiver mais de um parametro para atualizar criar um "if" para cada, se for atualizar apenas um parametro de varios utilizar o PATCH ao inves de PUT

            //Atualiza nome Tipo Usuario buscado
            ctx.TiposUsuarios.Update(tiposUsuarioBuscado);
            // Salva as informações
            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo usuario para o id informado
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            //Adiciona um novo TipoUsuario
            ctx.TiposUsuarios.Add(novoTipoUsuario);
            // Para adicionar informações ao banco sempre utilizar o SaveChanges para salvar essas alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca o tipo pelo id
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);
            // Remove o tipo buscado
            ctx.TiposUsuarios.Remove(tiposUsuarioBuscado);
            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            // retorna uma lista com todas as propriedades de tipos Usuarios
            return ctx.TiposUsuarios.ToList();
        }
    }
}
