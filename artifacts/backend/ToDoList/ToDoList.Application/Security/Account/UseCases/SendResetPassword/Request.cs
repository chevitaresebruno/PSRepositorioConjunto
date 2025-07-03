
using MediatR;

namespace ToDoList.Application.Security.Account.UseCases.SendResetPassword
{
    public record class Request(
        string Email
    ) : IRequest<Response>;
}