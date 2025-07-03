
using ToDoList.Application.DTOs.Common;
using ToDoList.Domain.Enums;
using MediatR;
namespace ToDoList.Application.DTOs.Entities.Request
{
    public class CategoriaRequestDTO : IRequest<ApiResponse>
    {
        public Guid Id {get; set;}
        
    public string Nome { get; set; }
    
        
    
    
        
    }
}