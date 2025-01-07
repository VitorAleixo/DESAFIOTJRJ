using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Domain.Entities;
using TJRJ.Livros.Infrastructure.Context;

namespace TJRJ.Livros.Infrastructure.Repositories.Relations
{
    public class LivroAssuntoRepository : ILivroAssuntoRepository
    {
        private readonly LivroDbContext _context;

        public LivroAssuntoRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(LivroAssunto assunto)
        {
            await _context.LivroAssunto.AddAsync(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int CodI)
        {
            var livroAssuntos = await _context.LivroAssunto
             .Where(la => la.Livro_CodI == CodI).ToListAsync();

            _context.LivroAssunto.RemoveRange(livroAssuntos);

            await _context.SaveChangesAsync();
        }
    }
}
