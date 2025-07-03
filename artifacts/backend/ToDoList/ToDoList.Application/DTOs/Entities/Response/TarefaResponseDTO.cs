
using ToDoList.Application.DTOs.Common;
using ToDoList.Domain.Enums;
namespace ToDoList.Application.DTOs.Entities.Response
{
    public class TarefaResponseDTO : BaseDTO
    {
        
    public string Titulo { get; set; }
    
    public string Descricao { get; set; }
    
    public DateTime Data_vencimento { get; set; }
    
        
          public virtual CategoriaResponseDTO Categoria { get; set; }
          public Guid TarefaCategoriaId { get; set; }
          public virtual UsuarioResponseDTO Usuario { get; set; }
          public Guid TarefaUsuarioId { get; set; }
        
    
    public Prioridade Prioridade { get; set; }
    
    public Status Status { get; set; }
    
    
    }
}