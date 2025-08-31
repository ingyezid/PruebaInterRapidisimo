using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaInterRapidisimo.Models
{
    public class Materia
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int Creditos { get; set; } = 3;

        [Required]
        public Guid ProfesorId { get; set; }
        public virtual Profesor? Profesor { get; set; }

        [JsonIgnore]
        public virtual ICollection<EstudianteMateria>? EstudianteMaterias { get; set; } 

    }
}
