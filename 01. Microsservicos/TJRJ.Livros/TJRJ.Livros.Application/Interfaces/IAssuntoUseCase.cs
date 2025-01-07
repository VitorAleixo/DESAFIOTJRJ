using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface IAssuntoUseCase
    {
        Task<IEnumerable<AssuntoDto>> ObterTodosAsync();
        Task<AssuntoDto> ObterPorIdAsync(int assunto);
        Task AdicionarAsync(AssuntoDto assunto);
        Task AtualizarAsync(AssuntoDto assunto);
        Task RemoverAsync(int assunto);
    }
}
