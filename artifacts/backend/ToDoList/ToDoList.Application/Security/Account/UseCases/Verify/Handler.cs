
using MediatR;
using ToDoList.Application.Security.Account.UseCases.Authenticate;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;

namespace ToDoList.Application.Security.Account.UseCases.Verify
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
                if (!res.IsValid)
                    return new Response("Requisição inválida", 400, res.Notifications);
            }
            catch
            {
                return new Response("Não foi possível validar sua requisição", 500);
            }
            #endregion

            #region Recuperar usuário pelo código
            User? user;
            try
            {
                user = await _repository.GetUserByCode(request.Code, cancellationToken);
                if (user is null)
                    return new Response("Usuário não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar o usuário", 500);
            }
            #endregion

            #region Validar Código
            try
            {
                user.Email.Verification.Verify(request.Code);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 400);
            }
            #endregion

            await _unitOfWork.Commit(cancellationToken);

            #region Construtor da resposta
            try
            {
                var data = new ResponseData
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email.Address,
                    Roles = user.Roles.Select(x => x.Name).ToArray(),
                };

                return new Response(string.Empty, data);
            }
            catch
            {
                return new Response("Não foi possível obter os dados do perfil", 500);
            }
            #endregion
        }
    }
}