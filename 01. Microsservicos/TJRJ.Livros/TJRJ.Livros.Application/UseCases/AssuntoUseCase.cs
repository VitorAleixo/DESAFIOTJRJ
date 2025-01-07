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
    public class AssuntoUseCase : IAssuntoUseCase
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoUseCase(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task<AssuntoDto> ObterPorIdAsync(int CodI)
        {
            var assunto = await _assuntoRepository.ObterPorIdAsync(CodI);
            if (assunto == null) return null;

            return new AssuntoDto
            {
                codAs = assunto.codAs,
                Descricao = assunto.Descricao,
            };
        }

        public async Task<IEnumerable<AssuntoDto>> ObterTodosAsync()
        {
            var assuntos = await _assuntoRepository.ObterTodosAsync();
            return assuntos.Select(assunto => new AssuntoDto
            {
                codAs = assunto.codAs,
                Descricao = assunto.Descricao,
            }).ToList();
        }

        public async Task AdicionarAsync(AssuntoDto assuntoDto)
        {
          var assunto = new Assunto
            {
                codAs = assuntoDto.codAs,
                Descricao = assuntoDto.Descricao,
            };
          
            await _assuntoRepository.AdicionarAsync(assunto);
        }

        public async Task AtualizarAsync(AssuntoDto assuntoDto)
        {
            var assunto = await _assuntoRepository.ObterPorIdAsync(assuntoDto.codAs);
            if (assunto == null) return;

            assunto.codAs = assuntoDto.codAs;
            assunto.Descricao = assuntoDto.Descricao;
            await _assuntoRepository.AtualizarAsync(assunto);
        }

        public async Task RemoverAsync(int CodI)
        {
            await _assuntoRepository.RemoverAsync(CodI);
        }
    }
}
