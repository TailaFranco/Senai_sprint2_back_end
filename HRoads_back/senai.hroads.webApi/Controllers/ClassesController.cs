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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Classe classeBuscada =_classeRepository.BuscarPorId(id);
            if(classeBuscada == null)
            {
                return NotFound("Nenhuma classe encontrada");
            }
            return Ok(classeBuscada);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post (Classe novaClasse)
        {
            //Chamada para o método
            _classeRepository.Cadastrar(novaClasse);
            //retorna created
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = _classeRepository.BuscarPorId(id);
            if (classeBuscada != null)
            {
                try
                {
                    _classeRepository.Atualizar(id, classeAtualizada);
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
                {
                    mensagem = "Classe não encontrada."
                }
                );
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _classeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
