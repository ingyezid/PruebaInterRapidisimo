using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IMateriaService
    {
        Task<List<Materia>?> GetAll();
        Task<Materia?> GetById(Guid id);
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


        public async Task<List<Materia>?> GetAll()
        {
            try
            {
                var result = await _context.Materias.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de materias", ex);
            }
        }

        public async Task<Materia?> GetById(Guid id)
        {
            try
            {
                var result = await _context.Materias.FindAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la materia por ID", ex);
            }
        }

        public async Task Save(Materia materia)
        {
            try
            {
                materia.Id = Guid.NewGuid();

                _context.Add(materia);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la materia", ex);
            }
        }

        public async Task Update(Guid id, Materia materia)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la materia", ex);
            }
        }


        public async Task Delete(Guid id)
        {
            try
            {
                var materiaActual = _context.Materias.Find(id);

                if (materiaActual != null)
                {
                    _context.Remove(materiaActual);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la materia", ex);
            }
        }
    }
}