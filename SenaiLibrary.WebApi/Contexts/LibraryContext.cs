using Microsoft.EntityFrameworkCore;
using SenaiLibrary.WebApi.Models;

namespace SenaiLibrary.WebApi.Contexts
{
    // dbcontext é a ponte entre o modelo de classe e o banco de dados
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {

        }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                // PC
                // optionsBuilder.UseSqlServer(("DataSource = DESKTOP-7JNQVD9t\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true"

                // Notebook
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-98U2MDO\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");
            }
        }
        //dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Jogo> Jogos { get; set; }

    }

}