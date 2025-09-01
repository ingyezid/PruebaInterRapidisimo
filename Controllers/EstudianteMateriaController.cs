using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Models;
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


        /// <summary>
        /// Index - Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _estudianteMateriaService.GetAll();
            return View(result);
        }

        /// <summary>
        /// Create - Get
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create - Post
        /// </summary>
        /// <param name="estudianteMateria"> EstudianteMateria </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudianteMateria estudianteMateria)
        {
            if (ModelState.IsValid)
            {
                // Procesa la creación               
                await _estudianteMateriaService.Save(estudianteMateria);

                return RedirectToAction(nameof(Index));
            }
            return View(estudianteMateria);
        }


        /// <summary>
        /// Update - Get
        /// </summary>
        /// <param name="id"> Id EstudianteMateria</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var estudianteMateria = await _estudianteMateriaService.GetById(id.GetValueOrDefault());

            if (estudianteMateria == null)
            {
                return NotFound();
            }

            return View(estudianteMateria);
        }


        /// <summary>
        /// Update - Post
        /// </summary>
        /// <param name="estudianteMateria"> EstudianteMateria </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, EstudianteMateria estudianteMateria)
        {
            if (id != estudianteMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Procesa la actualización               
                await _estudianteMateriaService.Update(id, estudianteMateria);

                return RedirectToAction(nameof(Index));
            }
            return View(estudianteMateria);
        }



        /// <summary>
        /// Delete - Get
        /// </summary>
        /// <param name="id"> Id EstudianteMateria</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _estudianteMateriaService.Delete(id.GetValueOrDefault());

            return RedirectToAction(nameof(Index));
        }
    }
}
