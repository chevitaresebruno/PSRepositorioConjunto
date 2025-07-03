
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Create
{
    public record CreateTarefaCommand(
      
    
    string? Titulo,
    

    string? Descricao,
    

    DateTime? Data_vencimento,
    
    

    Prioridade prioridade,
  

    Status status,
  

    
            Guid CategoriaId,

            Guid UsuarioId
    ) : IRequest<ApiResponse>;
}

