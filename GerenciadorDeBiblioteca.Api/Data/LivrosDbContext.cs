using GerenciadorDeBiblioteca.Api.Model;
using Microsoft.EntityFrameworkCore;

using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace GerenciadorDeBiblioteca.Api.Data
{
    public class LivrosDbContext : DbContext
    {
        public LivrosDbContext() { }

        public LivrosDbContext(DbContextOptions<LivrosDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
    }
}
