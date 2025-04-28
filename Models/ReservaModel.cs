using System;
using System.ComponentModel.DataAnnotations;

public class ReservaModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "La fecha de entrada es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaEntrada { get; set; }

    [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaSalida { get; set; }

    [Required(ErrorMessage = "El valor a pagar es obligatorio.")]
    [Range(0.0, double.MaxValue, ErrorMessage = "El valor debe ser positivo.")]
    public decimal ValorPagar { get; set; }

    [Required]
    public int ClienteId { get; set; }
    public ClienteModel Cliente { get; set; }
}