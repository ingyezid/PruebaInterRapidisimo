using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IEstudianteService
    {
        List<Estudiante>? Get();
        Estudiante? GetById(Guid id);
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

        public List<Estudiante>? Get()
        {
            var result = _context.Estudiantes.ToList();

            return result;
        }

        public Estudiante? GetById(Guid id)
        {
            var result = _context.Estudiantes.Find(id);

            return result;
        }

        public async Task Save(Estudiante estudiante)
        {
            _context.Add(estudiante);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Estudiante estudiante)
        {
            var estudianteActual = _context.Estudiantes.Find(id);

            if (estudianteActual != null)
            {
                estudianteActual.Identificacion = estudiante.Identificacion;
                estudianteActual.Nombres = estudiante.Nombres;
                estudianteActual.Identificacion = estudiante.Apellidos;
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
