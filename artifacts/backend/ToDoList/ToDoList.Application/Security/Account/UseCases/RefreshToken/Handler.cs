
using MediatR;
using ToDoList.Application.Security.Account.UseCases.Authenticate;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;


namespace ToDoList.Application.Security.Account.UseCases.RefreshToken
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

            #region Recupera o usuário
            User? user;
            try
            {
                user = await _repository.GetUserByRefreshCode(request.RefreshToken, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
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

            throw new NotImplementedException();
        }
    }
}