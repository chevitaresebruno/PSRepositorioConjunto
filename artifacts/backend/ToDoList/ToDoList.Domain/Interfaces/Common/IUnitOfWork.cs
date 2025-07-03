
namespace ToDoList.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}