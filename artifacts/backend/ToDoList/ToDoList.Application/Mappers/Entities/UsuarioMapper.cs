
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Create;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Delete;
using ToDoList.Application.UseCase.Entities.UsuarioCase.GetById;
using ToDoList.Application.UseCase.Entities.UsuarioCase.Update;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers.Entities
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            #region Entidade para DTO's
            CreateMap<Usuario, UsuarioResponseDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();
                
            #endregion

            #region Entidade para Commads de Caso de Uso
            CreateMap<Usuario, CreateUsuarioCommand>().ReverseMap();
            CreateMap<Usuario, UpdateUsuarioCommand>().ReverseMap();
            CreateMap<Usuario, GetByIdUsuarioCommand>().ReverseMap();
            CreateMap<Usuario, DeleteUsuarioCommand>().ReverseMap();
            #endregion

            #region DTO's para Commads de Caso de Uso
            CreateMap<UsuarioRequestDTO, CreateUsuarioCommand>().ReverseMap() 

.ForMember(dest => dest.UsuarioCategoriaId, opt => opt.MapFrom(src => src.CategoriaId));
            CreateMap<UsuarioRequestDTO, UpdateUsuarioCommand>().ReverseMap() 

.ForMember(dest => dest.UsuarioCategoriaId, opt => opt.MapFrom(src => src.CategoriaId));
            CreateMap<UsuarioRequestDTO, DeleteUsuarioCommand>().ReverseMap();
            #endregion

            #region Conversão para api response
            CreateMap<ApiResponse, UsuarioRequestDTO>().ReverseMap();
            CreateMap<ApiResponse, CreateUsuarioCommand>().ReverseMap();
            CreateMap<ApiResponse, UpdateUsuarioCommand>().ReverseMap();
            CreateMap<ApiResponse, DeleteUsuarioCommand>().ReverseMap();
            #endregion
        }
    }
}