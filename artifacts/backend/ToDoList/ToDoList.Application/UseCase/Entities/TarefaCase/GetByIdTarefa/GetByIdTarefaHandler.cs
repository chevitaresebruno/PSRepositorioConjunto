
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.TarefaCase.GetById
{
    internal class GetByIdTarefaHandler : GetByIdHandler<ITarefaService, GetByIdTarefaCommand, TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
        public GetByIdTarefaHandler(ITarefaService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
