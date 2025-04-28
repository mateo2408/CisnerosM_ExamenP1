using System;
using System.ComponentModel.DataAnnotations;

public class ClienteModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string Nombre { get; set; }

    [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100 años.")]
    public int Edad { get; set; }

    [Required(ErrorMessage = "El saldo es obligatorio.")]
    [Range(0.0, double.MaxValue, ErrorMessage = "El saldo debe ser un valor positivo.")]
    public decimal Saldo { get; set; }

    public bool EsActivo { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
    public DateTime FechaRegistro { get; set; }
}