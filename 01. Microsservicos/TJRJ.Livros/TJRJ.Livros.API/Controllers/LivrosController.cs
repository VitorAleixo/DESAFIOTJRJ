using Microsoft.AspNetCore.Mvc;

namespace TJRJ.Livros.API.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
