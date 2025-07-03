
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Create;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Delete;
using ToDoList.Application.UseCase.Entities.UsuarioCase.GetAll;
using ToDoList.Application.UseCase.Entities.UsuarioCase.GetById;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Update;
using ToDoList.WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApi.Controllers.Entities
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : BaseController
        <GetAllUsuarioCommand, 
        GetByIdUsuarioCommand, 
        CreateUsuarioCommand, 
        UpdateUsuarioCommand, 
        DeleteUsuarioCommand, 
        UsuarioResponseDTO>
    {
        public UsuarioController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}