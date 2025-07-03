
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.GetAll
{
    public class GetAllUsuarioHandler : GetAllHandler<IUsuarioService, GetAllUsuarioCommand, UsuarioRequestDTO, UsuarioResponseDTO, Usuario>
    {
        public GetAllUsuarioHandler(IUsuarioService service) : base(service)
        {
        }
    }
}