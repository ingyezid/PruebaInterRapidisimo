using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Models;
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

        /// <summary>
        /// Index - Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _materiaService.GetAll();
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
        /// <param name="materia"> Materia </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Materia materia)
        {
            if (ModelState.IsValid)
            {
                // Procesa la creación               
                await _materiaService.Save(materia);

                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }


        /// <summary>
        /// Update - Get
        /// </summary>
        /// <param name="id"> Id Materia</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var materia = await _materiaService.GetById(id.GetValueOrDefault());

            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }


        /// <summary>
        /// Update - Post
        /// </summary>
        /// <param name="materia"> Materia </param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Procesa la actualización               
                await _materiaService.Update(id, materia);

                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }



        /// <summary>
        /// Delete - Get
        /// </summary>
        /// <param name="id"> Id Materia</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _materiaService.Delete(id.GetValueOrDefault());

            return RedirectToAction(nameof(Index));
        }

    }
}
