using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiLibrary.WebApi.Models;
using SenaiLibrary.WebApi.Repositories;

namespace SenaiLibrary.WebApi.Controllers
{

    /// summary
    /// Controller responsável pelos endpoints URLs ) referentes aos livros
    /// summary

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio api nomeController
    // ex : http://localhost:5000/api/livros
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
            // retorna no corpo da resposta, a lista de livros
            // retorna o status Ok - 200, sucesso
            return Ok(_jogoRepository.Listar());
        }

        // POST /api/jogos
        [HttpPost]
        // recebe a informacao do livro que deseja salvar do corpo da requisição
        public IActionResult Cadastrar(Jogo jogo)
        {
            _jogoRepository.Cadastrar(jogo);
            // o status code para um cadastro, pode ser utilizado o 201 ou 200 Ok
            return StatusCode(201);
        }

        // GET /api/livrosjogos/{id}
        [HttpGet("{id}")] // busca um jogo a partir do id passado na requisição GET

        public IActionResult BuscarPorId(int id)
        {
            // busca o jogo por id no banco
            Jogo jogo = _jogoRepository.BuscarPorId(id);
            // se o jogo não for encontrado, retorna uma status
            // de não encontrado, 404 (NotFound).
            if
            (jogo == null)
            {
                return NotFound();
            }
            // caso tenha sido encontrado, retorna o status
            // de sucesso com a informação sobre o livro
            return Ok(jogo);
        }

        // PUT /api/jogos/{id}
        [HttpPut("{ id}")] // o id passado no PUT /api/jogos/1
        // recebe a informacao do livro que deseja
        // atualizar no corpo da requisição
        public IActionResult Atualizar(int id, Jogo jogo)
        {
            // atualizar as informações de um jogo
            // no corpo da requisição, corresponde as novas informações do jogo
            // na solicitação, o id do jogo a ser atualizado
            _jogoRepository.Atualizar(id, jogo);
            return StatusCode(204);
        }
    }
}