
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.Update
{
    public record UpdateCategoriaCommand(
      Guid Id,
      
    
    string Nome
    ) : IRequest<ApiResponse>;
}