using System;
using System.Linq;
using GestorSalud.C2_BLL.Contracts;
using GestorSalud.C3_DAL;
using GestorSalud.C3_DAL.Repositories;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Services
{
 public class ConsultaService : IConsultaService
 {
 private readonly ApplicationDbContext _context;
 private readonly ConsultaRepository _repo;

 public ConsultaService()
 {
 _context = new ApplicationDbContext();
 _repo = new ConsultaRepository(_context);
 }

 public IQueryable<ConsultaMedica> GetAll() => _repo.GetAll();
 public ConsultaMedica GetById(int id) => _repo.GetById(id);
 public void Create(ConsultaMedica consulta)
 {
 if (consulta == null) throw new ArgumentNullException(nameof(consulta));
 if (consulta.Fecha == default(DateTime)) throw new ArgumentException("Fecha requerida");
 _repo.Add(consulta);
 _repo.SaveChanges();
 }
 public void Update(ConsultaMedica consulta)
 {
 if (consulta == null) throw new ArgumentNullException(nameof(consulta));
 _repo.Update(consulta);
 _repo.SaveChanges();
 }
 public void Delete(int id)
 {
 var entity = _repo.GetById(id);
 if (entity == null) return;
 _repo.Remove(entity);
 _repo.SaveChanges();
 }
 }
}