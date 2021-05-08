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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);
            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado");
            }
            return Ok(jogoBuscado);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            //Chamada para o método
            _jogoRepository.Cadastrar(novoJogo);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);
            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);
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
                { mensagem = "Jogo não encontrado." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _jogoRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
