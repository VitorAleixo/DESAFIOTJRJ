using Microsoft.AspNetCore.Mvc;

namespace TJRJ.Assunto.API.Controllers
{
    public class AssuntosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
