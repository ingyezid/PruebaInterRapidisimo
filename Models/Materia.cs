using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaInterRapidisimo.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int Creditos { get; set; } = 3;

        [Required]
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<EstudianteMateria> EstudianteMaterias { get; set; } = new List<EstudianteMateria>();

    }
}
