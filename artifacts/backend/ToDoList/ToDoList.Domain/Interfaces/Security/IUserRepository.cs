
using ToDoList.Domain.Security.Account.Entities;
namespace ToDoList.Domain.Interfaces.Security
{
    public interface IUserRepository : IBaseSecurityRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User?> GetUserByCode(string code, CancellationToken cancellationToken);
        Task<User?> GetUserByPasswordCode(string code, CancellationToken cancellationToken);
        public Task<User?> GetUserByRefreshCode(Guid refreshToken, CancellationToken cancellationToken);
        Task<bool> AnyAsync(string email, CancellationToken cancelationToken);
    }
}
