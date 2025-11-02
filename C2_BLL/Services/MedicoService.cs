using System;
using System.Linq;
using GestorSalud.C2_BLL.Contracts;
using GestorSalud.C3_DAL;
using GestorSalud.C3_DAL.Repositories;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Services
{
 public class MedicoService : IMedicoService
 {
 private readonly ApplicationDbContext _context;
 private readonly MedicoRepository _repo;

 public MedicoService()
 {
 _context = new ApplicationDbContext();
 _repo = new MedicoRepository(_context);
 }

 public IQueryable<Medico> GetAll() => _repo.GetAll();
 public Medico GetById(int id) => _repo.GetById(id);
 public void Create(Medico medico)
 {
 if (medico == null) throw new ArgumentNullException(nameof(medico));
 if (string.IsNullOrWhiteSpace(medico.Matricula)) throw new ArgumentException("Matrícula requerida");
 _repo.Add(medico);
 _repo.SaveChanges();
 }
 public void Update(Medico medico)
 {
 if (medico == null) throw new ArgumentNullException(nameof(medico));
 _repo.Update(medico);
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