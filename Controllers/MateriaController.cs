using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Services;

namespace PruebaInterRapidisimo.Controllers
{
    public class MateriaController : Controller
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _materiaService.GetAll();
            return View(result);
        }
    }
}
