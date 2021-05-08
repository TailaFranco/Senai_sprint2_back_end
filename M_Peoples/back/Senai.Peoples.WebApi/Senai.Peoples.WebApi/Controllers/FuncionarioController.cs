using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FuncionarioDomain> funcionarios = _funcionarioRepository.ListarTodos();
            return Ok(funcionarios);
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);
            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionario foi encontrado!");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(FuncionarioDomain funcionarioAtualizado, int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);
            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.Atualizar(id, funcionarioAtualizado);
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
                        mensagem = "Funcionario não encontrado."
                    }
                    );
        }

    }
}
