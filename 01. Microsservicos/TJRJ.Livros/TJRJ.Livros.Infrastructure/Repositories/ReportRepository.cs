using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Domain.Entities;
using TJRJ.Livros.Infrastructure.Context;

namespace TJRJ.Livros.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly LivroDbContext _context;

        public ReportRepository(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<DataSet> ObterRelatorioAsync()
        {
            var livros = await _context.LivrosView.OrderBy(l => l.NomeAutor).ThenBy(l => l.Titulo).ToListAsync();

            var dataSet = new DataSet("LivrosDataSet");
            var dataTable = new DataTable("Livros");

            dataTable.Columns.Add("NomeAutor", typeof(string));
            dataTable.Columns.Add("Titulo", typeof(string));
            dataTable.Columns.Add("Editora", typeof(string));
            dataTable.Columns.Add("AnoPublicacao", typeof(string));
            dataTable.Columns.Add("Edicao", typeof(int));
            dataTable.Columns.Add("Assunto", typeof(string));

            // Preencha o DataTable com os dados
            foreach (var livro in livros)
            {
                var row = dataTable.NewRow();
                row["NomeAutor"] = livro.NomeAutor;
                row["Titulo"] = livro.Titulo;
                row["Editora"] = livro.Editora;
                row["AnoPublicacao"] = livro.AnoPublicacao;
                row["Edicao"] = livro.Edicao;
                row["Assunto"] = livro.Assunto;

                dataTable.Rows.Add(row);
            }

            dataSet.Tables.Add(dataTable);

            return dataSet;
        }

    }
}
