using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Models;

namespace PruebaInterRapidisimo.Services
{
    public interface IEstudianteMateriaService
    {
        List<EstudianteMateria>? Get();
        EstudianteMateria? GetById(Guid id);
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

        public List<EstudianteMateria>? Get()
        {
            var result = _context.EstudianteMaterias.ToList();

            return result;
        }

        public EstudianteMateria? GetById(Guid id)
        {
            var result = _context.EstudianteMaterias.Find(id);

            return result;
        }

        public async Task Save(EstudianteMateria estudianteMateria)
        {
            _context.Add(estudianteMateria);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, EstudianteMateria estudianteMateria)
        {
            var estudianteMateriaActual = _context.EstudianteMaterias.Find(id);

            if (estudianteMateriaActual != null)
            {
                estudianteMateriaActual.EstudianteId = estudianteMateria.EstudianteId;
                estudianteMateriaActual.MateriaId = estudianteMateria.MateriaId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var estudianteMateriaActual = _context.EstudianteMaterias.Find(id);

            if (estudianteMateriaActual != null)
            {
                _context.Remove(estudianteMateriaActual);

                await _context.SaveChangesAsync();
            }
        }
    }

}
