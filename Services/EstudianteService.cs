using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IEstudianteService
    {
        Task<List<Estudiante>?> GetAll();
        Task<Estudiante?> GetById(Guid id);
        Task Save(Estudiante estudiante);
        Task Update(Guid id, Estudiante estudiante);
        Task Delete(Guid id);
    }

    public class EstudianteService : IEstudianteService
    {
        private readonly ProjectContext _context;

        public EstudianteService(ProjectContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Estudiante>?> GetAll()
        {
            try
            {
                var result = await _context.Estudiantes.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de estudiantes", ex);
            }
        }

        public async Task<Estudiante?> GetById(Guid id)
        {
            try
            {
                var result = await _context.Estudiantes.FindAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estudiante por ID", ex);
            }
        }

        public async Task Save(Estudiante estudiante)
        {
            try
            {
                estudiante.Id = Guid.NewGuid();

                _context.Add(estudiante);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar el estudiante", ex);
            }
        }

        public async Task Update(Guid id, Estudiante estudiante)
        {
            try
            {
                var estudianteActual = _context.Estudiantes.Find(id);

                if (estudianteActual != null)
                {
                    estudianteActual.Identificacion = estudiante.Identificacion;
                    estudianteActual.Nombres = estudiante.Nombres;
                    estudianteActual.Apellidos = estudiante.Apellidos;
                    estudianteActual.ProgramaCreditos = estudiante.ProgramaCreditos;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estudiante", ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var estudianteActual = _context.Estudiantes.Find(id);

                if (estudianteActual != null)
                {
                    _context.Remove(estudianteActual);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el estudiante", ex);
            }
        }
    }
}
