
using ToDoList.Application.DTOs.Entities.Response;
using MediatR;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.GetById
{
    public record GetByIdTarefaCommand(Guid Id) : IRequest<IQueryable<TarefaResponseDTO>>
    {
    }
}