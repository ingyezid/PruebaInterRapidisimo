using System.ComponentModel.DataAnnotations;

namespace PruebaInterRapidisimo.Models
{
    public class EstudianteMateria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EstudianteId { get; set; }
        public virtual Estudiante? Estudiante { get; set; }

        [Required]
        public int MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
