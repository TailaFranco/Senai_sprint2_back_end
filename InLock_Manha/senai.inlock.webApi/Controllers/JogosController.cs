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
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }
        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> listaJogos = _jogosRepository.ListarTodos();
            return Ok(listaJogos);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Delete(JogosDomain jogoDeletado)
        {
            _jogosRepository.Deletar(jogoDeletado.idJogo);
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);
            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo foi encontrado!");
            }
            return Ok(jogoBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutUrl(JogosDomain jogoAtualizado, int id)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);
            if (jogoBuscado != null)
            {
                try
                {
                    _jogosRepository.Atualizar(id, jogoAtualizado);
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
                        mensagem = "Jogo não encontrado."
                    }
                    );
        }
    }
}
