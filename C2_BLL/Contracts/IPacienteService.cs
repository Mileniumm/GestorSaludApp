using System.Linq;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Contracts
{
 public interface IPacienteService
 {
 IQueryable<Paciente> GetAll();
 Paciente GetById(int id);
 void Create(Paciente paciente);
 void Update(Paciente paciente);
 void Delete(int id);
 }
}