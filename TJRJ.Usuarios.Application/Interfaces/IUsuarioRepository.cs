
using TJRJ.Usuarios.Application.DTOs.Main;
using TJRJ.Usuarios.Domain.Entities;

namespace TJRJ.Usuarios.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario> ObterPorIdAsync(Guid id);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task AdicionarAsync(Usuario aluno);
        Task AtualizarAsync(Usuario aluno);
        Task RemoverAsync(Guid id);
    }
}
