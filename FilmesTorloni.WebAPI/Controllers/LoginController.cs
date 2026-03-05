
using FilmesTorloni.WebAPI.Controllers;
using FilmesTorloni.WebAPI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Filmes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDto)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDto.Email!, loginDto.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                }
                //caso encontre o usuário, prosseguir para ciação do token JWT

                //1. Definir as informações (claims) que serão fornecidas no token - payload
                var claims = new[]
                {
                    //formato da claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.IdUsuario!),
                    
                    //existe a possibilidade de criar claims personalizadas, caso seja necessário
                   // new Claim("Claim personalizada", "Valor da minha claim personalizada")   
                };
                //2. Definir a chave de acesso ao token (secret)
                var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3. Definir as credenciais do token (header)
                var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                //4. Gerar o token
                var token = new JwtSecurityToken
                (
                    issuer: "api_filmes",

                    //Destinatário
                    audience: "api_filmes",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds

                );
                //5. Retornar o token para o cliente
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }

    public class LoginDTO
    {
        internal object Senha;
        internal object Email;
    }
}
