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
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroDbContext _context;

        public LivroRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _context.Livro.ToListAsync();
        }

        public async Task<Livro> ObterPorIdAsync(int CodI)
        {
            return await _context.Livro.FindAsync(CodI);
        }

        public async Task<Livro> AdicionarAsync(Livro Livro)
        {
            await _context.Livro.AddAsync(Livro);
            await _context.SaveChangesAsync();

            return Livro;
        }

        public async Task AtualizarAsync(Livro Livro)
        {
            _context.Livro.Update(Livro);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int CodI)
        {
            var Livro = await _context.Livro.FindAsync(CodI);
            if (Livro != null)
            {
                _context.Livro.Remove(Livro);
                await _context.SaveChangesAsync();
            }
        }

    }
}
