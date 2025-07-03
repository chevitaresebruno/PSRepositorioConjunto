
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.GetAll
{
    public record GetAllTarefaCommand() : IRequest<IQueryable<TarefaResponseDTO>>;
}
