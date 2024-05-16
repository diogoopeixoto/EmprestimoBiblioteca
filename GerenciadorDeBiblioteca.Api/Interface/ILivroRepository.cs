using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Model;

namespace GerenciadorDeBiblioteca.Api.Interface
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroVO>> GetAll();
        Task<LivroVO> GetById(int id);
        Task<LivroVO> Create(LivroVO vo);
        Task<LivroVO> Update(LivroVO vo);
        Task<bool>Delete(int id);
    }
}
