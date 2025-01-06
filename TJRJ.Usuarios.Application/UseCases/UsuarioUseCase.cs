using TJRJ.Usuarios.Application.DTOs.Main;
using TJRJ.Usuarios.Application.Interfaces;
using TJRJ.Usuarios.Domain.Entities;
using WorkGoal.Alunos.Application.DTOs.Sub;

namespace TJRJ.Usuarios.Application.UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IJwtRepository _jwtService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioUseCase(
           IUsuarioRepository usuarioRepository,
           IJwtRepository jwtService)
        {
            _jwtService = jwtService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> ObterPorIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                Ativo = usuario.Ativo
            };
        }

        public async Task<IEnumerable<UsuarioDto>> ObterTodosAsync()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();
            return usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                Ativo = usuario.Ativo
            }).ToList();
        }

        public async Task<UsuarioDto> ObterPorEmailAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha)) return null;


            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                DataCadastro = usuario.DataCadastro,
                Ativo = usuario.Ativo
            };
        }

        public async Task AdicionarAsync(UsuarioCreateDto usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email);
            if (usuarioExistente != null && usuarioExistente.Email != usuarioDto.Email)
            {
                throw new InvalidOperationException("Já existe um usuario cadastrado com este email.");
            }

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Telefone = usuarioDto.Telefone,
                DataNascimento = usuarioDto.DataNascimento,
                DataCadastro = DateTime.Now,
                Ativo = usuarioDto.Ativo
            };

            usuario.SetSenha(usuarioDto.Senha);
            await _usuarioRepository.AdicionarAsync(usuario);
        }

        public async Task AtualizarAsync(UsuarioCreateDto usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email);
            if (usuarioExistente != null && usuarioExistente.Email != usuarioDto.Email)
            {
                throw new InvalidOperationException("Já existe um usuario cadastrado com este email.");
            }

            var usuario = await _usuarioRepository.ObterPorIdAsync(usuarioDto.Id);
            if (usuario == null) return;

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Telefone = usuarioDto.Telefone;
            usuario.DataNascimento = usuarioDto.DataNascimento;
            usuario.Ativo = usuarioDto.Ativo;

            usuario.SetSenha(usuarioDto.Senha);
            await _usuarioRepository.AtualizarAsync(usuario);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _usuarioRepository.RemoverAsync(id);
        }
    }
}
