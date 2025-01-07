using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Sub;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroAutorUseCase
    {
        Task AdicionarAsync(LivroAutorDto livroAutor);
        Task RemoveAsync(int CodI);
    }
}
