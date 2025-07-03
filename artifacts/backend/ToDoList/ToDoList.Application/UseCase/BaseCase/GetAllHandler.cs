
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Common;
using MediatR;

namespace ToDoList.Application.UseCase.BaseCase
{
    public class GetAllHandler<IService, GetRequest, Request, Response, Entity> : IRequestHandler<GetRequest, IQueryable<Response>>
        where Entity : BaseEntity
        where Response : BaseDTO
        where GetRequest : IRequest<IQueryable<Response>>
        where Request : IRequest<ApiResponse>
        where IService : IBaseService<Request, Response, Entity>
    {
        protected readonly IService _service;

        public GetAllHandler(IService service)
        {
            _service = service;
        }


        public async Task<IQueryable<Response>> Handle(GetRequest getRequest, CancellationToken cancellationToken)
        {
            return await _service.GetAll();
        }
    }
}