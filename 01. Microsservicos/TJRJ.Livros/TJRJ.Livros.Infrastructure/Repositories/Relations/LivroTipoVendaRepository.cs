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
    public class LivroTipoVendaRepository : ILivroTipoVendaRepository
    {
        private readonly LivroDbContext _context;

        public LivroTipoVendaRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivroTipoVenda>> ObterTipoVendaAsync(int CodI)
        {
            return await _context.LivroTipoVenda.Where(la => la.Livro_CodI == CodI).ToListAsync();
        }


        public async Task AdicionarAsync(LivroTipoVenda tipoVenda)
        {
            await _context.LivroTipoVenda.AddAsync(tipoVenda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(LivroTipoVenda tipoVenda)
        {
            var livroTipoVenda = await _context.LivroTipoVenda
             .Where(la => la.Livro_CodI == tipoVenda.Livro_CodI && la.TipoVenda_CodI == tipoVenda.TipoVenda_CodI).ToListAsync();

            _context.LivroTipoVenda.RemoveRange(livroTipoVenda);

            await _context.SaveChangesAsync();
        }
    }
}
