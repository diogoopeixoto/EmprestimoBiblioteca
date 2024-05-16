using GerenciadorDeBiblioteca.Api.Data.ValueObjects;

namespace GerenciadorDeBiblioteca.Api.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<EmprestimoVO>> GetAll();
        Task<EmprestimoVO> GetById(int id);
        Task<EmprestimoVO> Create(EmprestimoVO vo);
        Task<EmprestimoVO> Update(EmprestimoVO vo);
        Task<bool> Delete(int id);
    }
}
