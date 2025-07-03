
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.GetAll
{
    public record GetAllCategoriaCommand() : IRequest<IQueryable<CategoriaResponseDTO>>;
}
