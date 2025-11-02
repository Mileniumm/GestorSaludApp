using System.Data.Entity;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C3_DAL
{
 public class ApplicationDbContext : DbContext
 {
 public ApplicationDbContext() : base("DefaultConnection") { }
 public DbSet<Paciente> Pacientes { get; set; }
 public DbSet<Medico> Medicos { get; set; }
 public DbSet<ConsultaMedica> Consultas { get; set; }
 }
}