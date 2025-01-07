using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroAutorRepository
    {
        Task AdicionarAsync(LivroAutor autor);
        Task AtualizarAsync(LivroAutor autor);
    }
}
