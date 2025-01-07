using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces.Relations
{
    public interface ILivroAssuntoRepository
    {
        Task AdicionarAsync(LivroAssunto assunto);
        Task RemoveAsync(int CodI);
    }
}
