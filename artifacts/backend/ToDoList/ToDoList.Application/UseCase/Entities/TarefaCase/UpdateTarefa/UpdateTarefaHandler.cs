
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Update
{
    public class UpdateTarefaHandler : UpdateHandler<ITarefaService, UpdateTarefaCommand, TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
        public UpdateTarefaHandler(IUnitOfWork unitOfWork, ITarefaService service, IMapper mapper) : base(unitOfWork, service, mapper) { }
    }
}