
using FluentValidation;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.GetAll
{
    public class GetAllCategoriaValidator : AbstractValidator<GetAllCategoriaCommand>
    {
        public GetAllCategoriaValidator()
        {
        }
    }
}
