
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Delete
{
    public class DeleteTarefaHandler : DeleteHandler<ITarefaService, DeleteTarefaCommand, TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
        public DeleteTarefaHandler(IUnitOfWork unitOfWork, ITarefaService service, IMapper mapper) : base(unitOfWork, service, mapper)
        {
        }
    }
}