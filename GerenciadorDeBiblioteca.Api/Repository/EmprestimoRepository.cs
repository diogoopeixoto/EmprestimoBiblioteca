﻿using AutoMapper;
using GerenciadorDeBiblioteca.Api.Data;
using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using GerenciadorDeBiblioteca.Api.Model;
using GerenciadorDeBiblioteca.Api.Model.Enuns;
using Microsoft.EntityFrameworkCore;

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
                throw new InvalidOperationException("O livro não está disponível para empréstimo.");           
                        
            livro.Disponibilidade = DisponibilidadeLivro.Indisponivel;
            _context.Livros.Update(livro);          
            
            Emprestimo emprestimo = new Emprestimo
            {
                IdUsuario = vo.IdUsuario, 
                IdLivroId = livro.Id, 
                DataDeEmprestimo = DateTime.Now
            };
                                               
            _context.Emprestimo.Add(emprestimo);                        
            await _context.SaveChangesAsync();

            return vo;
        }

        public async Task<EmprestimoVO> Update(EmprestimoVO vo)
        {
            var existeEmprestimo = await _context.Emprestimo.FirstOrDefaultAsync(e => e.Id == vo.Id);
            if (existeEmprestimo == null)
                throw new InvalidOperationException("O empréstimo não foi encontrado.");
                        
            existeEmprestimo.IdUsuario = vo.IdUsuario;
            existeEmprestimo.IdLivro = vo.IdLivro;
            existeEmprestimo.DataDeEmprestimo = vo.DataDeEmprestimo;

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
