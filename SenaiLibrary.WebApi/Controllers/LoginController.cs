using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaiLibrary.WebApi.Models;
using SenaiLibrary.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SenaiLibrary.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes ao Login
    /// </summary>
    /// 
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    // http://localhost:5000/api/login
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JogadorRepository _jogadorRepository;
        public LoginController(JogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a  senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>

        // dominio/api/Login
        [HttpPost]
        public IActionResult Post(Jogador login)
        {
            // Busca o usuário pelo e-mail e senha
            Jogador jogadorBuscado = _jogadorRepository.Login(login.Email, login.Senha);
            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (jogadorBuscado == null)
            {
                // Retorna NotFound com uma mensagem de erro
                return NotFound("E-mail ou senha inválidos!");
            }
            // Caso o usuário seja encontrado, prossegue para a criação do token

            /*
            Dependências
            Criar e validar o JWT: 
            System.IdentityModel.Tokens.Jwt
            Integrar a autenticação: 
            Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
            */

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                // Armazena na Claim o e-mail do usuário autenticado
                new Claim(JwtRegisteredClaimNames.Email,
                jogadorBuscado.Email),
                // Armazena na Claim o ID do usuário autenticado
                new Claim(JwtRegisteredClaimNames.Jti,
                jogadorBuscado.Id.ToString()),
             };


            // Define a chave de acesso ao token
            var key = new
            SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapterchave-autenticacao"));
            // Define as credenciais do token
            var creds = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256);
            // Gera o token
            var token = new JwtSecurityToken(
            issuer: "chapter.webapi", // emissor do token
            audience: "chapter.webapi", // destinatário do token
            claims: claims, // dados definidos acima
            expires: DateTime.Now.AddMinutes(30), // tempo de expiração
            signingCredentials: creds // credenciais do token
            );
            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}


