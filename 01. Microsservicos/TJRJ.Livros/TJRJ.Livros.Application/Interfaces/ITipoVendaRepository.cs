﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface ITipoVendaRepository
    {
        Task<IEnumerable<TipoVenda>> ObterTodosAsync();
        Task<TipoVenda> ObterPorIdAsync(int TipoVenda_CodI);
        Task AdicionarAsync(TipoVenda tipoVenda);
        Task AtualizarAsync(TipoVenda tipoVenda);
        Task RemoverAsync(int TipoVenda_CodI);
    }
}