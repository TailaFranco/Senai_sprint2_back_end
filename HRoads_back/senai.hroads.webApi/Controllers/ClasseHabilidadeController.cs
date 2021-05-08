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
    public class ClasseHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }
        public ClasseHabilidadeController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeHabilidadeRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClasseHabilidade classeHabilidadeBuscada = _classeHabilidadeRepository.BuscarPorId(id);
            if (classeHabilidadeBuscada == null)
            {
                return NotFound("Nenhuma classe / habilidade encontrada");
            }
            return Ok(classeHabilidadeBuscada);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ClasseHabilidade novaClasseHabilidade)
        {
            //Chamada para o método
            _classeHabilidadeRepository.Cadastrar(novaClasseHabilidade);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClasseHabilidade classeHabilidadeAtualizada)
        {
            ClasseHabilidade classeHabilidadeBuscada = _classeHabilidadeRepository.BuscarPorId(id);
            if (classeHabilidadeBuscada != null)
            {
                try
                {
                    _classeHabilidadeRepository.Atualizar(id, classeHabilidadeAtualizada);
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
                { mensagem = "Classe/Habilidade não encontrada." });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _classeHabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
