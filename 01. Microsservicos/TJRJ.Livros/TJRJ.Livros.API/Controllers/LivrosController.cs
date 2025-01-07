﻿using Microsoft.AspNetCore.Authorization;
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
            var Livros = await _livroUseCase.ObterTodosAsync();
            return Ok(Livros);
        }

        [HttpGet("getlivro")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetLivro(int CodI)
        {
            var Livro = await _livroUseCase.ObterPorIdAsync(CodI);
            if (Livro == null) return NotFound();

            return Ok(Livro);
        }

        [HttpPost("createLivro")]
        [Authorize]
        public async Task<ActionResult> CreateLivro([FromBody] LivroCreateDto LivroCreateDto)
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

            foreach (var assuntoId in LivroCreateDto.codAs)
            {
                var livroAssunto = new LivroAssuntoDto
                {
                    codAs = assuntoId,
                    CodI = livroId,
                };
                await _livroAssuntoUseCase.AdicionarAsync(livroAssunto);
            }

            foreach(var autorId in LivroCreateDto.CodAu)
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

        [HttpPut("updateLivro")]
        [Authorize]
        public async Task<ActionResult> UpdateLivro(int CodI, [FromBody] LivroCreateDto LivroCreateDto)
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

            foreach (var assuntoId in LivroCreateDto.codAs)
            {
                var livroAssunto = new LivroAssuntoDto
                {
                    codAs = assuntoId,
                    CodI = CodI,
                };
                await _livroAssuntoUseCase.AdicionarAsync(livroAssunto);
            }

            await _livroAutorUseCase.RemoveAsync(CodI);

            foreach (var autorId in LivroCreateDto.CodAu)
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

        [HttpPost("createTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> createTipoVendaLivro([FromBody] LivroTipoVendaDto LivroTipoVendaDto)
        {
            await _livroTipoVendaUseCase.AdicionarAsync(LivroTipoVendaDto);

            return NoContent();
        }

        [HttpPost("deleteTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> deleteTipoVendaLivro([FromBody] LivroTipoVendaDto LivroTipoVendaDto)
        {
            await _livroTipoVendaUseCase.RemoverAsync(LivroTipoVendaDto);

            return NoContent();
        }

        [HttpPost("getTipoVendaLivro")]
        [Authorize]
        public async Task<ActionResult> getTipoVendaLivro(int CodI)
        {
            var TipoVendasLivro = await _livroTipoVendaUseCase.ObterTipoVendaAsync(CodI);

            return Ok(TipoVendasLivro);
        }

        [HttpPut("deleteLivro")]
        [Authorize]
        public async Task<ActionResult> DeleteLivro(int CodI)
        {
            await _livroUseCase.RemoverAsync(CodI);
            return NoContent();
        }


        [HttpGet("getAllassuntos")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> GetAssuntos()
        {
            var Assuntos = await _assuntoUseCase.ObterTodosAsync();
            return Ok(Assuntos);
        }

        [HttpGet("getassunto")]
        [Authorize]
        public async Task<ActionResult<AssuntoDto>> GetAssunto(int CodI)
        {
            var Assunto = await _assuntoUseCase.ObterPorIdAsync(CodI);
            if (Assunto == null) return NotFound();

            return Ok(Assunto);
        }

        [HttpPost("createAssunto")]
        [Authorize]
        public async Task<ActionResult> CreateAssunto([FromBody] AssuntoDto AssuntoDto)
        {
            await _assuntoUseCase.AdicionarAsync(AssuntoDto);
            return CreatedAtAction(nameof(GetAssunto), new { codAs = AssuntoDto.codAs }, AssuntoDto);
        }

        [HttpPut("updateAssunto")]
        [Authorize]
        public async Task<ActionResult> UpdateAssunto(int codAs, [FromBody] AssuntoDto AssuntoDto)
        {
            AssuntoDto.codAs = codAs;
            await _assuntoUseCase.AtualizarAsync(AssuntoDto);
            return NoContent();
        }

        [HttpPut("deleteAssunto")]
        [Authorize]
        public async Task<ActionResult> DeleteAssunto(int CodA)
        {
            await _assuntoUseCase.RemoverAsync(CodA);
            return NoContent();
        }

        [HttpGet("getAllTipoVenda")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TipoVendaDto>>> GetTipoVendas()
        {
            var TipoVendas = await _tipoVendaUseCase.ObterTodosAsync();
            return Ok(TipoVendas);
        }

        [HttpGet("gettipovenda")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetTipoVenda(int TipoVenda_CodI)
        {
            var TipoVenda = await _tipoVendaUseCase.ObterPorIdAsync(TipoVenda_CodI);
            if (TipoVenda == null) return NotFound();

            return Ok(TipoVenda);
        }

        [HttpPost("createTipoVenda")]
        [Authorize]
        public async Task<ActionResult> CreateTipoVenda([FromBody] TipoVendaDto TipoVendaDto)
        {
            await _tipoVendaUseCase.AdicionarAsync(TipoVendaDto);
            return CreatedAtAction(nameof(GetTipoVenda), new { CodI = TipoVendaDto.TipoVenda_CodI }, TipoVendaDto);
        }

        [HttpPut("updateTipoVenda")]
        [Authorize]
        public async Task<ActionResult> UpdateTipoVenda(int TipoVenda_CodI, [FromBody] TipoVendaDto TipoVendaDto)
        {
            TipoVendaDto.TipoVenda_CodI = TipoVenda_CodI;
            await _tipoVendaUseCase.AtualizarAsync(TipoVendaDto);
            return NoContent();
        }

        [HttpPut("deleteTipoVenda")]
        [Authorize]
        public async Task<ActionResult> DeleteTipoVenda(int TipoVenda_CodI)
        {
            await _tipoVendaUseCase.RemoverAsync(TipoVenda_CodI);
            return NoContent();
        }

        [HttpGet("getAllautor")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            var Autores = await _autorUseCase.ObterTodosAsync();
            return Ok(Autores);
        }

        [HttpGet("getautor")]
        [Authorize]
        public async Task<ActionResult<LivroDto>> GetAutor(int CodAu)
        {
            var Autor = await _autorUseCase.ObterPorIdAsync(CodAu);
            if (Autor == null) return NotFound();

            return Ok(Autor);
        }

        [HttpPost("createAutor")]
        [Authorize]
        public async Task<ActionResult> CreateAutor([FromBody] AutorDto AutorDto)
        {
            await _autorUseCase.AdicionarAsync(AutorDto);
            return CreatedAtAction(nameof(GetLivro), new { CodAu = AutorDto.CodAu }, AutorDto);
        }

        [HttpPut("updateAutor")]
        [Authorize]
        public async Task<ActionResult> UpdateAutor(int CodAu, [FromBody] AutorDto AutorDto)
        {
            AutorDto.CodAu = CodAu;
            await _autorUseCase.AtualizarAsync(AutorDto);
            return NoContent();
        }

        [HttpPut("deleteAutor")]
        [Authorize]
        public async Task<ActionResult> DeleteAutor(int CodAu)
        {
            await _autorUseCase.RemoverAsync(CodAu);
            return NoContent();
        }

    }
}
