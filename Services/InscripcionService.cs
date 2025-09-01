using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;
using PruebaInterRapidisimo.Models.ViewModels;

namespace PruebaInterRapidisimo.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly ProjectContext _context;

        public InscripcionService(ProjectContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(bool Exito, List<string> Errores)> InscribirMateriasAsync(Guid estudianteId, List<Guid> materiasSeleccionadas)
        {
            try
            {
                var errores = new List<string>();

                // Validación 1: exactamente 3 materias
                if (materiasSeleccionadas.Count != 3)
                {
                    errores.Add("Debes seleccionar exactamente 3 materias.");
                }

                // Validación 2: profesores distintos
                var materias = await _context.Materias!
                    .Where(m => materiasSeleccionadas.Contains(m.Id))
                    .Include(m => m.Profesor)
                    .ToListAsync();

                if (materias.Select(m => m.ProfesorId).Distinct().Count() != materias.Count)
                {
                    errores.Add("Las materias deben ser de profesores distintos.");
                }

                // Validación 3: no tener inscripciones previas
                var materiasPrevias = await _context.EstudianteMaterias!
                    .Where(em => em.EstudianteId == estudianteId)
                    .CountAsync();

                if (materiasPrevias > 0)
                {
                    errores.Add("El estudiante ya tiene materias registradas.");
                }

                if (errores.Any())
                    return (false, errores);

                // Guardar inscripciones
                foreach (var materiaId in materiasSeleccionadas)
                {
                    var inscripcion = new EstudianteMateria
                    {
                        EstudianteId = estudianteId,
                        MateriaId = materiaId
                    };
                    _context.Add(inscripcion);
                }

                await _context.SaveChangesAsync();
                return (true, errores);
            }
            catch (Exception ex)
            {
                return (false, new List<string> { "Ocurrió un error al inscribir las materias: " + ex.Message });
            }
        }

        public async Task<List<CompañerosViewModel>> ObtenerCompañerosAsync(Guid estudianteId)
        {
            try
            {
                var materias = await _context.EstudianteMaterias
                    .Where(em => em.EstudianteId == estudianteId)
                    .Include(em => em.Materia)
                        .ThenInclude(m => m!.Profesor)
                    .Include(em => em.Materia)
                        .ThenInclude(m => m!.EstudianteMaterias!)
                            .ThenInclude(em => em.Estudiante)
                    .ToListAsync();

                return materias.Select(em => new CompañerosViewModel
                {
                    Materia = em.Materia?.Nombre ?? string.Empty,
                    Profesor = ((em.Materia?.Profesor?.Nombres ?? string.Empty) + " " + (em.Materia?.Profesor?.Apellidos ?? string.Empty)).Trim(),
                    Compañeros = em.Materia?.EstudianteMaterias?
                        .Where(x => x.EstudianteId != estudianteId && x.Estudiante != null)
                        .Select(x => ((x.Estudiante!.Nombres ?? string.Empty) + " " + (x.Estudiante!.Apellidos ?? string.Empty)).Trim())
                        .ToList() ?? new List<string>()
                }).ToList();
            }
            catch (Exception)
            {
                return new List<CompañerosViewModel>();
            }
        }

        public async Task<(bool Exito, string Mensaje)> EliminarInscripcionesAsync(Guid estudianteId)
        {
            try
            {
                var inscripciones = _context.EstudianteMaterias
                    .Where(em => em.EstudianteId == estudianteId);

                if (!inscripciones.Any())
                {
                    return (false, "El estudiante no tiene materias inscritas.");
                }

                _context.EstudianteMaterias.RemoveRange(inscripciones);
                await _context.SaveChangesAsync();

                return (true, "Se eliminaron todas las materias inscritas correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Ocurrió un error al eliminar las inscripciones: " + ex.Message);
            }
        }
    }
}