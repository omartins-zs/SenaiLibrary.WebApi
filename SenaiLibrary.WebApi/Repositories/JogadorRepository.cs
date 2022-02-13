using SenaiLibrary.WebApi.Contexts;
using SenaiLibrary.WebApi.Models;
using System.Linq;

namespace SenaiLibrary.WebApi.Repositories
{
    public class JogadorRepository
    {
        // possui acesso aos dados
        private readonly LibraryContext _context;
        // somente um data context na memória da aplicação na requisição, evitar o usar o new
        // para o repositório existir, precisa do contexto, a aplicacao cria
        // configurar no startup
        public JogadorRepository(LibraryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        public Jogador Login(string email, string senha)
        {
            // SELECT * FROM Usuarios WHERE email = @email AND senha = @senha
            // Retorna o usuário encontrado através do e-mail e da senha
            return _context.Jogadores.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }

}
