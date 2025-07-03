
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Update
{
    public record UpdateUsuarioCommand(
      Guid Id,
      
    
    string Nome,
    

    String _email,
    

    string Senha,
    
    
    
    
    
            Guid CategoriaId
    ) : IRequest<ApiResponse>;
}