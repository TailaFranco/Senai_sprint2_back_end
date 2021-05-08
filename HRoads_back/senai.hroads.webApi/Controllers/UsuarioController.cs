using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario encontrado");
            }
            return Ok(usuarioBuscado);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //Chamada para o método
            _usuarioRepository.Cadastrar(novoUsuario);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                new
                { mensagem = "Usuario não encontrado." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
