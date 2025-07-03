
using ToDoList.Application.DTOs.Common;
using MediatR;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Update
{
    public record UpdateTarefaCommand(
      Guid Id,
      
    
    string Titulo,
    

    string Descricao,
    

    DateTime Data_vencimento,
    
    
    
    Prioridade prioridade,
    

    Status status,
    
    
    
            Guid CategoriaId,

            Guid UsuarioId
    ) : IRequest<ApiResponse>;
}