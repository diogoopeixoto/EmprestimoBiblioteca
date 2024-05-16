
using GerenciadorDeBiblioteca.Api.Model.Base;
using GerenciadorDeBiblioteca.Api.Model.Enuns;

namespace GerenciadorDeBiblioteca.Api.Model
{
    public class Livro : BaseEntity
    {       
        public string Titulo { get; set; }
        public string Autor { get; set;}
        public string ISBN { get; set;}
        public int AnoDePuclicacao { get; set; }
        public DisponibilidadeLivro Disponibilidade { get; set; }
    }
}
