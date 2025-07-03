
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Create
{
    public class CreateUsuarioHandler : CreateHandler<IUsuarioService, CreateUsuarioCommand, UsuarioRequestDTO, UsuarioResponseDTO, Usuario>
    {
        public CreateUsuarioHandler(IUnitOfWork unitOfWork, IUsuarioService service, IMapper mapper) : base(unitOfWork, service, mapper)
        {
        }
    }
}