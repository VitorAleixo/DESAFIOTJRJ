using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Livros.Application.DTOs.Main
{
    public class LivroCreateDto
    {
        public int CodI { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }


        //Campos para cadastro
        public List<int> autores { get; set; }
        public List<int> assuntos { get; set; }
        //public List<int> TipoVenda_CodI { get; set; }
        //public double Valor { get; set; }

    }
}
