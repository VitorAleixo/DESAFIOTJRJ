using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TJRJ.Usuarios.Application.DTOs.Main;
using TJRJ.Usuarios.Application.Interfaces;
using WorkGoal.Alunos.Application.DTOs.Sub;

namespace TJRJ.Usuarios.API.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioUseCase _usrUseCase;


        public UsuariosController(IUsuarioUseCase usrUseCase)
        {
            _usrUseCase = usrUseCase;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usrUseCase.ObterTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(Guid id)
        {
            var usuario = await _usrUseCase.ObterPorIdAsync(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario([FromBody] UsuarioCreateDto usuarioDto)
        {
            await _usrUseCase.AdicionarAsync(usuarioDto);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateUsuario(Guid id, [FromBody] UsuarioCreateDto usuarioDto)
        {
            usuarioDto.Id = id;
            await _usrUseCase.AtualizarAsync(usuarioDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUsuario(Guid id)
        {
            await _usrUseCase.RemoverAsync(id);
            return NoContent();
        }
    }
}
