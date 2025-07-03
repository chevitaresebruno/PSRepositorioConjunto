
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.Delete
{
    public class DeleteUsuarioHandler : DeleteHandler<IUsuarioService, DeleteUsuarioCommand, UsuarioRequestDTO, UsuarioResponseDTO, Usuario>
    {
        public DeleteUsuarioHandler(IUnitOfWork unitOfWork, IUsuarioService service, IMapper mapper) : base(unitOfWork, service, mapper)
        {
        }
    }
}