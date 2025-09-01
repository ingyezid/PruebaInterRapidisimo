using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models.ViewModels;
using PruebaInterRapidisimo.Services;

namespace PruebaInterRapidisimo.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly ProjectContext _context;
        private readonly IInscripcionService _inscripcionService;

        public InscripcionesController(ProjectContext context, IInscripcionService inscripcionService)
        {
            _context = context;
            _inscripcionService = inscripcionService;
        }

        // GET: Inscripciones/Create/5
        [HttpGet]
        [Route("Inscripciones/Create/{estudianteId}")]
        public IActionResult Create(Guid estudianteId)
        {
            var materias = _context.Materias
                .Include(m => m.Profesor)
                .ToList();

            var vm = new InscripcionViewModel
            {
                EstudianteId = estudianteId
            };

            ViewBag.Materias = materias;
            return View(vm);
        }

        // POST: Inscripciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InscripcionViewModel model)
        {
            var (exito, errores) = await _inscripcionService.InscribirMateriasAsync(model.EstudianteId, model.MateriasSeleccionadas);

            if (!exito)
            {
                foreach (var error in errores)
                {
                    ModelState.AddModelError("", error);
                }

                ViewBag.Materias = _context.Materias.Include(m => m.Profesor).ToList();
                return View(model);
            }

            return RedirectToAction("Details", "Estudiante", new { id = model.EstudianteId });
        }

        // GET: Inscripciones/Compañeros/5
        [HttpGet]
        public async Task<IActionResult> Compañeros(Guid estudianteId)
        {
            var resultado = await _inscripcionService.ObtenerCompañerosAsync(estudianteId);
            ViewBag.EstudianteId = estudianteId;
            return View(resultado);
        }

        // POST: Inscripciones/EliminarInscripciones
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarInscripciones(Guid estudianteId)
        {
            var (exito, mensaje) = await _inscripcionService.EliminarInscripcionesAsync(estudianteId);
            TempData["Mensaje"] = mensaje;

            return RedirectToAction("Details", "Estudiante", new { id = estudianteId });
        }

    }
}
