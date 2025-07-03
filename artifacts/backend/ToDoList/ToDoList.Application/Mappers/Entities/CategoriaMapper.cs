
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Create;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Delete;
using ToDoList.Application.UseCase.Entities.CategoriaCase.GetById;
using ToDoList.Application.UseCase.Entities.CategoriaCase.Update;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers.Entities
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            #region Entidade para DTO's
            CreateMap<Categoria, CategoriaResponseDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaRequestDTO>().ReverseMap();
                
            #endregion

            #region Entidade para Commads de Caso de Uso
            CreateMap<Categoria, CreateCategoriaCommand>().ReverseMap();
            CreateMap<Categoria, UpdateCategoriaCommand>().ReverseMap();
            CreateMap<Categoria, GetByIdCategoriaCommand>().ReverseMap();
            CreateMap<Categoria, DeleteCategoriaCommand>().ReverseMap();
            #endregion

            #region DTO's para Commads de Caso de Uso
            CreateMap<CategoriaRequestDTO, CreateCategoriaCommand>().ReverseMap() ;
            CreateMap<CategoriaRequestDTO, UpdateCategoriaCommand>().ReverseMap() ;
            CreateMap<CategoriaRequestDTO, DeleteCategoriaCommand>().ReverseMap();
            #endregion

            #region Conversão para api response
            CreateMap<ApiResponse, CategoriaRequestDTO>().ReverseMap();
            CreateMap<ApiResponse, CreateCategoriaCommand>().ReverseMap();
            CreateMap<ApiResponse, UpdateCategoriaCommand>().ReverseMap();
            CreateMap<ApiResponse, DeleteCategoriaCommand>().ReverseMap();
            #endregion
        }
    }
}