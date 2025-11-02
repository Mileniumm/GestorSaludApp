using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C3_DAL.Repositories
{
 public class MedicoRepository : Repository<Medico>
 {
 public MedicoRepository(ApplicationDbContext context) : base(context) { }
 }
}