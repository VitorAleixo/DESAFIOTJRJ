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
    public class LivroAutorUseCase : ILivroAutorUseCase
    {
        private readonly ILivroAutorRepository _livroAutorRepository;

        public LivroAutorUseCase(ILivroAutorRepository livroAutorRepository)
        {
            _livroAutorRepository = livroAutorRepository;
        }

        public async Task AdicionarAsync(LivroAutorDto livroAutorDto)
        {
            var autor = new LivroAutor
            {
                Autor_CodAu = livroAutorDto.CodAu,
                Livro_CodI = livroAutorDto.CodI,
            };

            await _livroAutorRepository.AdicionarAsync(autor);
        }

        public async Task RemoveAsync(int CodI)
        {
            await _livroAutorRepository.RemoveAsync(CodI);
        }
    }
}
