using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface IAutorUseCase
    {
        Task<IEnumerable<AutorDto>> ObterTodosAsync();
        Task<AutorDto> ObterPorIdAsync(int CodAu);
        Task AdicionarAsync(AutorDto autor);
        Task AtualizarAsync(AutorDto autor);
        Task RemoverAsync(int CodAu);
    }
}
