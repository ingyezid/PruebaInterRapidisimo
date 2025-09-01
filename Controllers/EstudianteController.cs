using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaInterRapidisimo.Models;
using PruebaInterRapidisimo.Services;
using System.Diagnostics;

namespace PruebaInterRapidisimo.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        /// <summary>
        /// Index - Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _estudianteService.GetAll();
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
        /// <param name="estudiante"> Estudiante </param>
        /// <returns></returns>
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                // Procesa la creación               
                await _estudianteService.Save(estudiante);

                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }


        /// <summary>
        /// Update - Get
        /// </summary>
        /// <param name="id"> Id Estudiante</param>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var estudiante = await _estudianteService.GetById(id.GetValueOrDefault());

            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }


        /// <summary>
        /// Update - Post
        /// </summary>
        /// <param name="estudiante"> Estudiante </param>
        /// <returns></returns>
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Procesa la actualización               
                await _estudianteService.Update(id, estudiante);

                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }



        /// <summary>
        /// Delete - Get
        /// </summary>
        /// <param name="id"> Id Estudiante</param>
        /// <returns></returns>
      
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _estudianteService.Delete(id.GetValueOrDefault());

            return RedirectToAction(nameof(Index));
        }

        
    }
}
