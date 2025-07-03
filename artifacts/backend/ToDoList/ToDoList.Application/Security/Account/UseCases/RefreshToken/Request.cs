
using MediatR;
using ToDoList.Application.Security.Account.UseCases.Authenticate;

namespace ToDoList.Application.Security.Account.UseCases.RefreshToken
{
    public record Request(
        Guid RefreshToken
    ) : IRequest<Response>;
}