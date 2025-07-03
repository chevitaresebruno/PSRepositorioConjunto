
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Delete
{
    public class DeleteTarefaValidator : AbstractValidator<DeleteTarefaCommand>
    {
        public DeleteTarefaValidator()
        {
        
        }
    }
}