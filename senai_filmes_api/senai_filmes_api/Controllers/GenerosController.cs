using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_api.Domains;
using senai_filmes_api.Interfaces;
using senai_filmes_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_api.Controllers
{
    // Define tipo de resposta da api
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGenero _generoRepository { get; set; }
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();
            return Ok(listaGeneros);
        }
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método cadastrar
            _generoRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }
    }
}
