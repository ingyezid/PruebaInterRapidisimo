using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Services;

namespace PruebaInterRapidisimo.Controllers
{
    public class EstudianteMateriaController : Controller
    {
        private readonly IEstudianteMateriaService _estudianteMateriaService;

        public EstudianteMateriaController(IEstudianteMateriaService estudianteMateriaService)
        {
            _estudianteMateriaService = estudianteMateriaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _estudianteMateriaService.GetAll();
            return View(result);
        }
    }
}
