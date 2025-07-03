
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.GetById
{
    public record GetByIdUsuarioCommand(Guid Id) : IRequest<IQueryable<UsuarioResponseDTO>>
    {
    }
}