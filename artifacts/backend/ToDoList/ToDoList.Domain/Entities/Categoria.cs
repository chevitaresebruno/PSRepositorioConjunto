
using ToDoList.Domain.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
  namespace ToDoList.Domain.Entities
    {
    
    
    public  class Categoria : BaseEntity {
      
  
  public string Nome { get; set; }
      
      //OneToMany
      public ICollection<Usuario>? Usuarios { get; set;}
      
      //OneToMany
      public ICollection<Tarefa>? Tarefas { get; set;}
      
      
  
  
    public Categoria()
        {
        }
    public Categoria(
string nome)
        {
          
          var validationErrors = CategoriaValidation(
nome);
          if (validationErrors.Count > 0)
            {
              throw new DomainValidationException(validationErrors);
            }
            
          
Nome = nome;
          
          
  
  
        }
    private List<string>CategoriaValidation(
string nome)
      {
        var errors = new List<string>();
        // Validations
        return errors;
      }
    }
    }
  