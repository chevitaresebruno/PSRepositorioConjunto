
using MediatR;

namespace ToDoList.Application.Security.Account.UseCases.Create
{
    public record Request(
        string Name,
        string Email,
        string Password
    ) : IRequest<Response>;
}