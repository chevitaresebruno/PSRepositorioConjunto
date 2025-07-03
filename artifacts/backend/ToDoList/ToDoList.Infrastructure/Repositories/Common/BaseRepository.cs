
using ToDoList.Domain.Common;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Infrastructure.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
            DbSet =  Context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await Context.AddAsync(entity);
        }
        public async Task Delete(T entity)
        {
            entity.Delete();
            await Task.Run(() => Context.Remove(entity), new CancellationToken());
        }
        public async Task Update(T entity)
        {
            await Task.Run(() => Context.Update(entity), new CancellationToken());
        }
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>()
                 .AsSplitQuery().AsQueryable();
        }
        public IQueryable<T> GetById(Guid id)
        {
            return Context.Set<T>().Where(x => x.Id == id).AsNoTracking().AsQueryable();
        }
        public async Task<bool> Any(Guid id)
        {
            return await Context.Set<T>().AnyAsync(x => x.Id.Equals(id));
        }
        public void DeleteRange(ICollection<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
        public void AddRange(ICollection<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
    }
}