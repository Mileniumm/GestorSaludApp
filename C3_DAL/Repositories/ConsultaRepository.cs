using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C3_DAL.Repositories
{
 public class ConsultaRepository : Repository<ConsultaMedica>
 {
 public ConsultaRepository(ApplicationDbContext context) : base(context) { }
 }
}