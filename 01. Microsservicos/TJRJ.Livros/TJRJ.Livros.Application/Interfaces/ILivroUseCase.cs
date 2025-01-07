using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface ILivroUseCase
    {
        Task<IEnumerable<LivroDto>> ObterTodosAsync();
        Task<LivroDto> ObterPorIdAsync(int CodI);
        Task AdicionarAsync(LivroDto livro);
        Task AtualizarAsync(LivroDto livro);
        Task RemoverAsync(int CodI);
    }
}
