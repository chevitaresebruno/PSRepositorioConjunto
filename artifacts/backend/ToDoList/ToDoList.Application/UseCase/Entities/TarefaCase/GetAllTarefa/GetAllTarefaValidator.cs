
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.GetAll
{
    public class GetAllTarefaValidator : AbstractValidator<GetAllTarefaCommand>
    {
        public GetAllTarefaValidator()
        {
        }
    }
}
