using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Livros.Domain.Entities
{
    public class Livro
    {
        public int CodI { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public ICollection<LivroAutor> LivroAutores { get; set; }
        public ICollection<LivroAssunto> LivroAssuntos { get; set; }
        public ICollection<LivroTipoVenda> LivroTipoVendas { get; set; }
    }

    public class Autor
    {
        public int CodAu { get; set; }
        public ICollection<LivroAutor> LivroAutores { get; set; }
        public string Nome { get; set; }
    }

    public class Assunto
    {
        public int codAs { get; set; }
        public ICollection<LivroAssunto> LivroAssuntos { get; set; }
        public string Descricao { get; set; }
    }

    public class TipoVenda
    {
        public int TipoVenda_CodI { get; set; }
        public ICollection<LivroTipoVenda> LivroTipoVendas { get; set; }
        public string Descricao { get; set; }
    }

    public class LivroAutor
    {
        public int Livro_CodI { get; set; }
        public Livro Livro { get; set; }
        public Autor Autor { get; set; }
        public int Autor_CodAu { get; set; }
    }

    public class LivroAssunto
    {
        public int Livro_CodI { get; set; }
        public Livro Livro { get; set; }
        public Assunto Assunto { get; set; }
        public int Assunto_codAs { get; set; }
    }

    public class LivroTipoVenda
    {
        public int Livro_CodI { get; set; }
        public Livro Livro { get; set; }
        public TipoVenda TipoVenda { get; set; }
        public int TipoVenda_CodI { get; set; }
        public double Valor { get; set; }
    }

    public class LivroTipoVendaReturn
    {
        public int Livro_CodI { get; set; }
        public int TipoVenda_CodI { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
