using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterTodosAsync();
        Task<Livro> ObterPorIdAsync(int CodI);
        Task<Livro> AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task RemoverAsync(int CodI);
    }
}
