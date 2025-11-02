using System;
using System.ComponentModel.DataAnnotations;

namespace GestorSalud.C4_ENTIDAD.Entities
{
 public class ConsultaMedica
 {
 [Required]
 public int Id { get; set; }
 
 [Required]
 public int PacienteId { get; set; }
 
 [Required]
 public int MedicoId { get; set; }
 
 [Required]
 public DateTime Fecha { get; set; }
 
 [StringLength(250)]
 public string Motivo { get; set; }
 
 [StringLength(1000)]
 public string Observaciones { get; set; }
 }
}