
using ToDoList.Application.DTOs.Common;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.Delete
{
    public record DeleteCategoriaCommand(Guid Id) : IRequest<ApiResponse>
    {
    }
}
