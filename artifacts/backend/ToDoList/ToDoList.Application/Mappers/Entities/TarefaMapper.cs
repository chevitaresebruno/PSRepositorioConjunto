
using AutoMapper;
using ToDoList.Application.DTOs.Entities.Request;
using ToDoList.Application.DTOs.Entities.Response;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.UseCase.Entities.TarefaCase.Create;
using ToDoList.Application.UseCase.Entities.TarefaCase.Delete;
using ToDoList.Application.UseCase.Entities.TarefaCase.GetById;
using ToDoList.Application.UseCase.Entities.TarefaCase.Update;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappers.Entities
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            #region Entidade para DTO's
            CreateMap<Tarefa, TarefaResponseDTO>().ReverseMap();
            CreateMap<Tarefa, TarefaRequestDTO>().ReverseMap();
                
            #endregion

            #region Entidade para Commads de Caso de Uso
            CreateMap<Tarefa, CreateTarefaCommand>().ReverseMap();
            CreateMap<Tarefa, UpdateTarefaCommand>().ReverseMap();
            CreateMap<Tarefa, GetByIdTarefaCommand>().ReverseMap();
            CreateMap<Tarefa, DeleteTarefaCommand>().ReverseMap();
            #endregion

            #region DTO's para Commads de Caso de Uso
            CreateMap<TarefaRequestDTO, CreateTarefaCommand>().ReverseMap() 

.ForMember(dest => dest.TarefaCategoriaId, opt => opt.MapFrom(src => src.CategoriaId))

.ForMember(dest => dest.TarefaUsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
            CreateMap<TarefaRequestDTO, UpdateTarefaCommand>().ReverseMap() 

.ForMember(dest => dest.TarefaCategoriaId, opt => opt.MapFrom(src => src.CategoriaId))

.ForMember(dest => dest.TarefaUsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
            CreateMap<TarefaRequestDTO, DeleteTarefaCommand>().ReverseMap();
            #endregion

            #region Conversão para api response
            CreateMap<ApiResponse, TarefaRequestDTO>().ReverseMap();
            CreateMap<ApiResponse, CreateTarefaCommand>().ReverseMap();
            CreateMap<ApiResponse, UpdateTarefaCommand>().ReverseMap();
            CreateMap<ApiResponse, DeleteTarefaCommand>().ReverseMap();
            #endregion
        }
    }
}