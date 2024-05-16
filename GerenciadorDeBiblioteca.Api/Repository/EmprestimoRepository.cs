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
            // Verifica se o livro está disponível
            string idLivro = vo.IdLivro.ISBN;
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.ISBN == idLivro && l.Disponibilidade == DisponibilidadeLivro.Disponivel);

            if (livro == null)
            {
                // Livro não está disponível para empréstimo
                throw new InvalidOperationException("O livro não está disponível para empréstimo.");
            }

            // Atualiza o status do livro para indisponível
            var disponibilidade =livro.Disponibilidade = DisponibilidadeLivro.Indisponivel;
            _context.Livros.Update(livro);
            _context.Livros.Add(livro);
            // Atualiza o esta
            // Define a data de empréstimo como a data atual
            Emprestimo emprestimo = new Emprestimo
            {
                IdUsuario = vo.IdUsuario,
                IdLivro = vo.IdLivro,
                DataDeEmprestimo = DateTime.Now
            };

           
            // Define o estado do objeto Livro como Detached
            _context.Entry(livro).State = EntityState.Detached;

            // Adiciona o empréstimo ao contexto
            _context.Emprestimo.Add(emprestimo);

            // Salva as alterações no banco de dados
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
