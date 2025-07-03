
using ToDoList.Application.DTOs.Common;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Delete
{
    public record DeleteUsuarioCommand(Guid Id) : IRequest<ApiResponse>
    {
    }
}
