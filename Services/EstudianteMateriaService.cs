using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IEstudianteMateriaService
    {
        Task<List<EstudianteMateria>?> GetAll();
        Task<EstudianteMateria?> GetById(Guid id);
        Task Save(EstudianteMateria estudianteMateria);
        Task Update(Guid id, EstudianteMateria estudianteMateria);
        Task Delete(Guid id);
    }

    public class EstudianteMateriaService : IEstudianteMateriaService
    {
        private readonly ProjectContext _context;

        public EstudianteMateriaService(ProjectContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<EstudianteMateria>?> GetAll()
        {
            try
            {
                var result = await _context.EstudianteMaterias.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de estudiante-materia", ex);
            }
        }

        public async Task<EstudianteMateria?> GetById(Guid id)
        {
            try
            {
                var result = await _context.EstudianteMaterias.FindAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estudiante-materia por ID", ex);
            }
        }

        public async Task Save(EstudianteMateria estudianteMateria)
        {
            try
            {
                estudianteMateria.Id = Guid.NewGuid();

                _context.Add(estudianteMateria);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el estudiante-materia", ex);
            }
        }

        public async Task Update(Guid id, EstudianteMateria estudianteMateria)
        {
            try
            {
                var estudianteMateriaActual = _context.EstudianteMaterias.Find(id);

                if (estudianteMateriaActual != null)
                {
                    estudianteMateriaActual.EstudianteId = estudianteMateria.EstudianteId;
                    estudianteMateriaActual.MateriaId = estudianteMateria.MateriaId;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estudiante-materia", ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var estudianteMateriaActual = _context.EstudianteMaterias.Find(id);

                if (estudianteMateriaActual != null)
                {
                    _context.Remove(estudianteMateriaActual);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el estudiante-materia", ex);
            }
        }
    }

}
