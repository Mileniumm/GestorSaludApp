using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GestorSalud.C3_DAL.Repositories
{
 public class Repository<TEntity> where TEntity : class
 {
 protected readonly DbContext _context;
 protected readonly DbSet<TEntity> _dbSet;

 public Repository(DbContext context)
 {
 _context = context ?? throw new ArgumentNullException(nameof(context));
 _dbSet = _context.Set<TEntity>();
 }

 public IQueryable<TEntity> GetAll() => _dbSet;
 public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);
 public TEntity GetById(object id) => _dbSet.Find(id);
 public void Add(TEntity entity) => _dbSet.Add(entity);
 public void Update(TEntity entity)
 {
 _dbSet.Attach(entity);
 _context.Entry(entity).State = EntityState.Modified;
 }
 public void Remove(TEntity entity)
 {
 if (_context.Entry(entity).State == EntityState.Detached)
 {
 _dbSet.Attach(entity);
 }
 _dbSet.Remove(entity);
 }
 public int SaveChanges() => _context.SaveChanges();
 }
}