using System.Linq;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Contracts
{
 public interface IMedicoService
 {
 IQueryable<Medico> GetAll();
 Medico GetById(int id);
 void Create(Medico medico);
 void Update(Medico medico);
 void Delete(int id);
 }
}