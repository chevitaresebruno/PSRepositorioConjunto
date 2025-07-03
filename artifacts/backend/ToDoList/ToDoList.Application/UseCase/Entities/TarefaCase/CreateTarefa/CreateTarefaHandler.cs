
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.Create
{
    public class CreateTarefaHandler : CreateHandler<ITarefaService, CreateTarefaCommand, TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
        public CreateTarefaHandler(IUnitOfWork unitOfWork, ITarefaService service, IMapper mapper) : base(unitOfWork, service, mapper)
        {
        }
    }
}