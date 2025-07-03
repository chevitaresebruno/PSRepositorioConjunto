
using MediatR;
using ToDoList.Application.Security.Account.UseCases.Authenticate;

namespace ToDoList.Application.Security.Account.UseCases.Verify
{
    public record Request(string Code) : IRequest<Response>;
}