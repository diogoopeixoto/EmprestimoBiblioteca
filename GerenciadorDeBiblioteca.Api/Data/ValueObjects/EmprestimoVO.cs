using GerenciadorDeBiblioteca.Api.Model;

namespace GerenciadorDeBiblioteca.Api.Data.ValueObjects
{
    public class EmprestimoVO
    {
        public int Id { get; set; }
        public int IdUsuarioId { get; set; } // Id do usuário
        public Usuario IdUsuario { get; set; } // Referência de navegação para o usuário

        public int IdLivroId { get; set; } // Id do livro
        public Livro IdLivro { get; set; } // Referência de navegação para o livro

        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    }
}
