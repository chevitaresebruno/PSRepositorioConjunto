
using ToDoList.Domain.Security.Account.Entities;
namespace ToDoList.Domain.Interfaces.Security
{
    public interface IRoleRepository : IBaseSecurityRepository<Role>
    {
        Task<Role> GetRoleByName(string name, CancellationToken cancelationToken);
    }
}
