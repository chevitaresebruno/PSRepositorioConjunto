
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Application.Services.Entities
{
    public class TarefaService :
        BaseService<
            TarefaRequestDTO,
            TarefaResponseDTO,
            Tarefa,
            ITarefaRepository>, ITarefaService
    {
        public TarefaService(IMediator mediator, IMapper mapper, ITarefaRepository repository) : base(mediator, mapper, repository) { }
    }
}