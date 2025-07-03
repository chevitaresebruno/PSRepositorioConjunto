
using MediatR;
using ToDoList.Application.Security.Interfaces;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;

namespace ToDoList.Application.Security.Account.UseCases.SendResetPassword
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IService _service;

        public Handler(IUserRepository repository, IUnitOfWork unitOfWork, IService service)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _service = service;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            #region Validar Requisição
            try
            {
                var res = Specification.Ensure(request);
                if (!res.IsValid) return new Response("Requisição inválida", 400, res.Notifications);
            }
            catch
            {
                return new Response("Não foi possível validar a sua requisição", 500);
            }
            #endregion

            #region Buscar usuário pelo Email
            User? user;
            try
            {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                {
                    return new Response("Usuário não encontrado", 404);
                }
            }
            catch
            {
                return new Response("Ocorreu algum erro inesperado no servidor", 500);
            }
            #endregion

            await _unitOfWork.Commit(cancellationToken);

            #region Enviar o código de alteração de senha via email
            try
            {
                if (user != null)
                    await _service.SendResetPasswordAsync(user, cancellationToken);
                return new Response("Código de alteração de senha enviado por email com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response("Ocorreu algum erro inesperado no servidor", 500);
            }
            #endregion

        }
    }
}