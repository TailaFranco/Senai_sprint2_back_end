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
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }
        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);
            if (personagemBuscado == null)
            {
                return NotFound("Nenhum personagem encontrado");
            }
            return Ok(personagemBuscado);
        }
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            //Chamada para o método
            _personagemRepository.Cadastrar(novoPersonagem);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarPorId(id);
            if (personagemBuscado != null)
            {
                try
                {
                    _personagemRepository.Atualizar(id, personagemAtualizado);
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
                { mensagem = "Personagem não encontrado." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _personagemRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
