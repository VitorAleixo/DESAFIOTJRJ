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
                codI = tiposVenda.Livro_CodI,
                TipoVenda_CodI = tiposVenda.TipoVenda_CodI,
                Valor = tiposVenda.Valor,
                Descricao = tiposVenda.Descricao
            }).ToList();
        }



        public async Task AdicionarAsync(LivroTipoVendaDto livroTipoVendaDto)
        {
            if (livroTipoVendaDto.Valor <= 0)
            {
                throw new ArgumentException("Informe um valor válido.");
            }
            else if (livroTipoVendaDto.TipoVenda_CodI <= 0)
            {
                throw new ArgumentException("Informe um tipo de venda válido.");
            }
            var tipoVenda = new LivroTipoVenda
            {
                TipoVenda_CodI = livroTipoVendaDto.TipoVenda_CodI,
                Livro_CodI = livroTipoVendaDto.codI,
                Valor = livroTipoVendaDto.Valor,
            };

            var tiposVenda = await _livroTipoVendaRepository.ObterTipoVendaAsync(livroTipoVendaDto.codI);

            foreach(var ITEMS in tiposVenda)
            {
                if(ITEMS.TipoVenda_CodI == livroTipoVendaDto.TipoVenda_CodI)
                {
                    throw new ArgumentException("Já existe esse tipo de venda cadastrado para este livro!");
                }

            }
            
            await _livroTipoVendaRepository.AdicionarAsync(tipoVenda);
        }

        public async Task RemoverAsync(LivroTipoVendaDto livroTipoVendaDto)
        {
            var tipoVenda = new LivroTipoVenda
            {
                TipoVenda_CodI = livroTipoVendaDto.TipoVenda_CodI,
                Livro_CodI = livroTipoVendaDto.codI,
            };

            await _livroTipoVendaRepository.RemoveAsync(tipoVenda);
        }
    }
}
