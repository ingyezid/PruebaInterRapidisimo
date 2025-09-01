using System.ComponentModel.DataAnnotations;

namespace PruebaInterRapidisimo.Enums
{
    public class UtilEnums
    {

        public enum ProgramaCreditos
        {
            [Display(Name = "Ingeniería de Sistemas")]
            IngenieriaSistemas,
            [Display(Name = "Ingeniería Electrónica")]
            IngenieriaElectronica,
            [Display(Name = "Ingeniería Mecatrónica")]
            IngenieriaMecatronica,
            [Display(Name = "Ingeniería Mecánica")]
            IngenieriaMecanica,
            [Display(Name = "Ingeniería Civil")]
            IngenieriaCivil,
            [Display(Name = "Ingeniería Química")]
            IngenieriaQuimica,
            [Display(Name = "Ingeniería Ambiental")]
            IngenieriaAmbiental
        }
    }
}
