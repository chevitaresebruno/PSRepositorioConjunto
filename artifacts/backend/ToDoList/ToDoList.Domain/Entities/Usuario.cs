
using ToDoList.Domain.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
  namespace ToDoList.Domain.Entities
    {
    
    
    public  class Usuario : BaseEntity {
      
  
  public string Nome { get; set; }
  
  public String _email { get; set; }
  
  public string Senha { get; set; }
      
        //ManyToOne
        public Categoria? Categoria { get; set; }
        public Guid UsuarioCategoriaId {get; set; }
      
      //OneToMany
      public ICollection<Tarefa>? Tarefas { get; set;}
      
      
  
  
    public Usuario()
        {
        }
    public Usuario(
string nome,
String _email,
string senha, Guid categoriaId)
        {
          
          var validationErrors = UsuarioValidation(
nome,
_email,
senha, categoriaId);
          if (validationErrors.Count > 0)
            {
              throw new DomainValidationException(validationErrors);
            }
            
          
Nome = nome;
_email = _email;
Senha = senha;
          
        UsuarioCategoriaId = categoriaId;
      
          
  
  
        }
    private List<string>UsuarioValidation(
string nome,
String _email,
string senha, Guid categoriaId)
      {
        var errors = new List<string>();
        // Validations
        return errors;
      }
    }
    }
  