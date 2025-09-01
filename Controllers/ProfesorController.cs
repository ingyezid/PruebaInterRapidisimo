using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Models;
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

        /// <summary>
        /// Index - Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _profesorService.GetAll();
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
        /// <param name="profesor"> Profesor </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                // Procesa la creación               
                await _profesorService.Save(profesor);

                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }


        /// <summary>
        /// Update - Get
        /// </summary>
        /// <param name="id"> Id Profesor</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var profesor = await _profesorService.GetById(id.GetValueOrDefault());

            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }


        /// <summary>
        /// Update - Post
        /// </summary>
        /// <param name="profesor"> Profesor </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Procesa la actualización               
                await _profesorService.Update(id, profesor);

                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }



        /// <summary>
        /// Delete - Get
        /// </summary>
        /// <param name="id"> Id Profesor</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _profesorService.Delete(id.GetValueOrDefault());

            return RedirectToAction(nameof(Index));
        }
    }
}
