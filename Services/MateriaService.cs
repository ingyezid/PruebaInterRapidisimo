using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;
using System.Drawing.Drawing2D;

namespace PruebaInterRapidisimo.Services
{
    public interface IMateriaService
    {
        List<Materia>? Get();
        Materia? GetById(Guid id);
        Task Save(Materia materia);
        Task Update(Guid id, Materia materia);
        Task Delete(Guid id);
    }

    public class MateriaService : IMateriaService
    {
        private readonly ProjectContext _context;

        public MateriaService(ProjectContext dbContext)
        {
            _context = dbContext;
        }


        public List<Materia>? Get()
        {
            var result = _context.Materias.ToList();

            return result;
        }

        public Materia? GetById(Guid id)
        {
            var result = _context.Materias.Find(id);

            return result;
        }

        public async Task Save(Materia materia)
        {
            _context.Add(materia);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Materia materia)
        {
            var materiaActual = _context.Materias.Find(id);

            if (materiaActual != null)
            {
                materiaActual.Nombre = materia.Nombre;
                materiaActual.ProfesorId = materia.ProfesorId;
                materiaActual.Creditos = materia.Creditos;

                await _context.SaveChangesAsync();
            }
        }


        public async Task Delete(Guid id)
        {
            var materiaActual = _context.Materias.Find(id);

            if (materiaActual != null)
            {
                _context.Remove(materiaActual);

                await _context.SaveChangesAsync();
            }
        }
    }
}
