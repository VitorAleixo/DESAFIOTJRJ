using Microsoft.AspNetCore.Mvc;

namespace TJRJ.Usuarios.API.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
