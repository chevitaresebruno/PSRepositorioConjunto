
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Create
{
    public class CreateTarefaValidator : AbstractValidator<CreateTarefaCommand>
    {
        public CreateTarefaValidator()
        {
        }
    }
}