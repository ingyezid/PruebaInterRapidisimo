namespace PruebaInterRapidisimo.Models.ViewModels
{
    public class CompañerosViewModel
    {
        public string? Materia { get; set; }
        public string? Profesor { get; set; }
        public List<string> Compañeros { get; set; } = new();
    }

}
