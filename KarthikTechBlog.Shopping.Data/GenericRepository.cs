using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
   where TEntity : class, new()
    {
        private readonly ShoppingDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ShoppingDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", CancellationToken cancellationToken = default, bool trackable = true)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = trackable ? query.Where(filter).AsNoTracking() : query.Where(filter).AsNoTracking();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return query.AsNoTracking().ToListAsync();
            }
        }

        public virtual Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return dbSet.FindAsync(id);
        }

        public virtual Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateStateAlone(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void DetachEntities(TEntity entityToDetach)
        {
            context.Entry(entityToDetach).State = EntityState.Detached;
        }

        public void DetachEntities(List<TEntity> entitiesToDetach)
        {
            foreach (var entity in entitiesToDetach)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
        }



    }
}
