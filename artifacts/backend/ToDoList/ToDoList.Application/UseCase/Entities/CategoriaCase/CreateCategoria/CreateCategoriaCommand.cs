
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.Create
{
    public record CreateCategoriaCommand(
      
    
    string? Nome
    ) : IRequest<ApiResponse>;
}

