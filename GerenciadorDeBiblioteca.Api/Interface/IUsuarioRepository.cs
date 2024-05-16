using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Model;

namespace GerenciadorDeBiblioteca.Api.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioVO>> GetAll();
        Task<UsuarioVO> GetById(int id);
        Task<UsuarioVO> Create(UsuarioVO vo);
        Task<UsuarioVO> Update(UsuarioVO vo);
        Task<bool> Delete(int id);
    }
}
