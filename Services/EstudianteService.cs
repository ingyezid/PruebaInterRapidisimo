using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;
using System.Linq.Expressions;

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
            var result = await _context.Estudiantes.ToListAsync();

            return result;
        }

        public async Task<Estudiante?> GetById(Guid id)
        {
            var result = await _context.Estudiantes.FindAsync(id);

            return result;
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

        public async Task Delete(Guid id)
        {
            var estudianteActual = _context.Estudiantes.Find(id);

            if (estudianteActual != null)
            {
                _context.Remove(estudianteActual);

                await _context.SaveChangesAsync();
            }
        }
    }
}
