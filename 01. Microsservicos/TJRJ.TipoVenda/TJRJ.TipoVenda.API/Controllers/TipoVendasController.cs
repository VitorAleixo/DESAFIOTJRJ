using Microsoft.AspNetCore.Mvc;

namespace TJRJ.TipoVenda.API.Controllers
{
    public class TipoVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
