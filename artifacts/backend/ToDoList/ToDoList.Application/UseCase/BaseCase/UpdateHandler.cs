
﻿using AutoMapper;
using ToDoList.Application.DTOs.Common;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Common;
using ToDoList.Domain.Interfaces.Common;
using MediatR;

namespace ToDoList.Application.UseCase.BaseCase
{
    public class UpdateHandler<IService, UpdateRequest, Request, Response, Entity> : IRequestHandler<UpdateRequest, ApiResponse>
        where Entity : BaseEntity
        where Response : BaseDTO
        where UpdateRequest : IRequest<ApiResponse>
        where Request : IRequest<ApiResponse>
        where IService : IBaseService<Request, Response, Entity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IService _service;
        private readonly IMapper _mapper;

        public UpdateHandler(IUnitOfWork unitOfWork, IService service, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateRequest updateRequest, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<Request>(updateRequest);
            var response = await _service.Update(request, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);
            return response;
        }
    }
}