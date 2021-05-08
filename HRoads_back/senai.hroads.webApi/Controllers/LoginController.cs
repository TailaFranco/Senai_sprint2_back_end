using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login);
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            //Encontrado vai para criação do token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor Teste")
            };
            //Chave de acesso
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HRoads-chave-autenticacao"));
            //Credenciais do token - header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //gera token
            var token = new JwtSecurityToken(
                issuer: "senai.hroads.webApi", // emissor
                audience: "senai.hroads.webApi", // destinatario
                claims: claims,  // dados definidos anteriormente
                expires: DateTime.Now.AddMinutes(30), // tempo de expiração
                signingCredentials: creds   // credenciais
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
