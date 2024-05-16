using GerenciadorDeBiblioteca.Api.Model.Base;

namespace GerenciadorDeBiblioteca.Api.Model
{
    public class Usuario : BaseEntity
    {       
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
