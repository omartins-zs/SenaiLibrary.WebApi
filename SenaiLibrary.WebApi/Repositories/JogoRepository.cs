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

        // Cadastrar um Jogo no banco de dados
        public
        void Cadastrar(Jogo jogo)
        {
            // INSERT INTO Jogos VALUES([TituloDoJogo], [LojaDisponivel], [Disponivel])
            // Adiciona o novo Jogo
            _context.Jogos.Add(jogo);
            // Salva (persistir) as informações para serem gravadas no banco de dados
            _context.SaveChanges();
        }

        // busca as informações de um jogo por id
        public Jogo BuscarPorId(int id)
        {
            // SELECT Id, TituloDoJogo, LojaDisponivel, Disponivel
            // FROM Jogos WHERE Id = $idRecebido
            return _context.Jogos.Find(id);
        }
    }
}
