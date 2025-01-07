using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.UseCases.Relations
{
    public class LivroTipoVendaUseCase : ILivroTipoVendaUseCase
    {
        private readonly ILivroTipoVendaRepository _livroTipoVendaRepository;

        public LivroTipoVendaUseCase(ILivroTipoVendaRepository livroTipoVendaRepository)
        {
            _livroTipoVendaRepository = livroTipoVendaRepository;
        }


        public async Task<IEnumerable<LivroTipoVendaDto>> ObterTipoVendaAsync(int CodI)
        {
            var tiposVenda = await _livroTipoVendaRepository.ObterTipoVendaAsync(CodI);

            return tiposVenda.Select(tiposVenda => new LivroTipoVendaDto
            {
                CodI = tiposVenda.Livro_CodI,
                TipoVenda_CodI = tiposVenda.TipoVenda_CodI,
                Valor = tiposVenda.Valor,
            }).ToList();
        }



        public async Task AdicionarAsync(LivroTipoVendaDto livroTipoVendaDto)
        {
            var tipoVenda = new LivroTipoVenda
            {
                TipoVenda_CodI = livroTipoVendaDto.TipoVenda_CodI,
                Livro_CodI = livroTipoVendaDto.CodI,
                Valor = livroTipoVendaDto.Valor
            };

            await _livroTipoVendaRepository.AdicionarAsync(tipoVenda);
        }

        public async Task RemoverAsync(LivroTipoVendaDto livroTipoVendaDto)
        {
            var tipoVenda = new LivroTipoVenda
            {
                TipoVenda_CodI = livroTipoVendaDto.TipoVenda_CodI,
                Livro_CodI = livroTipoVendaDto.CodI,
            };

            await _livroTipoVendaRepository.RemoveAsync(tipoVenda);
        }
    }
}
