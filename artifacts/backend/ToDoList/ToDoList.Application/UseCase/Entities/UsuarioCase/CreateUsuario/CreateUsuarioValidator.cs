
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Create
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioValidator()
        {
        }
    }
}