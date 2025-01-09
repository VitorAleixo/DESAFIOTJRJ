using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> ObterTodosAsync();
        Task<Autor> ObterPorIdAsync(int CodAu);
        Task<List<int>> ObterTodosByLivroAsync(int CodI);
        Task AdicionarAsync(Autor autor);
        Task AtualizarAsync(Autor autor);
        Task RemoverAsync(int CodAu);
    }
}
