
using ToDoList.Application.DTOs.Common;
using ToDoList.Domain.Enums;
namespace ToDoList.Application.DTOs.Entities.Response
{
    public class UsuarioResponseDTO : BaseDTO
    {
        
    public string Nome { get; set; }
    
    public String _email { get; set; }
    
    public string Senha { get; set; }
    
        
          public virtual CategoriaResponseDTO Categoria { get; set; }
          public Guid UsuarioCategoriaId { get; set; }
        
    
    
    }
}