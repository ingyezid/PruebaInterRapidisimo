using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Services;

namespace PruebaInterRapidisimo.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _profesorService.GetAll();
            return View(result);
        }
    }
}
