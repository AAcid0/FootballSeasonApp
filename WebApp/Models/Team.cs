using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe tener exactamente 3 letras.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string TeamCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país es obligatorio.")]
        public string Country { get; set; } = string.Empty;

        [Range(0, 2, ErrorMessage = "Seleccione una categoría válida (0-2).")]
        public int Category { get; set; }

        [Range(1850, 2025, ErrorMessage = "Ingrese un año de fundación válido.")]
        public int FoundationDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser positivo.")]
        public double Budget { get; set; }
    }
}