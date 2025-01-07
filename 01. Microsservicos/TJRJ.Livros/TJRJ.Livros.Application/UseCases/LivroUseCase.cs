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
    public class LivroUseCase : ILivroUseCase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroUseCase(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroDto> ObterPorIdAsync(int CodI)
        {
            var livro = await _livroRepository.ObterPorIdAsync(CodI);
            if (livro == null) return null;

            return new LivroDto
            {
                CodI = livro.CodI,
                Edicao = livro.Edicao,
                Editora = livro.Editora,
                Titulo = livro.Titulo,
                AnoPublicacao = livro.AnoPublicacao,
            };
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosAsync()
        {
            var livros = await _livroRepository.ObterTodosAsync();
            return livros.Select(livro => new LivroDto
            {
                CodI = livro.CodI,
                Edicao = livro.Edicao,
                Editora = livro.Editora,
                Titulo = livro.Titulo,
                AnoPublicacao = livro.AnoPublicacao,
            }).ToList();
        }

        public async Task AdicionarAsync(LivroDto livroDto)
        {
          var livro = new Livro
            {
                AnoPublicacao = livroDto.AnoPublicacao,
                Edicao = livroDto.Edicao,
                Editora = livroDto.Editora,
                Titulo = livroDto.Titulo,
            };
          
            await _livroRepository.AdicionarAsync(livro);
        }

        public async Task AtualizarAsync(LivroDto livroDto)
        {
            var livro = await _livroRepository.ObterPorIdAsync(livroDto.CodI);
            if (livro == null) return;

            livro.Titulo = livroDto.Titulo;
            livro.Edicao = livroDto.Edicao;
            livro.AnoPublicacao = livroDto.AnoPublicacao;
            livro.Editora = livroDto.Editora;
            await _livroRepository.AtualizarAsync(livro);
        }

        public async Task RemoverAsync(int CodI)
        {
            await _livroRepository.RemoverAsync(CodI);
        }
    }
}
