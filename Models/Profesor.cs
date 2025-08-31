using System.ComponentModel.DataAnnotations;

namespace PruebaInterRapidisimo.Models
{
    public class Profesor
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
    }
}
