using System.ComponentModel.DataAnnotations;

namespace GestorSalud.C4_ENTIDAD.Entities
{
 public class Medico
 {
 [Required]
 public int Id { get; set; }
 
 [Required, StringLength(100)]
 public string Nombre { get; set; }
 
 [Required, StringLength(100)]
 public string Apellido { get; set; }
 
 [Required, StringLength(50)]
 public string Matricula { get; set; }
 
 [Required, StringLength(100)]
 public string Especialidad { get; set; }
 
 [EmailAddress]
 public string Email { get; set; }
 }
}