
﻿using AutoMapper;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Common;
using ToDoList.Domain.Interfaces.Common;
using MediatR;

namespace ToDoList.Application.UseCase.BaseCase
{
    public class DeleteHandler<IService, DeleteRequest, Request, Response, Entity> : IRequestHandler<DeleteRequest, ApiResponse>
        where Entity : BaseEntity
        where Response : BaseDTO
        where Request : IRequest<ApiResponse>
        where DeleteRequest : IRequest<ApiResponse>
        where IService : IBaseService<Request, Response, Entity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IService _service;
        private readonly IMapper _mapper;

        public DeleteHandler(IUnitOfWork unitOfWork, IService service, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteRequest deleteRequest, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<Entity>(deleteRequest);
            var response = await _service.Delete(request.Id, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);
            return response;
        }
    }
}