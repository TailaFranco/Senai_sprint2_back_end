using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            // Caso encontrado vai para a criação do token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor Teste")
            };
            // Chave de acesso do token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));
            // Credencias do token - header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // gera token
            var token = new JwtSecurityToken(
                issuer: "InLock.webApi", // emissor
                audience: "InLock.webApi", // destinatario
                claims: claims,  // dados definidos anteriormente
                expires: DateTime.Now.AddMinutes(30), // tempo de expiração
                signingCredentials: creds   // credenciais
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuarios = _usuarioRepository.ListarTodos();
            return Ok(listaUsuarios);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Delete(UsuarioDomain usuarioDeletado)
        {
            _usuarioRepository.Deletar(usuarioDeletado.idUsuario);
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario foi encontrado!");
            }
            return Ok(usuarioBuscado);
        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutUrl(UsuarioDomain usuarioAtualizado, int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
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
                        mensagem = "Usuario não encontrado."
                    }
                    );
        }
    }
}
