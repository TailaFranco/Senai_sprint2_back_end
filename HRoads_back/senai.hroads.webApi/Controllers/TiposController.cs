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
    public class TiposController : ControllerBase
    {
        private ITipoRepository _tiposRepository { get; set; }
        public TiposController()
        {
            _tiposRepository = new TipoRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposRepository.Listar());
        }
        [Authorize]
        [HttpGet("habilidade")]
        public IActionResult GetTipoHabilidade()
        {
            return Ok(_tiposRepository.ListarHabilidade());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Tipo tipoBuscado = _tiposRepository.BuscarPorId(id);
            if (tipoBuscado == null)
            {
                return NotFound("Nenhum tipo encontrado");
            }
            return Ok(tipoBuscado);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Tipo novoTipo)
        {
            //Chamada para o método
            _tiposRepository.Cadastrar(novoTipo);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Tipo tipoAtualizado)
        {
            Tipo tipoBuscado = _tiposRepository.BuscarPorId(id);
            if (tipoBuscado != null)
            {
                try
                {
                    _tiposRepository.Atualizar(id, tipoAtualizado);
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
                { mensagem = "Tipo não encontrado." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tiposRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
