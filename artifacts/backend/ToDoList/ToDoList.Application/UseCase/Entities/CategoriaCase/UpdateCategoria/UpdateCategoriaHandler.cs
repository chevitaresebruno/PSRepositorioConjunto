
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Common;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.Update
{
    public class UpdateCategoriaHandler : UpdateHandler<ICategoriaService, UpdateCategoriaCommand, CategoriaRequestDTO, CategoriaResponseDTO, Categoria>
    {
        public UpdateCategoriaHandler(IUnitOfWork unitOfWork, ICategoriaService service, IMapper mapper) : base(unitOfWork, service, mapper) { }
    }
}