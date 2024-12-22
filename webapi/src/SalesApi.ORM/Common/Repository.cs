using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Common;

namespace SalesApi.ORM.Common
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            Context = context;
        }

        public int SaveChanges() => Context.SaveChanges();

        #region GET

        public virtual async Task<T?> GetById(Guid id) =>
            await Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            var query = Context.Set<T>()
                .AsQueryable()
                .Skip(skip)
                .Take(take);

            return await query.AsNoTracking().ToListAsync();
        }

        #endregion

        public async Task<T> Add(T entity)
        {
            var entry = await Context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => Context.Set<T>().Update(entity));
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => Context.Set<T>().Remove(new T() { Id = id }));
        }
    }
}
