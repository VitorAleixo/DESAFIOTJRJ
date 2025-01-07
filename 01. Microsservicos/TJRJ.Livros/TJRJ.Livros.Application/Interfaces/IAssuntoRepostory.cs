using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface IAssuntoRepository
    {
        Task<IEnumerable<Assunto>> ObterTodosAsync();
        Task<Assunto> ObterPorIdAsync(int codAs);
        Task AdicionarAsync(Assunto assunto);
        Task AtualizarAsync(Assunto assunto);
        Task RemoverAsync(int codAs);
    }
}
