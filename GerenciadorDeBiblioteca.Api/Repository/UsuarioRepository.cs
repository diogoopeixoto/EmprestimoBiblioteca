using AutoMapper;
using GerenciadorDeBiblioteca.Api.Data;
using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using GerenciadorDeBiblioteca.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeBiblioteca.Api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivrosDbContext _context;
        private IMapper _maper;

        public UsuarioRepository(LivrosDbContext context, IMapper maper)
        {
            _context = context;
            _maper = maper;
        }

        public async Task<IEnumerable<UsuarioVO>> GetAll()
        {
            List<Usuario> usuario = await _context.Usuarios.ToListAsync();
            return _maper.Map<List<UsuarioVO>>(usuario);
        }

        public async Task<UsuarioVO> GetById(int id)
        {
            Usuario usuario =
                await _context.Usuarios.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Usuario();

            return _maper.Map<UsuarioVO>(usuario);
        }
        public async Task<UsuarioVO> Create(UsuarioVO vo)
        {
           Usuario usuario = _maper.Map<Usuario>(vo);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _maper.Map<UsuarioVO>(usuario);
        }

        public async Task<UsuarioVO> Update(UsuarioVO vo)
        {
            Usuario usuario = _maper.Map<Usuario>(vo);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _maper.Map<UsuarioVO>(usuario) ;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Usuario usuario =
                    await _context.Usuarios.Where(predicate => predicate.Id == id)
                    .FirstOrDefaultAsync() ?? new Usuario();
                if (usuario.Id <= 0) return false;
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }            
        
    }
}
