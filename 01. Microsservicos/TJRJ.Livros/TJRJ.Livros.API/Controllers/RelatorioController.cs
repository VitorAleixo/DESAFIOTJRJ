using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TJRJ.Livros.Application.DTOs.Main;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Application.UseCases;
using TJRJ.Livros.Domain.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Reporting.NETCore;
using System.IO;

namespace TJRJ.Livros.API.Controllers
{

    public class RelatorioController : Controller
    {
        private readonly IReportUseCase _reportUseCase;

        public RelatorioController(IReportUseCase reportUseCase)
        {
            _reportUseCase = reportUseCase;
        }

        [HttpGet("relatorioLivros")]
        [Authorize]
        public async Task<IActionResult> GerarRelatorioLivros()
        {

            // Caminho do arquivo RDLC
            string caminhoArquivoRdlc = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "_rptLivros.rdlc");

            LocalReport lr = new LocalReport();
            lr.ReportPath = caminhoArquivoRdlc;

            var dataSet = await _reportUseCase.ObterRelatorioAsync();

            ReportDataSource rd = new ReportDataSource("DataSet1", dataSet.Tables[0]);

            lr.DataSources.Add(rd);

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                " <OutputFormat>PDF</OutputFormat>" +
                " <PageWidht>21cm</PageWidht>" +
                " <PageHeight>29,7cm</PageHeight>" +
                " <MarginTop>0cm</MarginTop>" +
                " <MarginLeft>0cm</MarginLeft>" +
                " <MarginRight>0cm</MarginRight>" +
                " <MarginBottom>0cm</MarginBottom>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType, "RelatorioLivros.pdf");
        }
    }
}
