using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Application.Interfaces
{
    public interface IReportUseCase
    {
        Task<DataSet> ObterRelatorioAsync();
    }
}
