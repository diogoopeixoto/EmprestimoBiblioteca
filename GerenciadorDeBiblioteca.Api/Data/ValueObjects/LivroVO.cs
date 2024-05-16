using GerenciadorDeBiblioteca.Api.Model.Enuns;
using System.Security.Principal;

namespace GerenciadorDeBiblioteca.Api.Data.ValueObjects
{
    public class LivroVO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePuclicacao { get; set; }
        public DisponibilidadeLivro Disponibilidade { get; set; }
    }
}
