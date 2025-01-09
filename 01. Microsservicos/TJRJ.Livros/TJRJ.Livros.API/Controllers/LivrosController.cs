using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Application.UseCases;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.API.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroUseCase _livroUseCase;
        private readonly IAutorUseCase _autorUseCase;
        private readonly IAssuntoUseCase _assuntoUseCase;
        private readonly ITipoVendaUseCase _tipoVendaUseCase;
        private readonly ILivroAutorUseCase _livroAutorUseCase;
        private readonly ILivroAssuntoUseCase _livroAssuntoUseCase;
        private readonly ILivroTipoVendaUseCase _livroTipoVendaUseCase;

        public LivrosController(ILivroUseCase livroUseCase, IAutorUseCase autorUseCase, IAssuntoUseCase assuntoUseCase, ITipoVendaUseCase tipoVendaUseCase, ILivroAssuntoUseCase livroAssuntoUseCase, ILivroAutorUseCase livroAutorUseCase, ILivroTipoVendaUseCase livroTipoVendaUseCase)
        {
            _livroUseCase = livroUseCase;
            _tipoVendaUseCase = tipoVendaUseCase; 
            _autorUseCase = autorUseCase;
            _assuntoUseCase = assuntoUseCase;

            _livroAutorUseCase = livroAutorUseCase;
            _livroAssuntoUseCase = livroAssuntoUseCase;
            _livroTipoVendaUseCase = livroTipoVendaUseCase;
        }

        [HttpGet("getAlllivros")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            try
            {
                var Livros = await _livroUseCase.ObterTodosAsync();
                return Ok(Livros);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
            
        }

        [HttpGet("getlivro")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetLivro(int CodI)
        {
            try
            {

                var Livro = await _livroUseCase.ObterPorIdAsync(CodI);
                if (Livro == null) return NotFound();

                Livro.autores = await GetAutorByLivro(CodI);
                Livro.assuntos = await GetAssuntoByLivro(CodI);

                return Ok(Livro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPost("createLivro")]
        [Authorize]
        public async Task<ActionResult> CreateLivro([FromBody] LivroCreateDto LivroCreateDto)
        {
            try
            {
                var LivroDto = new LivroDto()
                {
                    Editora = LivroCreateDto.Editora,
                    Edicao = LivroCreateDto.Edicao,
                    AnoPublicacao = LivroCreateDto.AnoPublicacao,
                    Titulo = LivroCreateDto.Titulo
                };
                await _livroUseCase.AdicionarAsync(LivroDto);

                var livroId = LivroDto.CodI;

                foreach (var assuntoId in LivroCreateDto.assuntos)
                {
                    var livroAssunto = new LivroAssuntoDto
                    {
                        codAs = assuntoId,
                        CodI = livroId,
                    };
                    await _livroAssuntoUseCase.AdicionarAsync(livroAssunto);
                }

                foreach (var autorId in LivroCreateDto.autores)
                {
                    var livroAutor = new LivroAutorDto
                    {
                        CodAu = autorId,
                        CodI = livroId,
                    };
                    await _livroAutorUseCase.AdicionarAsync(livroAutor);
                }

                return CreatedAtAction(nameof(GetAssunto), new { CodI = LivroDto.CodI }, LivroCreateDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("updateLivro")]
        [Authorize]
        public async Task<ActionResult> UpdateLivro(int CodI, [FromBody] LivroCreateDto LivroCreateDto)
        {
            try
            {
                var LivroDto = new LivroDto()
                {
                    CodI = CodI,
                    Editora = LivroCreateDto.Editora,
                    Edicao = LivroCreateDto.Edicao,
                    AnoPublicacao = LivroCreateDto.AnoPublicacao,
                    Titulo = LivroCreateDto.Titulo
                };

                await _livroUseCase.AtualizarAsync(LivroDto);

                await _livroAssuntoUseCase.RemoveAsync(CodI);

                foreach (var assuntoId in LivroCreateDto.assuntos)
                {
                    var livroAssunto = new LivroAssuntoDto
                    {
                        codAs = assuntoId,
                        CodI = CodI,
                    };
                    await _livroAssuntoUseCase.AdicionarAsync(livroAssunto);
                }

                await _livroAutorUseCase.RemoveAsync(CodI);

                foreach (var autorId in LivroCreateDto.autores)
                {
                    var livroAutor = new LivroAutorDto
                    {
                        CodAu = autorId,
                        CodI = CodI,
                    };
                    await _livroAutorUseCase.AdicionarAsync(livroAutor);
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPost("createTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> createTipoVendaLivro([FromBody] LivroTipoVendaDto LivroTipoVendaDto)
        {
            try
            {
                await _livroTipoVendaUseCase.AdicionarAsync(LivroTipoVendaDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPost("deleteTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> deleteTipoVendaLivro([FromBody] LivroTipoVendaDto LivroTipoVendaDto)
        {
            try
            {
                await _livroTipoVendaUseCase.RemoverAsync(LivroTipoVendaDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("getTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> getTipoVendaLivro(int CodI)
        {
            try
            {
                var TipoVendasLivro = await _livroTipoVendaUseCase.ObterTipoVendaAsync(CodI);
                return Ok(TipoVendasLivro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("deleteLivro")]
        [Authorize]
        public async Task<ActionResult> DeleteLivro(int CodI)
        {
            try
            {
                await _livroUseCase.RemoverAsync(CodI);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }


        [HttpGet("getAllassuntos")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> GetAssuntos()
        {
            try
            {
                var Assuntos = await _assuntoUseCase.ObterTodosAsync();
                return Ok(Assuntos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }

           
        }

        [HttpGet("getassunto")]
        [Authorize]
        public async Task<ActionResult<AssuntoDto>> GetAssunto(int CodI)
        {
            try
            {
                var Assunto = await _assuntoUseCase.ObterPorIdAsync(CodI);
                if (Assunto == null) return NotFound();

                return Ok(Assunto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }

        }

        [HttpPost("createAssunto")]
        [Authorize]
        public async Task<ActionResult> CreateAssunto([FromBody] AssuntoDto AssuntoDto)
        {
            try
            {
                await _assuntoUseCase.AdicionarAsync(AssuntoDto);
                return CreatedAtAction(nameof(GetAssunto), new { codAs = AssuntoDto.codAs }, AssuntoDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("updateAssunto")]
        [Authorize]
        public async Task<ActionResult> UpdateAssunto(int codAs, [FromBody] AssuntoDto AssuntoDto)
        {
            try
            {
                AssuntoDto.codAs = codAs;
                await _assuntoUseCase.AtualizarAsync(AssuntoDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("deleteAssunto")]
        [Authorize]
        public async Task<ActionResult> DeleteAssunto(int CodA)
        {
            try
            {
                await _assuntoUseCase.RemoverAsync(CodA);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("getAllTipoVenda")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TipoVendaDto>>> GetTipoVendas()
        {
            try
            {
                var TipoVendas = await _tipoVendaUseCase.ObterTodosAsync();
                return Ok(TipoVendas);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("gettipovenda")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetTipoVenda(int TipoVenda_CodI)
        {
            try
            {
                var TipoVenda = await _tipoVendaUseCase.ObterPorIdAsync(TipoVenda_CodI);
                if (TipoVenda == null) return NotFound();

                return Ok(TipoVenda);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPost("createTipoVenda")]
        [Authorize]
        public async Task<ActionResult> CreateTipoVenda([FromBody] TipoVendaDto TipoVendaDto)
        {
            try
            {
                await _tipoVendaUseCase.AdicionarAsync(TipoVendaDto);
                return CreatedAtAction(nameof(GetTipoVenda), new { CodI = TipoVendaDto.TipoVenda_CodI }, TipoVendaDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("updateTipoVenda")]
        [Authorize]
        public async Task<ActionResult> UpdateTipoVenda(int TipoVenda_CodI, [FromBody] TipoVendaDto TipoVendaDto)
        {
            try
            {
                TipoVendaDto.TipoVenda_CodI = TipoVenda_CodI;
                await _tipoVendaUseCase.AtualizarAsync(TipoVendaDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpPut("deleteTipoVenda")]
        [Authorize]
        public async Task<ActionResult> DeleteTipoVenda(int TipoVenda_CodI)
        {
            try
            {
                await _tipoVendaUseCase.RemoverAsync(TipoVenda_CodI);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("getAllautor")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            try
            {
                var Autores = await _autorUseCase.ObterTodosAsync();
                return Ok(Autores);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }

        [HttpGet("getAutorByLivro")]
        [Authorize]
        public async Task<List<int>> GetAutorByLivro(int CodI)
        {
            return await _autorUseCase.ObterTodosByLivroAsync(CodI);
        }

        [HttpGet("getAssuntoByLivro")]
        [Authorize]
        public async Task<List<int>> GetAssuntoByLivro(int CodI)
        {
            return await _assuntoUseCase.ObterTodosByLivroAsync(CodI);
        }

        [HttpGet("getautor")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetAutor(int CodAu)
        {
            try
            {
                var Autor = await _autorUseCase.ObterPorIdAsync(CodAu);
                if (Autor == null) return NotFound();

                return Ok(Autor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
            
        }

        [HttpPost("createAutor")]
        [Authorize]
        public async Task<ActionResult> CreateAutor([FromBody] AutorDto AutorDto)
        {
            try
            {
                await _autorUseCase.AdicionarAsync(AutorDto);
                return CreatedAtAction(nameof(GetLivro), new { CodAu = AutorDto.CodAu }, AutorDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
            
        }

        [HttpPut("updateAutor")]
        [Authorize]
        public async Task<ActionResult> UpdateAutor(int CodAu, [FromBody] AutorDto AutorDto)
        {
            try
            {
                AutorDto.CodAu = CodAu;
                await _autorUseCase.AtualizarAsync(AutorDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
           
        }

        [HttpPut("deleteAutor")]
        [Authorize]
        public async Task<ActionResult> DeleteAutor(int CodAu)
        {
            try
            {
                await _autorUseCase.RemoverAsync(CodAu);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
            
        }

    }
}
