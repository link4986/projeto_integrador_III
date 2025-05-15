using Microsoft.AspNetCore.Mvc;

namespace Ouvidoria.WebApi.Controllers
{
    public class MoradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
