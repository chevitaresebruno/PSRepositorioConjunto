
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.UseCase.Entities.TarefaCase.Create;
using ToDoList.Application.UseCase.Entities.TarefaCase.Delete;
using ToDoList.Application.UseCase.Entities.TarefaCase.GetAll;
using ToDoList.Application.UseCase.Entities.TarefaCase.GetById;
using ToDoList.Application.UseCase.Entities.TarefaCase.Update;
using ToDoList.WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApi.Controllers.Entities
{
    [Route("api/Tarefa")]
    [ApiController]
    public class TarefaController : BaseController
        <GetAllTarefaCommand, 
        GetByIdTarefaCommand, 
        CreateTarefaCommand, 
        UpdateTarefaCommand, 
        DeleteTarefaCommand, 
        TarefaResponseDTO>
    {
        public TarefaController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}