using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
