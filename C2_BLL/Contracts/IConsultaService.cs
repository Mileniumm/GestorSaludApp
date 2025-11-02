using System.Linq;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Contracts
{
 public interface IConsultaService
 {
 IQueryable<ConsultaMedica> GetAll();
 ConsultaMedica GetById(int id);
 void Create(ConsultaMedica consulta);
 void Update(ConsultaMedica consulta);
 void Delete(int id);
 }
}