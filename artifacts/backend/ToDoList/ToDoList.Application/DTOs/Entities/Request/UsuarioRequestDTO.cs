
using ToDoList.Application.DTOs.Common;
using ToDoList.Domain.Enums;
using MediatR;
namespace ToDoList.Application.DTOs.Entities.Request
{
    public class UsuarioRequestDTO : IRequest<ApiResponse>
    {
        public Guid Id {get; set;}
        
    public string Nome { get; set; }
    
    public String _email { get; set; }
    
    public string Senha { get; set; }
    
        
    
    
        
          public Guid UsuarioCategoriaId { get; set; }
    }
}