
using ToDoList.Application.DTOs.Common;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Delete
{
    public record DeleteTarefaCommand(Guid Id) : IRequest<ApiResponse>
    {
    }
}
