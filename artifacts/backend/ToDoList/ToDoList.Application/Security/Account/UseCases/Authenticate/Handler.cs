
using MediatR;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;

namespace ToDoList.Application.Security.Account.UseCases.Authenticate
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
            #region Valida a requisição

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

            #region Recupera o perfil

            User? user;
            try
            {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion

            #region Verifica se a senha é válida

            if (!user.Password.Challenge(request.Password))
                return new Response("Usuário ou senha inválidos", 400);

            #endregion

            #region Verifica se a conta está verificada

            try
            {
                if (!user.Email.Verification.IsActive)
                    return new Response("Conta inativa", 400);
            }
            catch
            {
                return new Response("Não foi possível verificar seu perfil", 500);
            }

            #endregion

            await _unitOfWork.Commit(cancellationToken);

            #region Retorna os dados

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