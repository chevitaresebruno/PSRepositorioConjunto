
﻿using ToDoList.Application.DTOs.Common;

namespace ToDoList.Application.Interfaces
{
    public interface IBaseService<Request, Response, Entity>
    {
        Task<IQueryable<Response>> GetAll();
        Task<IQueryable<Response>> GetById(Guid id);
        Task<ApiResponse> Create(Request request, CancellationToken cancellationToken);
        Task<ApiResponse> Delete(Guid id, CancellationToken cancellationToken);
        Task<ApiResponse> Update(Request request, CancellationToken cancellationToken);
        abstract List<string> SaveValidation();

    }
}
