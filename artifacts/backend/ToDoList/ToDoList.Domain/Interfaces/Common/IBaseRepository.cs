
using ToDoList.Domain.Common;
namespace ToDoList.Domain.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Any(Guid id);
        IQueryable<T> GetById(Guid id);
        IQueryable<T> GetAll();
        void AddRange(ICollection<T> entities);
        void DeleteRange(ICollection<T> entities);
    }
}