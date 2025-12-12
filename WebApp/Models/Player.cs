using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Player
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El número de identificación es obligatorio.")]
    [Range(1, long.MaxValue, ErrorMessage = "Ingrese una identificación válida.")]
    public long DocumentNumber { get; set; }

    [Required(ErrorMessage = "El nombre del futbolista es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe seleccionar un equipo.")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un equipo válido.")]
    public int TeamId { get; set; }

    public Team? Team { get; set; }

    [Required(ErrorMessage = "La edad es obligatoria.")]
    [Range(15, 50, ErrorMessage = "La edad debe estar entre 15 y 50 años.")]
    public int Age { get; set; }

    [Range(0, 2000, ErrorMessage = "Ingrese una cantidad válida de goles.")]
    public int GoalsScored { get; set; }

    [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
    public string Nationality { get; set; } = string.Empty;
    
    [Range(0, 3, ErrorMessage = "Seleccione una posición válida.")]
    public int Position { get; set; }

    public bool IsInjured { get; set; }
}