using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface ITipoVendaUseCase
    {
        Task<IEnumerable<TipoVendaDto>> ObterTodosAsync();
        Task<TipoVendaDto> ObterPorIdAsync(int TipoVenda_CodI);
        Task AdicionarAsync(TipoVendaDto tipoVenda);
        Task AtualizarAsync(TipoVendaDto tipoVenda);
        Task RemoverAsync(int TipoVenda_CodI);
    }
}
