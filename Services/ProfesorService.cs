using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IProfesorService
    {
        List<Profesor>? Get();
        Profesor? GetById(Guid id);
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

        public List<Profesor>? Get()
        {
            var result = _context.Profesores.ToList();

            return result;
        }

        public Profesor? GetById(Guid id)
        {
            var result = _context.Profesores.Find(id);

            return result;
        }

        public async Task Save(Profesor profesor)
        {
            _context.Add(profesor);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Profesor profesor)
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

        public async Task Delete (Guid id)
        {
            var profesorActual = _context.Profesores.Find(id);

            if (profesorActual != null)
            {
                _context.Remove(profesorActual);

                await _context.SaveChangesAsync();

            }
        }
    }
}
