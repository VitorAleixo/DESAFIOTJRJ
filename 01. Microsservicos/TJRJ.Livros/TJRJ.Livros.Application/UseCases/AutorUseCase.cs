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
    public class AutorUseCase : IAutorUseCase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorUseCase(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorDto> ObterPorIdAsync(int CodAu)
        {
            var autor = await _autorRepository.ObterPorIdAsync(CodAu);
            if (autor == null) return null;

            return new AutorDto
            {
                CodAu = autor.CodAu,
                Nome = autor.Nome,
            };
        }

        public async Task<List<int>> ObterTodosByLivroAsync(int CodI)
        {
            var autores = await _autorRepository.ObterTodosByLivroAsync(CodI);
            return autores;
        }

        public async Task<IEnumerable<AutorDto>> ObterTodosAsync()
        {
            var autores = await _autorRepository.ObterTodosAsync();
            return autores.Select(autor => new AutorDto
            {
                CodAu = autor.CodAu,
                Nome = autor.Nome,
            }).ToList();
        }

        public async Task AdicionarAsync(AutorDto autorDto)
        {
          var autor = new Autor
            {
                CodAu = autorDto.CodAu,
                Nome = autorDto.Nome,
            };
          
            await _autorRepository.AdicionarAsync(autor);
        }

        public async Task AtualizarAsync(AutorDto autorDto)
        {
            var autor = await _autorRepository.ObterPorIdAsync(autorDto.CodAu);
            if (autor == null) return;

            autor.CodAu = autorDto.CodAu;
            autor.Nome = autorDto.Nome;
            await _autorRepository.AtualizarAsync(autor);
        }

        public async Task RemoverAsync(int CodAu)
        {
            await _autorRepository.RemoverAsync(CodAu);
        }
    }
}
