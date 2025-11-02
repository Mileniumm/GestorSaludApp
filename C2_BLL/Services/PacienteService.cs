using System;
using System.Linq;
using System.ComponentModel; 
using GestorSalud.C2_BLL.Contracts;
using GestorSalud.C3_DAL;
using GestorSalud.C3_DAL.Repositories;
using GestorSalud.C4_ENTIDAD.Entities;

namespace GestorSalud.C2_BLL.Services
{
 [DataObject]
 public class PacienteService : IPacienteService
 {
 private readonly ApplicationDbContext _context;
 private readonly PacienteRepository _repo;

 public PacienteService()
 {
 _context = new ApplicationDbContext();
 _repo = new PacienteRepository(_context);
 }

 [DataObjectMethod(DataObjectMethodType.Select)]
 public IQueryable<Paciente> GetAll() => _repo.GetAll();
 public Paciente GetById(int id) => _repo.GetById(id);

 // Paginación y conteo para ObjectDataSource
 [DataObjectMethod(DataObjectMethodType.Select, true)]
 public IQueryable<Paciente> GetPaged(int startRowIndex, int maximumRows, string sortExpression)
 {
 var query = _repo.GetAll();
 if (string.IsNullOrEmpty(sortExpression))
 {
 query = query.OrderBy(p => p.Id);
 }
 else
 {
 switch (sortExpression)
 {
 case "Id": query = query.OrderBy(p => p.Id); break;
 case "Id DESC": query = query.OrderByDescending(p => p.Id); break;
 case "Nombre": query = query.OrderBy(p => p.Nombre); break;
 case "Nombre DESC": query = query.OrderByDescending(p => p.Nombre); break;
 case "Apellido": query = query.OrderBy(p => p.Apellido); break;
 case "Apellido DESC": query = query.OrderByDescending(p => p.Apellido); break;
 case "Email": query = query.OrderBy(p => p.Email); break;
 case "Email DESC": query = query.OrderByDescending(p => p.Email); break;
 case "FechaNacimiento": query = query.OrderBy(p => p.FechaNacimiento); break;
 case "FechaNacimiento DESC": query = query.OrderByDescending(p => p.FechaNacimiento); break;
 case "Genero": query = query.OrderBy(p => p.Genero); break;
 case "Genero DESC": query = query.OrderByDescending(p => p.Genero); break;
 default:
 query = query.OrderBy(p => p.Id);
 break;
 }
 }
 return query.Skip(startRowIndex).Take(maximumRows);
 }

 public int GetCount()
 {
 return _repo.GetAll().Count();
 }

 [DataObjectMethod(DataObjectMethodType.Insert)]
 public void Create(Paciente paciente)
 {
 if (paciente == null) throw new ArgumentNullException(nameof(paciente));
 // ejemplo de validación mínima
 if (string.IsNullOrWhiteSpace(paciente.Nombre)) throw new ArgumentException("Nombre requerido");
 if (string.IsNullOrWhiteSpace(paciente.Apellido)) throw new ArgumentException("Apellido requerido");
 _repo.Add(paciente);
 _repo.SaveChanges();
 }

 [DataObjectMethod(DataObjectMethodType.Update)]
 public void Update(Paciente paciente)
 {
 if (paciente == null) throw new ArgumentNullException(nameof(paciente));
 _repo.Update(paciente);
 _repo.SaveChanges();
 }

 [DataObjectMethod(DataObjectMethodType.Delete)]
 public void Delete(int id)
 {
 var entity = _repo.GetById(id);
 if (entity == null) return;
 _repo.Remove(entity);
 _repo.SaveChanges();
 }
 }
}