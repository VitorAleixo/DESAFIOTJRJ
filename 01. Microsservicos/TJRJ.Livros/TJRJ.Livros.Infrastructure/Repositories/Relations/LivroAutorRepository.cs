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
    public class LivroAutorRepository : ILivroAutorRepository
    {

        private readonly LivroDbContext _context;

        public LivroAutorRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(LivroAutor autor)
        {
            await _context.LivroAutor.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int CodI)
        {
            var livroAutores = await _context.LivroAutor
             .Where(la => la.Livro_CodI == CodI).ToListAsync();

            _context.LivroAutor.RemoveRange(livroAutores);

            await _context.SaveChangesAsync();
        }
    }
}
