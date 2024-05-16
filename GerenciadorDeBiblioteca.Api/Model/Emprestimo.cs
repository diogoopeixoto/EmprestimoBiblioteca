using GerenciadorDeBiblioteca.Api.Model;
using GerenciadorDeBiblioteca.Api.Model.Base;

namespace GerenciadorDeBiblioteca.Api.Model
{
    public class Emprestimo : BaseEntity
    {
        public int IdUsuarioId { get; set; } 
        public Usuario IdUsuario { get; set; } 
        public int IdLivroId { get; set; } 
        public Livro IdLivro { get; set; } 
        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    }
}


