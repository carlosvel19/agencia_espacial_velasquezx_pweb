using System.ComponentModel.DataAnnotations;

namespace AgenciaEspacialVelasquezX.Models;

public class Astronauta
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Display(Name = "Nombre completo")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La edad es obligatoria")]
    [Range(18, 65, ErrorMessage = "La edad debe estar entre 18 y 65 años")]
    public int Edad { get; set; }

    [Required(ErrorMessage = "Seleccione una especialidad")]
    public string Especialidad { get; set; } = string.Empty;

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}