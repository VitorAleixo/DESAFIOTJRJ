using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroTipoVendaRepository
    {
        Task AdicionarAsync(LivroTipoVenda tipoVenda);
        Task<IEnumerable<LivroTipoVendaReturn>> ObterTipoVendaAsync(int CodI);
        Task RemoveAsync(LivroTipoVenda tipoVenda);
    }
}
