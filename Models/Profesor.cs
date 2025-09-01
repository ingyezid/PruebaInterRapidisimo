using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaInterRapidisimo.Models
{
    public class Profesor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Identificacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Apellidos { get; set; }

        [JsonIgnore]
        public virtual ICollection<Materia>? Materias { get; set; } 
    }
}
