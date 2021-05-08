using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = _tipoUsuarioRepository.ListarTodos();
            return Ok(listaTipoUsuario);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(TipoUsuarioDomain TipoUsuarioDeletado)
        {
            _tipoUsuarioRepository.Deletar(TipoUsuarioDeletado.idTipoUsuario);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum tipo de usuario foi encontrado!");
            }
            return Ok(tipoUsuarioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(TipoUsuarioDomain tipoUsuarioAtualizado, int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
            return NotFound
                    (
                    new
                    {
                        mensagem = "Tipo Usuario não encontrado."
                    }
                    );
        }
    }
}
