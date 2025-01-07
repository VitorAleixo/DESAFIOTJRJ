using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.DTOs.Sub;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroTipoVendaUseCase
    {
        Task AdicionarAsync(LivroTipoVendaDto livroTipoVenda);
        Task RemoverAsync(LivroTipoVendaDto livroTipoVenda);
        Task<IEnumerable<LivroTipoVendaDto>> ObterTipoVendaAsync(int CodI);
    }
}
