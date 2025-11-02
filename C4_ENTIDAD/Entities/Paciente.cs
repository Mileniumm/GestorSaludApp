using System;
using System.ComponentModel.DataAnnotations;

namespace GestorSalud.C4_ENTIDAD.Entities
{
 public class Paciente
 {
 [Required]
 public int Id { get; set; }

 [Required]
 [StringLength(100)]
 public string Nombre { get; set; }

 [Required]
 [StringLength(100)]
 public string Apellido { get; set; }

 [Required]
 [EmailAddress]
 public string Email { get; set; }

 [Required]
 [DataType(DataType.Date)]
 public DateTime FechaNacimiento { get; set; }

 [Required]
 public string Genero { get; set; }
 }
}