
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.GetAll
{
    public class GetAllTarefaHandler : GetAllHandler<ITarefaService, GetAllTarefaCommand, TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
        public GetAllTarefaHandler(ITarefaService service) : base(service)
        {
        }
    }
}