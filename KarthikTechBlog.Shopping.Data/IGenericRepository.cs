using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Data
{
    public interface IGenericRepository<TEntity>
    {
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", CancellationToken cancellationToken = default, bool trackable = true);

        Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void UpdateStateAlone(TEntity entityToUpdate);
        void DetachEntities(TEntity entityToDetach);
        void DetachEntities(List<TEntity> entitiesToDetach);
    }
}
