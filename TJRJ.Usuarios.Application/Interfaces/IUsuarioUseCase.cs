using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Usuarios.Application.DTOs.Main;
using WorkGoal.Alunos.Application.DTOs.Sub;

namespace TJRJ.Usuarios.Application.Interfaces
{
    public interface IUsuarioUseCase
    {
        Task<IEnumerable<UsuarioDto>> ObterTodosAsync();
        Task<UsuarioDto> ObterPorIdAsync(Guid id);
        Task<UsuarioDto> ObterPorEmailAsync(string email, string senha);
        Task AdicionarAsync(UsuarioCreateDto aluno);
        Task AtualizarAsync(UsuarioCreateDto aluno);
        Task RemoverAsync(Guid id);
    }
}
