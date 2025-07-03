
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.GetById
{
    internal class GetByIdCategoriaHandler : GetByIdHandler<ICategoriaService, GetByIdCategoriaCommand, CategoriaRequestDTO, CategoriaResponseDTO, Categoria>
    {
        public GetByIdCategoriaHandler(ICategoriaService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
