
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
    public class UsuarioService :
        BaseService<
            UsuarioRequestDTO,
            UsuarioResponseDTO,
            Usuario,
            IUsuarioRepository>, IUsuarioService
    {
        public UsuarioService(IMediator mediator, IMapper mapper, IUsuarioRepository repository) : base(mediator, mapper, repository) { }
    }
}