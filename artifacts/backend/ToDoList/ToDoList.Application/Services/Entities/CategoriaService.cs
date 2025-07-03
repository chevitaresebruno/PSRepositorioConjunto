
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
    public class CategoriaService :
        BaseService<
            CategoriaRequestDTO,
            CategoriaResponseDTO,
            Categoria,
            ICategoriaRepository>, ICategoriaService
    {
        public CategoriaService(IMediator mediator, IMapper mapper, ICategoriaRepository repository) : base(mediator, mapper, repository) { }
    }
}