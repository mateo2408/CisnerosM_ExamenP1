using System;
using System.ComponentModel.DataAnnotations;

public class PlanDeRecompensasModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Los puntos acumulados deben ser positivos.")]
    public int PuntosAcumulados { get; set; }

    [Required]
    public string TipoRecompensa
    {
        get
        {
            return PuntosAcumulados < 500 ? "SILVER" : "GOLD";
        }
    }
}