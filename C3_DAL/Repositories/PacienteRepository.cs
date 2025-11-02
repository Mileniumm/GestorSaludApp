using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C3_DAL.Repositories
{
 public class PacienteRepository : Repository<Paciente>
 {
 public PacienteRepository(ApplicationDbContext context) : base(context) { }
 }
}