
using ToDoList.Domain.Security.Account.Entities;
namespace ToDoList.Application.Security.Interfaces
{
    public interface IService
    {
        Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);
        Task SendResetPasswordAsync(User user, CancellationToken cancellationToken);
    }
}