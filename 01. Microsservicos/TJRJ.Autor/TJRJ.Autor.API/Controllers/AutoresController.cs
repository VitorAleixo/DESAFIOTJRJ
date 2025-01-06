using Microsoft.AspNetCore.Mvc;

namespace TJRJ.Autor.API.Controllers
{
    public class AutoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
