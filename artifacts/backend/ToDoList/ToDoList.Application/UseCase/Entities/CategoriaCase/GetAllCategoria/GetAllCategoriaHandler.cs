
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.UseCase.BaseCase;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.UseCase.Entities.CategoriaCase.GetAll
{
    public class GetAllCategoriaHandler : GetAllHandler<ICategoriaService, GetAllCategoriaCommand, CategoriaRequestDTO, CategoriaResponseDTO, Categoria>
    {
        public GetAllCategoriaHandler(ICategoriaService service) : base(service)
        {
        }
    }
}