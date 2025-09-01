namespace PruebaInterRapidisimo.Models.ViewModels
{
           public class InscripcionViewModel
        {
            public Guid EstudianteId { get; set; }
            public List<Guid> MateriasSeleccionadas { get; set; } = new();
        }
    
}
