using SenaiLibrary.WebApi.Contexts;
using SenaiLibrary.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SenaiLibrary.WebApi.Repositories
{
    public class JogoRepository
    {
        // possui acesso aos dados
        private readonly LibraryContext _context;
        // somente um data context na memória da aplicação na requisição, evitar o usar o new
        // para o repositório existir, precisa do contexto, a aplicacao cria
        // configurar no startup
        public JogoRepository(LibraryContext context)
        {
            _context = context;
        }
        // retorna a lista de livros
        public List<Jogo> Listar()
        {
            // SELECT Id, TituloDoJogo, LojaDisponivel , Disponivel FROM Livros;
            return _context.Jogos.ToList();
        }
    }
}
