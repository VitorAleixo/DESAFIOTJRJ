using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Sub;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroAssuntoUseCase
    {
        Task AdicionarAsync(LivroAssuntoDto livroAssunto);
        Task AtualizarAsync(LivroAssuntoDto livroAssunto);
    }
}
