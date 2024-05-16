using AutoMapper;
using GerenciadorDeBiblioteca.Api.Data;
using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using GerenciadorDeBiblioteca.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeBiblioteca.Api.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivrosDbContext _context;
        private IMapper _maper;

        public LivroRepository(LivrosDbContext context, IMapper maper)
        {
            _context = context;
            _maper = maper;
        }
        public async Task<IEnumerable<LivroVO>> GetAll()
        {
            List<Livro> livros = await _context.Livros.ToListAsync();
            return _maper.Map<List<LivroVO>>(livros);
        }

        public async Task<LivroVO> GetById(int id)
        {
            Livro livros = await _context.Livros.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Livro();
            return _maper.Map<LivroVO>(livros);
        }
        public async Task<LivroVO> Create(LivroVO vo)
        {
            Livro livros = _maper.Map<Livro>(vo);
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();
            return _maper.Map<LivroVO>(livros);
        }

        public async Task<LivroVO> Update(LivroVO vo)
        {
            Livro livros = _maper.Map<Livro>(vo);
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();
            return _maper.Map<LivroVO>(livros);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Livro livros =
                    await _context.Livros.Where(predicate => predicate.Id == id)
                    .FirstOrDefaultAsync() ?? new Livro();
                if (livros.Id <= 0) return false;
                _context.Livros.Remove(livros);
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
