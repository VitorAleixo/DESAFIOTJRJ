using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.DTOs.Sub
{
    public class LivroTipoVendaDto
    {
        public int TipoVenda_CodI { get; set; }
        public int codI { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
