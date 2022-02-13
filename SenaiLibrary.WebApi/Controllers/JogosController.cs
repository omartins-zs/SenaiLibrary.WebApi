using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiLibrary.WebApi.Models;
using SenaiLibrary.WebApi.Repositories;
using System;

namespace SenaiLibrary.WebApi.Controllers
{

    /// summary
    /// Controller responsável pelos endpoints URLs ) referentes aos jogos
    /// summary

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio api nomeController
    // ex : http://localhost:5000/api/jogos
    [Route("api/[controller]")]

    // atributo para habilitar comportamentos especificos de API, como status, retorno
    [ApiController]
    // [ControllerBase]requisicoes HTTP

    public class JogosController : ControllerBase
    {
        private readonly JogoRepository _jogoRepository;
        public JogosController(JogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
        // GET /api/jogos
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // retorna no corpo da resposta, a lista de jogos
                // retorna o status Ok - 200, sucesso
                return Ok(_jogoRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // POST /api/jogos
        [HttpPost]
        // recebe a informacao do jogo que deseja salvar do corpo da requisição
        public IActionResult Cadastrar(Jogo jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);
                // o status code para um cadastro, pode ser utilizado o 201 ou 200 Ok
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET BY ID /api/jogos/{id}
        [HttpGet("{id}")] // busca um jogo a partir do id passado na requisição GET
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                // busca o jogo por id no banco
                Jogo jogo = _jogoRepository.BuscarPorId(id);
                // se o jogo não for encontrado, retorna uma status
                // de não encontrado, 404 (NotFound).
                if (jogo == null)
                {
                    return NotFound();
                }
                // caso tenha sido encontrado, retorna o status
                // de sucesso com a informação sobre o jogo
                return Ok(jogo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT /api/jogos/{id}
        [AllowAnonymous]
        [HttpPut("{ id}")] // o id passado no PUT /api/jogos/1
        // recebe a informacao do jogo que deseja
        // atualizar no corpo da requisição
        public IActionResult Atualizar(int id, Jogo jogo)
        {
            try
            {
                // atualizar as informações de um jogo
                // no corpo da requisição, corresponde as novas informações do jogo
                // na solicitação, o id do jogo a ser atualizado
                _jogoRepository.Atualizar(id, jogo);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // DELETE /api/jogos/{id}
        [Authorize]
        [HttpDelete("{id}")]  // o id passado no DELETE api/jogos/1
        public IActionResult Deletar(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}