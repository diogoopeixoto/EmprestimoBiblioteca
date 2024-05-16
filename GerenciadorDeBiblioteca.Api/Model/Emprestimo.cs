using GerenciadorDeBiblioteca.Api.Model;
using GerenciadorDeBiblioteca.Api.Model.Base;

namespace GerenciadorDeBiblioteca.Api.Model
{
    public class Emprestimo : BaseEntity
    {
        public int IdUsuarioId { get; set; } // Id do usuário
        public Usuario IdUsuario { get; set; } // Referência de navegação para o usuário

        public int IdLivroId { get; set; } // Id do livro
        public Livro IdLivro { get; set; } // Referência de navegação para o livro

        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    }
}


