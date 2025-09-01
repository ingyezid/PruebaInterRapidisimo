using PruebaInterRapidisimo.Models.ViewModels;

namespace PruebaInterRapidisimo.Services
{
    public interface IInscripcionService
    {
        Task<(bool Exito, List<string> Errores)> InscribirMateriasAsync(Guid estudianteId, List<Guid> materiasSeleccionadas);
        Task<List<CompañerosViewModel>> ObtenerCompañerosAsync(Guid estudianteId);
    }
}
