using AutoMapper;
using GerenciadorDeBiblioteca.Api.Data;
using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using GerenciadorDeBiblioteca.Api.Model;
using GerenciadorDeBiblioteca.Api.Model.Enuns;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GerenciadorDeBiblioteca.Api.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly LivrosDbContext _context;
        private IMapper _maper;

        public EmprestimoRepository(LivrosDbContext context, IMapper maper)
        {
            _context = context;
            _maper = maper;
        }

        public async Task<IEnumerable<EmprestimoVO>> GetAll()
        {
            List<Emprestimo> emprestimo = await _context.Emprestimo.ToListAsync();

            return _maper.Map<List<EmprestimoVO>>(emprestimo);               
        }
        public async Task<EmprestimoVO> GetById(int id)
        {
           Emprestimo emprestimo = 
                await _context.Emprestimo.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Emprestimo();
            return _maper.Map<EmprestimoVO>(emprestimo) ;



        }
        public async Task<EmprestimoVO> Create(EmprestimoVO vo)
        {            
            string idLivro = vo.IdLivro.ISBN;
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.ISBN == idLivro && l.Disponibilidade == DisponibilidadeLivro.Disponivel);

            if (livro == null)
            {                
                throw new InvalidOperationException("O livro não está disponível para empréstimo.");
            }
                        
            livro.Disponibilidade = DisponibilidadeLivro.Indisponivel;
            _context.Livros.Update(livro);
            _context.Livros.Add(livro);
            
            Emprestimo emprestimo = new Emprestimo
            {
                IdUsuario = vo.IdUsuario,
                IdLivro = vo.IdLivro,
                DataDeEmprestimo = DateTime.Now
            };
              
            _context.Entry(livro).State = EntityState.Detached;                        
            _context.Emprestimo.Add(emprestimo);                        
            await _context.SaveChangesAsync();

            return vo;
        }

        public async Task<EmprestimoVO> Update(EmprestimoVO vo)
        {
            var existingEmprestimo = await _context.Emprestimo.FirstOrDefaultAsync(e => e.Id == vo.Id);
            if (existingEmprestimo == null)
                throw new InvalidOperationException("O empréstimo não foi encontrado.");

            // Atualiza os dados do empréstimo
            existingEmprestimo.IdUsuario = vo.IdUsuario;
            existingEmprestimo.IdLivro = vo.IdLivro;
            existingEmprestimo.DataDeEmprestimo = vo.DataDeEmprestimo;

            await _context.SaveChangesAsync();

            return vo;
        }

        public async Task<bool> Delete(int id)
        {
            var emprestimo = await _context.Emprestimo.FirstOrDefaultAsync(e => e.Id == id);
            if (emprestimo == null)
                return false;

            _context.Emprestimo.Remove(emprestimo);
            await _context.SaveChangesAsync();
            return true;
        }       
    }
}
