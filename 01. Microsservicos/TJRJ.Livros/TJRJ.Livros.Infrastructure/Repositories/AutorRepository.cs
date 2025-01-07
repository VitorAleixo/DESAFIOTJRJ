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
    public class AutorRepository : IAutorRepository
    {
        private readonly LivroDbContext _context;

        public AutorRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> ObterTodosAsync()
        {
            return await _context.Autor.ToListAsync();
        }

        public async Task<Autor> ObterPorIdAsync(int CodAu)
        {
            return await _context.Autor.FindAsync(CodAu);
        }

        public async Task AdicionarAsync(Autor Autor)
        {
            await _context.Autor.AddAsync(Autor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Autor Autor)
        {
            _context.Autor.Update(Autor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int CodAu)
        {
            var Autor = await _context.Autor.FindAsync(CodAu);
            if (Autor != null)
            {
                _context.Autor.Remove(Autor);
                await _context.SaveChangesAsync();
            }
        }

    }
}
