using GerenciadorDeBiblioteca.Api.Model;

namespace GerenciadorDeBiblioteca.Api.Data.ValueObjects
{
    public class EmprestimoVO
    {
        public int Id { get; set; }
        public int IdUsuarioId { get; set; } 
        public Usuario IdUsuario { get; set; }
        public int IdLivroId { get; set; } 
        public Livro IdLivro { get; set; } 
        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    }
}
