using System.ComponentModel.DataAnnotations;

namespace PruebaInterRapidisimo.Models
{
    public class EstudianteMateria
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EstudianteId { get; set; }
        public virtual Estudiante? Estudiante { get; set; }

        [Required]
        public Guid MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
