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

        public async Task<IEnumerable<LivroTipoVendaReturn>> ObterTipoVendaAsync(int CodI)
        {
            var query = from livroTipoVenda in _context.LivroTipoVenda
                        join tipoVenda in _context.TipoVenda on livroTipoVenda.TipoVenda_CodI equals tipoVenda.TipoVenda_CodI
                        where livroTipoVenda.Livro_CodI == CodI
                        select new LivroTipoVendaReturn
                        {
                            Livro_CodI = livroTipoVenda.Livro_CodI,
                            TipoVenda_CodI = livroTipoVenda.TipoVenda_CodI,
                            Valor = livroTipoVenda.Valor,
                            Descricao = tipoVenda.Descricao // Adicionando a descrição do tipo de venda
                        };

            return await query.ToListAsync();

            //return await _context.LivroTipoVenda.Where(la => la.Livro_CodI == CodI).ToListAsync();
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
