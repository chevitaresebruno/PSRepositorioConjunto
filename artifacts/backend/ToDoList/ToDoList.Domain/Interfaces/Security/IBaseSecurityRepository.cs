
using ToDoList.Domain.Security.Shared.Entities;
namespace ToDoList.Domain.Interfaces.Security
{
    public interface IBaseSecurityRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetById(Guid id);
        IQueryable<T> GetAll();
    }
}
