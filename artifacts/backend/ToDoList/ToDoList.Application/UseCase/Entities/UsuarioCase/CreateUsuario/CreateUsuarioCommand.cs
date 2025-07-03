
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Create
{
    public record CreateUsuarioCommand(
      
    
    string? Nome,
    

    String? _email,
    

    string? Senha,
    
    


    
            Guid CategoriaId
    ) : IRequest<ApiResponse>;
}

