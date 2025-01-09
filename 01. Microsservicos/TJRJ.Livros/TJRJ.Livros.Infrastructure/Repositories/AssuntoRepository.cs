using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Domain.Entities;
using TJRJ.Livros.Infrastructure.Context;

namespace TJRJ.Livros.Infrastructure.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly LivroDbContext _context;

        public AssuntoRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assunto>> ObterTodosAsync()
        {
            return await _context.Assunto.ToListAsync();
        }

        public async Task<List<int>> ObterTodosByLivroAsync(int CodI)
        {
            var autorIds = await _context.LivroAssunto
                .Where(la => la.Livro_CodI == CodI)
                .Select(la => la.Assunto_codAs) 
            .ToListAsync();

            return autorIds;
        }

        public async Task<Assunto> ObterPorIdAsync(int CodAu)
        {
            return await _context.Assunto.FindAsync(CodAu);
        }

        public async Task AdicionarAsync(Assunto Assunto)
        {
            await _context.Assunto.AddAsync(Assunto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Assunto Assunto)
        {
            _context.Assunto.Update(Assunto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int CodAu)
        {
            var Assunto = await _context.Assunto.FindAsync(CodAu);
            if (Assunto != null)
            {
                _context.Assunto.Remove(Assunto);
                await _context.SaveChangesAsync();
            }
        }

    }
}
