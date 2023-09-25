using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Academico.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Seja bem-vindo as definições de privacidade de nossa instituição!";
            return View();
        }

        public IActionResult Teste()
        {
            ViewData["Message"] = "Esta é a página da view Teste.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}