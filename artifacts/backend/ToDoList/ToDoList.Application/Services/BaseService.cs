
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Common;
using ToDoList.Domain.Interfaces.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Application.Services
{
    public class BaseService<Request, Response, Entity, Repository> : IBaseService<Request, Response, Entity>
       where Entity : BaseEntity
       where Response : BaseDTO
       where Repository : IBaseRepository<Entity>
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly Repository _repository;
        public BaseService(IMediator mediator, IMapper mapper, Repository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }
        public virtual async Task<IQueryable<Response>> GetAll()
        {
            var result = _repository.GetAll();
            var response = result.ProjectTo<Response>(_mapper.ConfigurationProvider);
            return response;
        }
        public virtual async Task<IQueryable<Response>> GetById(Guid id)
        {
            var result = _repository.GetById(id);
            var response = result.ProjectTo<Response>(_mapper.ConfigurationProvider);
            return response;
        }
        public virtual async Task<ApiResponse> Create(Request request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity>(request);
            await _repository.Create(entity);
            return new ApiResponse(201, entity.Id.ToString(), "item criado com sucesso!");
        }
        public virtual async Task<ApiResponse> Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id).FirstOrDefaultAsync();
            await _repository.Delete(entity);
            return new ApiResponse(200, "item deletado com sucesso!");
        }
        public virtual async Task<ApiResponse> Update(Request request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity>(request);
            var result = await _repository.GetById(entity.Id).FirstOrDefaultAsync();
            result.Update(entity);
            await _repository.Update(result);
            return new ApiResponse(200, result.Id.ToString(), "item atualizado com sucesso!");
        }
        public virtual List<string> SaveValidation()
        {
            throw new NotImplementedException();
        }
    }
}