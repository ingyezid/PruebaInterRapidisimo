using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IProfesorService
    {
        Task<List<Profesor>?> GetAll();
        Task<Profesor?> GetById(Guid id);
        Task Save(Profesor profesor);
        Task Update(Guid id, Profesor profesor);
        Task Delete(Guid id);
    }

    public class ProfesorService : IProfesorService
    {
        private readonly ProjectContext _context;

        public ProfesorService(ProjectContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Profesor>?> GetAll()
        {
            try
            {
                var result = await _context.Profesores.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de profesores", ex);
            }
        }

        public async Task<Profesor?> GetById(Guid id)
        {
            try
            {
                var result = await _context.Profesores.FindAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el profesor por ID", ex);
            }
        }

        public async Task Save(Profesor profesor)
        {
            try
            {
                profesor.Id = Guid.NewGuid();

                _context.Add(profesor);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el profesor", ex);
            }
        }

        public async Task Update(Guid id, Profesor profesor)
        {
            try
            {
                var profesorActual = _context.Profesores.Find(id);

                if (profesorActual != null)
                {
                    profesorActual.Identificacion = profesor.Identificacion;
                    profesorActual.Nombres = profesor.Nombres;
                    profesorActual.Apellidos = profesor.Apellidos;

                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el profesor", ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var profesorActual = _context.Profesores.Find(id);

                if (profesorActual != null)
                {
                    _context.Remove(profesorActual);

                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el profesor", ex);
            }
        }
    }
}
