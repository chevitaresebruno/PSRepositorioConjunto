
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Create;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Delete;
using ToDoList.Application.UseCase.Entities.CategoriaCase.GetAll;
using ToDoList.Application.UseCase.Entities.CategoriaCase.GetById;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Update;
using ToDoList.WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApi.Controllers.Entities
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : BaseController
        <GetAllCategoriaCommand, 
        GetByIdCategoriaCommand, 
        CreateCategoriaCommand, 
        UpdateCategoriaCommand, 
        DeleteCategoriaCommand, 
        CategoriaResponseDTO>
    {
        public CategoriaController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}