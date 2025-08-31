using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static PruebaInterRapidisimo.Enums.UtilEnums;

namespace PruebaInterRapidisimo.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required]
        public ProgramaCreditos ProgramaCreditos { get; set; }

        [JsonIgnore]
        public  virtual ICollection<EstudianteMateria> EstudianteMaterias { get; set; } = new List<EstudianteMateria>();
    }
}
