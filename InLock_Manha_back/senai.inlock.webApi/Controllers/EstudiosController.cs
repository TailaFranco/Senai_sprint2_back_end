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
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository { get; set; }

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudiosDomain> listaEstudios = _estudiosRepository.ListarTodos();
            return Ok(listaEstudios);
        }

        [Authorize (Roles ="1")]
        [HttpPost]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            _estudiosRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(EstudiosDomain estudioDeletado)
        {
            _estudiosRepository.Deletar(estudioDeletado.idEstudio);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudiosDomain estudioBuscado = _estudiosRepository.BuscarPorId(id);
            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estudio foi encontrado!");
            }
            return Ok(estudioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(EstudiosDomain estudioAtualizado, int id)
        {
            EstudiosDomain estudioBuscado = _estudiosRepository.BuscarPorId(id);
            if(estudioBuscado != null)
            {
                try
                {
                    _estudiosRepository.Atualizar(id, estudioAtualizado);
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
                        mensagem = "Estudio não encontrado."
                    }
                    );
        }
    }
}
