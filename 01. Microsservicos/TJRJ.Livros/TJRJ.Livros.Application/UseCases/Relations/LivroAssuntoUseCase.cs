using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.UseCases.Relations
{
    public class LivroAssuntoUseCase : ILivroAssuntoUseCase
    {
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public LivroAssuntoUseCase(ILivroAssuntoRepository livroAssuntoRepository)
        {
            _livroAssuntoRepository = livroAssuntoRepository;
        }
        

        public async Task AdicionarAsync(LivroAssuntoDto livroAssuntoDto)
        {
            var assunto = new LivroAssunto
            {
                Assunto_codAs= livroAssuntoDto.codAs,
                Livro_CodI = livroAssuntoDto.CodI,
            };

            await _livroAssuntoRepository.AdicionarAsync(assunto);
        }

        public async Task RemoveAsync(int CodI)
        {
            await _livroAssuntoRepository.RemoveAsync(CodI);
        }
    }
}
