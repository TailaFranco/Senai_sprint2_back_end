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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }
        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuarioRepository.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TiposUsuario tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);
            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum tipo Usuario encontrado");
            }
            return Ok(tipoUsuarioBuscado);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            //Chamada para o método
            _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);
            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
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
                { mensagem = "Tipo Usuario não encontrado." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tiposUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
