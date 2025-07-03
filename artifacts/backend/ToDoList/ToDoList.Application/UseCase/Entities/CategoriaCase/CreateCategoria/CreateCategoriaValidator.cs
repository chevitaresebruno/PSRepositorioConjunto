
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.Create
{
    public class CreateCategoriaValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaValidator()
        {
        }
    }
}