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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }
        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_HabilidadeRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Habilidade HabilidadeBuscada = _HabilidadeRepository.BuscarPorId(id);
            if (HabilidadeBuscada == null)
            {
                return NotFound("Nenhuma habilidade encontrada");
            }
            return Ok(HabilidadeBuscada);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            //Chamada para o método
            _HabilidadeRepository.Cadastrar(novaHabilidade);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade HabilidadeBuscada = _HabilidadeRepository.BuscarPorId(id);
            if (HabilidadeBuscada != null)
            {
                try
                {
                    _HabilidadeRepository.Atualizar(id, habilidadeAtualizada);
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
                {mensagem = "Habilidade não encontrada." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _HabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpGet("tipos")]
        public IActionResult GetTipoHabilidade()
        {
            return Ok(_HabilidadeRepository.ListarTipo());
        }
    }
}
