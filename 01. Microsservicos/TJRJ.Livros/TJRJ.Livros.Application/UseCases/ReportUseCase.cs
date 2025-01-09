using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.UseCases
{
    public class ReportUseCase : IReportUseCase
    {
        private readonly IReportRepository _reportRepository;

        public ReportUseCase(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<DataSet> ObterRelatorioAsync()
        {
            return await _reportRepository.ObterRelatorioAsync();
        }
    }
}
