
using ToDoList.Domain.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
  namespace ToDoList.Domain.Entities
    {
    
    
    public  class Tarefa : BaseEntity {
      
  
  public string Titulo { get; set; }
  
  public string Descricao { get; set; }
  
  public DateTime Data_vencimento { get; set; }
      
        //ManyToOne
        public Categoria? Categoria { get; set; }
        public Guid TarefaCategoriaId {get; set; }
      
        //ManyToOne
        public Usuario? Usuario { get; set; }
        public Guid TarefaUsuarioId {get; set; }
      
      
  
  public Prioridade Prioridade { get; set; }
  
  public Status Status { get; set; }
  
  
    public Tarefa()
        {
        }
    public Tarefa(
string titulo,
string descricao,
DateTime data_vencimento, Guid categoriaId,Guid usuarioId, Prioridade prioridade,Status status)
        {
          
          var validationErrors = TarefaValidation(
titulo,
descricao,
data_vencimento, categoriaId,usuarioId, prioridade,status);
          if (validationErrors.Count > 0)
            {
              throw new DomainValidationException(validationErrors);
            }
            
          
Titulo = titulo;
Descricao = descricao;
Data_vencimento = data_vencimento;
          
        TarefaCategoriaId = categoriaId;
      
        TarefaUsuarioId = usuarioId;
      
          
  
  Prioridade = prioridade;
  
  Status = status;
  
  
        }
    private List<string>TarefaValidation(
string titulo,
string descricao,
DateTime data_vencimento, Guid categoriaId,Guid usuarioId, Prioridade prioridade,Status status)
      {
        var errors = new List<string>();
        // Validations
        return errors;
      }
    }
    }
  