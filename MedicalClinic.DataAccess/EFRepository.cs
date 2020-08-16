using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(MedicalClinicDBContext dbContext)
        {

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();

        }
        protected MedicalClinicDBContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public virtual T GetById(long id)
        {
            return DbSet.Find(id);
        }


        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }
        public virtual void AddRange(T[] entities)
        {
            DbContext.AddRange(entities);
        }
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }
        public bool Save()
        {
            return (DbContext.SaveChanges()) > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return (await DbContext.SaveChangesAsync()) > 0;
        }

        public Task<T> GetByIdAsync(long id)
        {
            return DbSet.FindAsync(id);
        }
    }
}
