
using MediatR;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;

namespace ToDoList.Application.Security.Account.UseCases.ChangePassword
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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

            #region Buscar usuário pelo código
            User? user;
            try
            {
                user = await _repository.GetUserByPasswordCode(request.Code, cancellationToken);
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

            #region Alterar senha do usuário
            try
            {
                user.UpdatePassword(request.Password, request.Code);
            }
            catch
            {
                return new Response("Não foi possível realizar a alteração de senha", 404);
            }
            #endregion

            await _unitOfWork.Commit(cancellationToken);

            return new Response("Senha alterada com sucesso!");
        }
    }
}