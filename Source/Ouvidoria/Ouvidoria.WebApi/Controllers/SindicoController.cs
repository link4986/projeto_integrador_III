using Microsoft.AspNetCore.Mvc;

namespace Ouvidoria.WebApi.Controllers
{
    public class SindicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
