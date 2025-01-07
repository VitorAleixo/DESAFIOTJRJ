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
    public class TipoVendaRepository : ITipoVendaRepository
    {
        private readonly LivroDbContext _context;

        public TipoVendaRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoVenda>> ObterTodosAsync()
        {
            return await _context.TipoVenda.ToListAsync();
        }

        public async Task<TipoVenda> ObterPorIdAsync(int CodAu)
        {
            return await _context.TipoVenda.FindAsync(CodAu);
        }

        public async Task AdicionarAsync(TipoVenda TipoVenda)
        {
            await _context.TipoVenda.AddAsync(TipoVenda);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(TipoVenda TipoVenda)
        {
            _context.TipoVenda.Update(TipoVenda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int CodAu)
        {
            var TipoVenda = await _context.TipoVenda.FindAsync(CodAu);
            if (TipoVenda != null)
            {
                _context.TipoVenda.Remove(TipoVenda);
                await _context.SaveChangesAsync();
            }
        }

    }
}
