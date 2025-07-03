
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.UsuarioCase.GetById
{
    internal class GetByIdUsuarioHandler : GetByIdHandler<IUsuarioService, GetByIdUsuarioCommand, UsuarioRequestDTO, UsuarioResponseDTO, Usuario>
    {
        public GetByIdUsuarioHandler(IUsuarioService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
