using Microsoft.AspNetCore.Mvc;

namespace LavanderiaVJWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
