
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.GetById
{
    public record GetByIdCategoriaCommand(Guid Id) : IRequest<IQueryable<CategoriaResponseDTO>>
    {
    }
}