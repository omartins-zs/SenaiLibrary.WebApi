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

        // atualizar as informacoes de um jogo, a partir da busca de jogo por id
        public void Atualizar(int id, Jogo jogo)
        {
            // Busca o jogo por id
            Jogo jogoBuscado = _context.Jogos.Find(id);
            // caso encontre o jogo, atualiza as informacoes
            if (jogoBuscado != null)
            {
                // Atribui os novos valores
                jogoBuscado.TituloDoJogo = jogo.TituloDoJogo;
                jogoBuscado.LojaDisponivel = jogo.LojaDisponivel;
                jogoBuscado.Disponivel = jogo.Disponivel;
            }
            // UPDATE Jogos SET TituloDoJogo = @TituloDoJogo,
            // LojaDisponivel = @LojaDisponivel,
            // Disponivel = @Disponivel
            // WHERE Id = @IdRecebido;
            // Adiciona o jogo atualizado
            _context.Jogos.Update(jogoBuscado);
            // Salva (persistir) as informações para serem gravadas no banco de dados
            _context.SaveChanges();
        }

        /// summary
        /// Deleta um livro existente a partir do id
        /// </summary>
        /// <param name id id do estúdio que será deletado </param>
        public void Deletar(int id)
        {
            // Busca um jogo através do seu id
            Jogo jogoBuscado = _context.Jogos.Find(id);
            // Remove o livro que foi buscado
            _context.Jogos.Remove(jogoBuscado);
            // Salva as alterações
            _context.SaveChanges();
        }
    }
}
