
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.GetAll
{
    public record GetAllUsuarioCommand() : IRequest<IQueryable<UsuarioResponseDTO>>;
}
