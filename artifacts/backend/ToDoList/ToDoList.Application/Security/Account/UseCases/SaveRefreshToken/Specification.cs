
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDoList.Application.Security.Account.UseCases.SaveRefreshToken
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
              => new Contract<Notification>()
                    .Requires()
                    .IsNotNull(request.Id, "O Id de usuário não pode ser nulo")
                    .IsNotNull(request.RefreshToken, "O Refresh Token não pode ser nulo");
    }
}