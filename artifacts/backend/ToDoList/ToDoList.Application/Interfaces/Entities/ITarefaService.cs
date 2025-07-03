
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Interfaces.Entities
{
    public interface ITarefaService : IBaseService<TarefaRequestDTO, TarefaResponseDTO, Tarefa>
    {
    }
}

