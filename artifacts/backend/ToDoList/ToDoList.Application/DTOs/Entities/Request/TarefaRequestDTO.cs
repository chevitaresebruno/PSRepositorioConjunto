
using ToDoList.Application.DTOs.Common;
using ToDoList.Domain.Enums;
using MediatR;
namespace ToDoList.Application.DTOs.Entities.Request
{
    public class TarefaRequestDTO : IRequest<ApiResponse>
    {
        public Guid Id {get; set;}
        
    public string Titulo { get; set; }
    
    public string Descricao { get; set; }
    
    public DateTime Data_vencimento { get; set; }
    
        
    
    public Prioridade Prioridade { get; set; }
    
    public Status Status { get; set; }
    
    
        
          public Guid TarefaCategoriaId { get; set; }
          public Guid TarefaUsuarioId { get; set; }
    }
}