using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.UseCases
{
    public class TipoVendaUseCase : ITipoVendaUseCase
    {
        private readonly ITipoVendaRepository _tipoVendaRepository;

        public TipoVendaUseCase(ITipoVendaRepository tipoVendaRepository)
        {
            _tipoVendaRepository = tipoVendaRepository;
        }

        public async Task<TipoVendaDto> ObterPorIdAsync(int CodAu)
        {
            var tipoVenda = await _tipoVendaRepository.ObterPorIdAsync(CodAu);
            if (tipoVenda == null) return null;

            return new TipoVendaDto
            {
                TipoVenda_CodI = tipoVenda.TipoVenda_CodI,
                Descricao = tipoVenda.Descricao,
            };
        }

        public async Task<IEnumerable<TipoVendaDto>> ObterTodosAsync()
        {
            var tipoVendaes = await _tipoVendaRepository.ObterTodosAsync();
            return tipoVendaes.Select(tipoVenda => new TipoVendaDto
            {
                TipoVenda_CodI = tipoVenda.TipoVenda_CodI,
                Descricao = tipoVenda.Descricao,
            }).ToList();
        }

        public async Task AdicionarAsync(TipoVendaDto tipoVendaDto)
        {
          var tipoVenda = new TipoVenda
            {
              TipoVenda_CodI = tipoVendaDto.TipoVenda_CodI,
              Descricao = tipoVendaDto.Descricao,
          };
          
            await _tipoVendaRepository.AdicionarAsync(tipoVenda);
        }

        public async Task AtualizarAsync(TipoVendaDto tipoVendaDto)
        {
            var tipoVenda = await _tipoVendaRepository.ObterPorIdAsync(tipoVendaDto.TipoVenda_CodI);
            if (tipoVenda == null) return;

            tipoVenda.TipoVenda_CodI = tipoVendaDto.TipoVenda_CodI;
            tipoVenda.Descricao = tipoVendaDto.Descricao;
            await _tipoVendaRepository.AtualizarAsync(tipoVenda);
        }

        public async Task RemoverAsync(int CodAu)
        {
            await _tipoVendaRepository.RemoverAsync(CodAu);
        }
    }
}
